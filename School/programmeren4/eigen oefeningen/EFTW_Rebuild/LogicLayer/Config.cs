using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public static class Config
    {
        public static string StoragePath { get; set; } = @"../../../";
        public static int drawingFactor = 4;
        public static List<string> monkeyNames = new List<string>()
            {"Marge",
            "Homer",
            "Bart",
            "Lisa",
            "Maggie",
            "Ned",
            "Tod",
            "Milhouse",
            "Edna",
            "Nelson",
            "Moe"
        };



    }
}
