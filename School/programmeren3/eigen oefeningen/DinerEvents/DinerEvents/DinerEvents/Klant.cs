using System;
using System.Collections.Generic;
using System.Text;

namespace DinerEvents
{
   public class Klant
    {
        public string Naam { get; set; }

        public Klant(string Naam)
        {
           
        }

        public void Betaal(string Product)
        {
            Console.WriteLine("betaald" + Product);
        }
        public void Consumeer(string Product)
        {
            Console.WriteLine("consumeer" + Product);
        }
        public void Bestel(Ober ober, string product)
        {
            Ober.BrengBestelling(this, product);
        }

    }
}