﻿using System;

// TODO: take taalcode into account, DEBUG test to disable lines of code, command line arg to use csv or bin; evaluate use of SortedList? Speedup? StringBuilder, Linq ...

namespace Straten
{
    class Program
    {
        static int Main(string[] args)
        {
            if(args.Length < 3)
            {
                Console.WriteLine("Usage: Straten.exe <operation> <nl|fr> <city>");
                return 1;
            }
            int operation = int.Parse(args[0]);
            string taalCode = args[1];
            string gemeente = args[2];            

            Land land = new Land { Id = 1, Naam = "Belgie", TaalCode = taalCode };
            var regio = new Regio { Id = 1, Naam = "Vlaanderen", Land = land };
            land.Regios.Add(regio.Naam, regio);

            switch(operation)
            {
                case 1:
                    land.Read();
                    land.Persist();
                    break;
                    /*
                default:
                case 2:
                    land.Load();
                    break;
                    */
            }

            Exporters.FileExporter fileExporter = new Exporters.FileExporter(land);
            fileExporter.Export(gemeente);
            /*
            Exporters.ConsoleExporter consoleExporter = new Exporters.ConsoleExporter(land);
            consoleExporter.Export(gemeente);
            */

            return 0;
        }
    }
}    