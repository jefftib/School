using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore
{
    public delegate string Todo();
    class Employee
    {
        public Todo Todolist { get; set; }
        public List<string> Completed { get; set; }

        private Store _store;
        public Store Store
        {
            get { return _store; }
            set
            {
                if (_store != null)
                    _store.TruckArrived -= new EventHandler(Store_TruckArrived);
                _store = value;
                _store.TruckArrived += new EventHandler(Store_TruckArrived);
            }
        }
        

        public Employee(Store store)
        {
            Store = store;
            Completed = new List<string>();
        }

        private void Store_TruckArrived(object sender, EventArgs e)
        {
           foreach(var todo in Todolist.GetInvocationList())
            {
                Completed.Add((string)todo.DynamicInvoke());
            }
            Todolist = null;
        }

    }
}
