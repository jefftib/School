using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore
{
    class Store
    {
        public event EventHandler TruckArrived;

        protected virtual void OnTruckArrived(EventArgs e)
        {
            if (TruckArrived != null)
                TruckArrived.Invoke(this, e);

        }

        public void RaisTheEvent()
        {
            OnTruckArrived(null);
        }
       
    }
}
