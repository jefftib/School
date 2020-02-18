using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DinerEvents
{
  public  class Ober
    {
        /*
            •Class Ober
            • Property Naam: string
            • Property Klanten: List<Klant>
            • Ctor met naam
        
            Bijkomende Property BestellingsSysteem
            • Bijkomende method BrengBestelling(Klant klant, string
            product)
            • Voeg klant toe aan lijst van klanten indien nodig
            • Roep GeefBestellingIn() op van KeukenBestellingsSysteem

            • Bijkomende property Bel
            • set: abonneert zich op RingEvent met method
            BelGehoord(object sender, BestelEventArgs args);
            
         */
        private Bel _Bel;
        public Bel Bel
        {
            get
            {
                return this._Bel;
            }
            set
            {
                if (this._Bel != null) this.Bel.RingEvent -= this.BelGehoord;
               this._Bel = value;
                this._Bel.RingEvent += this.BelGehoord;
            }

        }

        public string Naam { get; set; }
        public BestellingsSysteem BestellingsSysteem { get; set; }
        private List<Klant> _Klanten = new List<Klant>();

        public Ober(string naam) 
        {
            Naam = naam;
        }

       public void BrengBestelling(Klant klant, string product) 
        {
            if (klant == null || string.IsNullOrEmpty(product)) return;
            if(!_Klanten.Contains(klant))
            {
                _Klanten.Add(klant);
                Console.WriteLine("klant toegevoegd");
                BestellingsSysteem.GeefBestellingIn(new BestelEventArgs { Klant = klant.Naam, Product = product });
            }

        }

        public void BelGehoord(object sender, BestelEventArgs args) 
        {
            var klant = this._Klanten.Where(k => k.Naam == args.Klant).FirstOrDefault();
            if (klant == null) return;
            klant.Betaal(args.Product);
            klant.Consumeer(args.Product);


        }


    }
}
