using System;
using System.Collections.Generic;
using System.Text;

namespace Straten
{
    class Regio
    {
        public int Id;
        public string Naam;
        public string TaalCode;
        public int NaamId;
        public SortedList<string, Gemeente> Gemeeenten;
        public Land Land;
     
    }
}
