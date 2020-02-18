using System;

namespace DinerEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            BestellingsSysteem bestellingsSysteem = new BestellingsSysteem();
            Klant klant1  = new Klant("Tafel1");
            Klant klant2 = new Klant("Tafel2");
            /*Maak object BestellingsSysteem
                • Ken object BestellingsSysteem toe aan ober object */
            Ober ober = new Ober("Jan")
            {
               
                BestellingsSysteem = bestellingsSysteem
            };
            Kok kok = new Kok("Marie")
            {
                bestellingsSysteem = bestellingsSysteem
         
            };
            /*
                • Klant 1: Bestel(ober, “Hoegaarden”);
                • Klant 2: Bestel(ober, “Koffie”);
                */
            klant1.Bestel(ober, "Hoegaarden");
            klant2.Bestel(ober, "Koffie");           

        }
    }
}
