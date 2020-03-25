using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.Models
{
    class Hamburger : Burger
    {
        public override string Name => "Hamburger";

        public override float Price => 2.80f;
    }
}
