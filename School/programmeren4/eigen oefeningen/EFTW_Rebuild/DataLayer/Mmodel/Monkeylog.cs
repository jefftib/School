using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Mmodel
{
   public class Monkeylog
    {
        public int Id { get; set; }
        public int MonkeyId { get; set; }
        public string MonkeyName { get; set; }
        public int ForestId { get; set; }
        public int SequenceNumber { get; set; }
        public int TreeId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Monkeylog(string Monkeyname, int forestId, int SequenceNumber, int TreeId, int X, int Y) 
        {
            this.ForestId = forestId;
            this.MonkeyName = Monkeyname;
            this.SequenceNumber = SequenceNumber;
            this.TreeId = TreeId;
            this.X = X;
            this.Y = Y;
        }
        
    }
}
