using System;
using System.Collections.Generic;
using System.Text;

namespace DinerEvents
{
   public class Ober
    {
        public string Naam { get; set; }
        public List<Klant> Klanten { get; set; }
        public Ober(string Naam)
        {
           
        }

        public void BrengBestelling(Klant klant, string product)
        {
            if(!Klanten.Contains(klant)){
                Klanten.Add(klant);
                Console.WriteLine("$klant toegevoegd");

            }
        }
        

    }

}
