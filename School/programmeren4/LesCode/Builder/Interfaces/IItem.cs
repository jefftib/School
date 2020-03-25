using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.Interfaces
{
    interface IItem
    {
        string Name { get; }
        IPacking Packing { get; }
        float Price { get; }
    }
}
