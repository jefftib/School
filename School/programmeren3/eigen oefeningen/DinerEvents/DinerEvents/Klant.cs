using System;
using System.Collections.Generic;
using System.Text;

namespace DinerEvents
{
    public class Klant
    {
        /*
            • Class Klant
            • Property Naam: string
            • Ctor met naam
            • Method Betaal(string product)
            • Method Consumeer(string product) 
            bijkomende method Bestel(Ober ober, string product)
            • Roept Ober::BrengBestelling() op

         */
        public string Naam { get; set; }

        public Klant(string naam) 
        {
            Naam = naam;
        }

        public void Betaal(String product)
        {
            Console.WriteLine("Ik ben " + Naam + " en ik betaal: " + product);
        }

        public void Consumeer(String product) 
        {
            Console.WriteLine("Ik ben " + Naam + " en ik consumeer: " + product);
        }
        public void Bestel(Ober ober, string product) 
        {
            if (ober == null || string.IsNullOrEmpty(product)) return;
            ober.BrengBestelling(this, product);
        }
    }
}
