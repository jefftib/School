using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Mmodel
{
   public class ForestLog
    {
        public int Id { get; set; }
        public int ForestId { get; set; }
        public int TreeId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public ForestLog(int ForestId, int TreeId, int x, int y)
        {
            this.ForestId = ForestId;
            this.TreeId = TreeId;
            this.X = x;
            this.Y = y;
        }
        public ForestLog() { }

    }
}
