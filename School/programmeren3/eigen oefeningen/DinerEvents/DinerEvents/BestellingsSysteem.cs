using System;
using System.Collections.Generic;
using System.Text;

namespace DinerEvents
{
  public  class BestellingsSysteem
    {
        // Event BestellingEvent ifv BestelEventArgs
        public event EventHandler<BestelEventArgs> BestellingEvent;
        //Method GeefBestellingIn(BestelEventArgs): roept event op
      public void GeefBestellingIn(BestelEventArgs args) 
        {
            BestellingEvent?.Invoke(this, args);
        }
        

    }
}
