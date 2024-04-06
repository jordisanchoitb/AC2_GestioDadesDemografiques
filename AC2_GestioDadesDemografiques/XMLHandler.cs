using System.Xml;

namespace AC2_GestioDadesDemografiques
{
    public class XMLHandler
    {
        const bool DEBUG = false;

        public static string PATH { get; set; }
        public static XmlDocument xmlDocument { get; set; }

        public XMLHandler(string path) 
        {
            PATH = path;
            xmlDocument = new XmlDocument();
            try {
                xmlDocument.Load(PATH);
            }
            catch (Exception e)
            {
                if (DEBUG)
                {
                    Console.WriteLine("Could not load the XML document.");
                    Console.WriteLine(e.Message);
                }
                return;
            }
        }

        public void ConvertToXml(List<Comarca> comarcas)
        {
            var xmlDocument = new XmlDocument();
            var rootNode = xmlDocument.CreateElement("Comarques");
            xmlDocument.AppendChild(rootNode);

            foreach (var comarca in comarcas)
            {
                var comarcaNode = xmlDocument.CreateElement("Comarca");
                rootNode.AppendChild(comarcaNode);

                var anyNode = xmlDocument.CreateElement("Any");
                anyNode.InnerText = comarca.Any.ToString();
                comarcaNode.AppendChild(anyNode);

                var codiNode = xmlDocument.CreateElement("Codi");
                codiNode.InnerText = comarca.CodiComarca.ToString();
                comarcaNode.AppendChild(codiNode);

                var nomNode = xmlDocument.CreateElement("Nom");
                nomNode.InnerText = comarca.NomComarca;
                comarcaNode.AppendChild(nomNode);

                var poblacioNode = xmlDocument.CreateElement("Poblacio");
                poblacioNode.InnerText = comarca.Poblacio.ToString();
                comarcaNode.AppendChild(poblacioNode);

                var domesticNode = xmlDocument.CreateElement("DomesticXarxa");
                domesticNode.InnerText = comarca.DomesticXarxa.ToString();
                comarcaNode.AppendChild(domesticNode);

                var activitatsNode = xmlDocument.CreateElement("ActivitatsEconomiques");
                activitatsNode.InnerText = comarca.ActivitatsEconomiques.ToString();
                comarcaNode.AppendChild(activitatsNode);

                var totalNode = xmlDocument.CreateElement("Total");
                totalNode.InnerText = comarca.Total.ToString();
                comarcaNode.AppendChild(totalNode);

                var consumNode = xmlDocument.CreateElement("ConsumDomesticPerCapita");
                consumNode.InnerText = comarca.ConsumDomesticPerCapita.ToString();
                comarcaNode.AppendChild(consumNode);
            }
            xmlDocument.Save(PATH);
        }
    }
}
