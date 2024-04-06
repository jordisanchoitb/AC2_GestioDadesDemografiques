using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace AC2_GestioDadesDemografiques
{
    public class CSVHandler
    {
        public static string PATH { get; set; }

        public CSVHandler(string path)
        {
            PATH = path;
        }

        public List<Comarca> ReadAllCsv()
        {
            using var reader = new StreamReader(PATH);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<Comarca>().ToList();
        }
    }
}
