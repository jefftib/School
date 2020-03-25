using System;
using System.Collections.Generic;
using System.Text;
using Builder.Interfaces;
namespace Builder.Models
{
    public class Bottle : IPacking
    {
        public string Pack 
        {
            get 
            {
                return"Bottle"; 
            }
        }
    }
}
