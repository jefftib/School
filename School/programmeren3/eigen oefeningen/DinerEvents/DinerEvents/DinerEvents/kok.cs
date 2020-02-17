using System;
using System.Collections.Generic;
using System.Text;

namespace DinerEvents
{
    public class Kok
    {
        public Bel Bel { get; set; }

        public string Naam { get; set; }

        private BestelSysteem _bestellingsSysteem;
        public BestelSysteem BestellingsSysteem
        {
            get
            {
                return _bestellingsSysteem;
            }
            set
            {
                if (_bestellingsSysteem != null) _bestellingsSysteem.BestelEvent -= BestellingOntvangen;
                _bestellingsSysteem = value;
                _bestellingsSysteem.BestelEvent += BestellingOntvangen;
            }
        }

        public Kok(string naam)
        {
            Naam = naam;
        }

        public void BestellingOntvangen(object sender, BestelEventArgs args)
        {
            if (args == null || string.IsNullOrEmpty(args.product)) return; // preconditie
            System.Console.WriteLine(args.product + " in voorbereiding");
            System.Threading.Thread.Sleep(5000);
            Bel.Ring(args);
        }
    }
}

