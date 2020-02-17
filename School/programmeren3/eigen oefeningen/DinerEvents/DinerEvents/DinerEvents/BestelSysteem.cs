using System;
using System.Collections.Generic;
using System.Text;

namespace DinerEvents
{
     public class BestelSysteem
    {
        public event EventHandler<BestelEventArgs> BestelEvent;
        public void geefbestellingIn(BestelEventArgs args)
        {
            BestelEvent?.Invoke(this, args);
        }
           
    }
}
