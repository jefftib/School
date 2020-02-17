using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore
{
    class Person
    {
        public string Name { get; set; }
        public string CallMe() { return "Called" + Name; }
        public string MailMe() { return "Mailed" + Name; }

    }
}
