using System;

namespace AC2_GestioDadesDemografiques
{
    public static class Program
    {
        public static void Main()
        {
            string pathcsv = @"..\..\..\fitxers\Consum_daigua_a_Catalunya_per_comarques.csv";
            string pathxml = @"..\..\..\fitxers\Consum_daigua_a_Catalunya_per_comarques.xml";
            CSVHandler csvHandler = new CSVHandler(pathcsv);
            XMLHandler xmlHandler = new XMLHandler(pathxml);

            List<Comarca> comarques = csvHandler.ReadAllCsv();
            xmlHandler.ConvertToXml(comarques);

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Methods.PrintMenu();
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        List<Comarca> comarquesSuperiorA200000 = Methods.PoblacioSuperiorA200000();
                        foreach (var comarca in comarquesSuperiorA200000)
                        {
                            Console.WriteLine(comarca);
                        }
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Methods.ConsumDomesticMitjaPerComarca();
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Comarca comarcaAmbConsumDomesticPerCapitaMesAlt = Methods.ComarquesAmbConsumDomesticPerCapitaMesAlt();
                        Console.WriteLine(comarcaAmbConsumDomesticPerCapitaMesAlt);
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Comarca comarcaAmbConsumDomesticPerCapitaMesBaix = Methods.ComarquesAmbConsumDomesticPerCapitaMesBaix();
                        Console.WriteLine(comarcaAmbConsumDomesticPerCapitaMesBaix);
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Introdueix el nom o el codi de la comarca que vols buscar:");
                        string nomOcodi = Console.ReadLine();
                        Console.WriteLine(Methods.FiltrarComarcaPerNomOCodi(nomOcodi));
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();
                        exit = true;
                        Console.WriteLine("Adeu!");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opció no vàlida.");
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}