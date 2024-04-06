using System;
using System.Xml.Linq;

namespace AC2_GestioDadesDemografiques
{
    public static class Methods
    {
        public static List<Comarca> PoblacioSuperiorA200000()
        {
            XDocument xmldoc = XDocument.Load(XMLHandler.PATH);

            var comarcas = from comarca in xmldoc.Descendants("Comarca")
                           where int.Parse(comarca.Element("Poblacio").Value) > 200000
                           select new Comarca
                           {
                               Any = int.Parse(comarca.Element("Any").Value),
                               CodiComarca = int.Parse(comarca.Element("Codi").Value),
                               NomComarca = comarca.Element("Nom").Value,
                               Poblacio = int.Parse(comarca.Element("Poblacio").Value),
                               DomesticXarxa = double.Parse(comarca.Element("DomesticXarxa").Value),
                               ActivitatsEconomiques = double.Parse(comarca.Element("ActivitatsEconomiques").Value),
                               Total = double.Parse(comarca.Element("Total").Value),
                               ConsumDomesticPerCapita = double.Parse(comarca.Element("ConsumDomesticPerCapita").Value)
                           };

            return comarcas.ToList();
        }

        public static void ConsumDomesticMitjaPerComarca()
        {
            XDocument xmldoc = XDocument.Load(XMLHandler.PATH);

            var comarcas = from comarca in xmldoc.Descendants("Comarca")
                           group comarca by comarca.Element("Nom").Value into g
                           select new
                           {
                               NomComarca = g.Key,
                               ConsumDomesticMitja = g.Average(x => double.Parse(x.Element("ConsumDomesticPerCapita").Value)),
                           };

            foreach (var comarca in comarcas)
            {
                Console.WriteLine($"Nom comarca: {comarca.NomComarca} - Consum domèstic mitjà: {comarca.ConsumDomesticMitja:N2}");

            }
        }

        public static Comarca ComarquesAmbConsumDomesticPerCapitaMesAlt()
        {
            XDocument xmldoc = XDocument.Load(XMLHandler.PATH);

            var comarcas = (from comarca in xmldoc.Descendants("Comarca")
                           where double.Parse(comarca.Element("ConsumDomesticPerCapita").Value) == xmldoc.Descendants("Comarca").Max(x => double.Parse(x.Element("ConsumDomesticPerCapita").Value))
                           select new Comarca
                           {
                               Any = int.Parse(comarca.Element("Any").Value),
                               CodiComarca = int.Parse(comarca.Element("Codi").Value),
                               NomComarca = comarca.Element("Nom").Value,
                               Poblacio = int.Parse(comarca.Element("Poblacio").Value),
                               DomesticXarxa = double.Parse(comarca.Element("DomesticXarxa").Value),
                               ActivitatsEconomiques = double.Parse(comarca.Element("ActivitatsEconomiques").Value),
                               Total = double.Parse(comarca.Element("Total").Value),
                               ConsumDomesticPerCapita = double.Parse(comarca.Element("ConsumDomesticPerCapita").Value)
                           }).FirstOrDefault();
            return comarcas;
        }

        public static Comarca ComarquesAmbConsumDomesticPerCapitaMesBaix()
        {
            XDocument xmldoc = XDocument.Load(XMLHandler.PATH);

            var comarcas = (from comarca in xmldoc.Descendants("Comarca")
                           where double.Parse(comarca.Element("ConsumDomesticPerCapita").Value) == xmldoc.Descendants("Comarca").Min(x => double.Parse(x.Element("ConsumDomesticPerCapita").Value))
                           select new Comarca
                           {
                               Any = int.Parse(comarca.Element("Any").Value),
                               CodiComarca = int.Parse(comarca.Element("Codi").Value),
                               NomComarca = comarca.Element("Nom").Value,
                               Poblacio = int.Parse(comarca.Element("Poblacio").Value),
                               DomesticXarxa = double.Parse(comarca.Element("DomesticXarxa").Value),
                               ActivitatsEconomiques = double.Parse(comarca.Element("ActivitatsEconomiques").Value),
                               Total = double.Parse(comarca.Element("Total").Value),
                               ConsumDomesticPerCapita = double.Parse(comarca.Element("ConsumDomesticPerCapita").Value)
                           }).FirstOrDefault();
            return comarcas;
        }

        public static Comarca FiltrarComarcaPerNomOCodi(string nomOcodi)
        {
            XDocument xmldoc = XDocument.Load(XMLHandler.PATH);

            var comarca = (from com in xmldoc.Descendants("Comarca")
                           where com.Element("Nom").Value == nomOcodi || com.Element("Codi").Value == nomOcodi
                           select new Comarca
                           {
                               Any = int.Parse(com.Element("Any").Value),
                               CodiComarca = int.Parse(com.Element("Codi").Value),
                               NomComarca = com.Element("Nom").Value,
                               Poblacio = int.Parse(com.Element("Poblacio").Value),
                               DomesticXarxa = double.Parse(com.Element("DomesticXarxa").Value),
                               ActivitatsEconomiques = double.Parse(com.Element("ActivitatsEconomiques").Value),
                               Total = double.Parse(com.Element("Total").Value),
                               ConsumDomesticPerCapita = double.Parse(com.Element("ConsumDomesticPerCapita").Value)
                           }).FirstOrDefault();

            return comarca;

        }

        public static void PrintMenu()
        {
            Console.WriteLine("1. Comarques amb població superior a 200.000 habitants");
            Console.WriteLine("2. Consum domèstic mitjà per comarca");
            Console.WriteLine("3. Comarques amb consum domèstic per càpita més alt");
            Console.WriteLine("4. Comarques amb consum domèstic per càpita més baix");
            Console.WriteLine("5. Filtrar comarca per nom o codi");
            Console.WriteLine("6. Sortir");
        }

        public static void ReadAndPrintAllCsv(CSVHandler csvHandler)
        {
            List<Comarca> records = csvHandler.ReadAllCsv();
            foreach (var record in records)
            {
                Console.WriteLine(record);
            }
            Console.WriteLine($"Hi han un total de {records.Count()} comarques");
        }
    }
}
