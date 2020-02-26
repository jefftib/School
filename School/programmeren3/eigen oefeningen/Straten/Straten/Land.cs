using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GenericParsing;

namespace Straten
{
  public  class Land
    {
        public int Id;
        public string Naam;
        public string TaalCode;
        public SortedList<string, Regio> Regios = new SortedList<string, Regio>(); //new SortedList??


        public void Read()
        {
          

            using GenericParser RegioReader = new GenericParser(Config.Path + "/" + Config.ProvincieInfo)
            {
                ColumnDelimiter = ';',
                FirstRowHasHeader = true,
                MaxBufferSize = 4096 // hiermee mag je spelen
            };
            while (RegioReader.Read())
            {
                int naamId = int.Parse(RegioReader[0].Trim());
                if (!Regios.ContainsKey(RegioReader[3]))
                {
                    Regios.Add(RegioReader[3].Trim(),
              new Regio
              {
                  NaamId = naamId,
                  Id = int.Parse(RegioReader[1].Trim()),
                  TaalCode = RegioReader[2].Trim(),
                  Naam = RegioReader[3].Trim()
              });
                }
             
            }

        }
        public void Persist() 
        { }
        



    }
}
