using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.Models
{
    class Cola : Drink
    {
        public override string Name =>"Cola";

        public override float Price => 1.50f;
    }
}
