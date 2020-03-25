using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.Models
{
    class Water : Drink
    {
        public override string Name => "Water";

        public override float Price => 1f;
    }
}
