using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Mmodel
{
 public  class txtLog
    {
        public int Id { get; set; }
        public int ForestId { get; set; }
        public int MonkeyId { get; set; }
        public string Message { get; set; }

        public txtLog(int ForestId, int MonkeyId, string message)
        {
            this.Id = Id;
            this.ForestId = ForestId;
            this.MonkeyId = MonkeyId;
            this.Message = message;
        }
    }
}
