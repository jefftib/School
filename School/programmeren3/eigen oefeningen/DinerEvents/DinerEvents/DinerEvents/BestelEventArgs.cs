using System;
using System.Collections.Generic;
using System.Text;

namespace DinerEvents
{
   public class BestelEventArgs
    {
        public string klant;
        public string product;

        public BestelEventArgs(string klant, string product)
        {
            this.klant = klant;
            this.product = product;
        }
    }
}
