using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GenericParsing;

namespace Straten
{
    class Land
    {
        public int Id;
        public string Naam;
        public string TaalCode;
        public SortedList<string, Regio> Regios;

        public void Read()
        {
          

            using GenericParser RegioReader = new GenericParser(Config.Path + "/" + Config.RegioNamen)
            {
                ColumnDelimiter = ';',
                FirstRowHasHeader = true,
                MaxBufferSize = 4096 // hiermee mag je spelen
            };
            while (RegioReader.Read())
            {
                int naamId = int.Parse(RegioReader[0].Trim());

                RegioReader.Add(naamId,
                    new Regio
                    {
                        NaamId = naamId,
                        Id = int.Parse(RegioReader[1].Trim()),
                        TaalCode = RegioReader[2].Trim(),
                        Naam = RegioReader[3].Trim()
                    });
            }

        }
        public void Persist() 
        { }
        



    }
}
