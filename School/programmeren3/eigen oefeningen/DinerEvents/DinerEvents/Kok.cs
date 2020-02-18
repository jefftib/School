using System;
using System.Collections.Generic;
using System.Text;

namespace DinerEvents
{
  public  class Kok
    {
        /*
           • Property Naam: string
            • Property BestellingSysteem
            • set: abonneer op event BestellingEvent met method
            void BestellingOntvangen(object sender,
            BestelEventArgs args)
            • Method BestellingOntvangen()
            laat weten dat product in voorbereiding is
            • System.Threading.Thread.Sleep(5000);
            Bijkomende property Bel
            • In method BestellingOntvangen(): roep Bel.Ring() op

         */
        public string Naam;
        public Bel Bel { get; set; }

        private BestellingsSysteem _bestellingsSysteem;
        public BestellingsSysteem bestellingsSysteem
        {
            get
            {
                return _bestellingsSysteem;
            }
            set
            {
                if (_bestellingsSysteem != null) _bestellingsSysteem.BestellingEvent -= BestellingOntvangen;
                _bestellingsSysteem = value;
                _bestellingsSysteem.BestellingEvent += BestellingOntvangen;
            }
        }
        
        public Kok(string naam) 
        {
            Naam = naam;
        }

        public void BestellingOntvangen(object sender, BestelEventArgs args) 
        {
            if (args == null || String.IsNullOrEmpty(args.Product)) return;
            Console.WriteLine(args.Product + " in voorbereiding");
            System.Threading.Thread.Sleep(5000);
            Bel.Ring(args);
        }
      }
}
