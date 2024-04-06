using System;
using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;

namespace AC2_GestioDadesDemografiques
{
    public class Comarca
    {
        [Index(0)]
        public int Any { get; set; }

        [Index(1)]
        public int CodiComarca { get; set; }

        [Index(2)]
        public string? NomComarca { get; set; }

        [Index(3)]
        public int Poblacio { get; set; }

        [Index(4)]
        public double DomesticXarxa { get; set; }

        [Index(5)]
        public double ActivitatsEconomiques { get; set; }

        [Index(6)]
        public double Total { get; set; }

        [Index(7)]
        public double ConsumDomesticPerCapita { get; set; }

        public override string ToString()
        {
            return $"Any: {Any}\nCodi comarca: {CodiComarca}\nNom comarca: {NomComarca}\nPoblació: {Poblacio}\nDomestic xarxa: {DomesticXarxa}\nActivitat econòmica: {ActivitatsEconomiques}\nTotal: {Total}\nConsum domèstic: {ConsumDomesticPerCapita}\n";
        }
    }
}
