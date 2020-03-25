using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.Models
{
    class ChickenBurger : Burger
    {
        public override string Name => "Chickenburger";

        public override float Price => 2.50f;
    }
}
