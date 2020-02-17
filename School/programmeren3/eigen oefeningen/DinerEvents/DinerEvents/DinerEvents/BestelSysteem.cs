using System;
using System.Collections.Generic;
using System.Text;

namespace DinerEvents
{
    class BestelSysteem
    {
        public event EventHandler<BestelEventArgs> _BestelEvent;
        public void geefbestellingIn(BestelEventArgs args)
        {
            _BestelEvent?.Invoke(this, args);
        }
           
    }
}
