using System;
using System.Collections.Generic;
using System.Text;

namespace Straten
{
   public static class Config
    {
        public static string TaalCode { get; set; } = "nl";
        public static string Path { get; set; } = @"C:\Users\jeffr\Desktop\repos\School\programmeren3\eigen oefeningen\Straten\Straten\repository";
        
        public const string StraatnaamGemeenteId = "StraatnaamID_gemeenteID.csv";
        public const string Straatnamen = "WRstraatnamen.csv";
        public const string ProvincieIds = "ProvincieIdsVlaanderen.csv";
        public const string ProvincieInfo = "ProvincieInfo.csv";
        public const string Gemeentenamen = "WRGemeentenaam.csv";


    }
}
