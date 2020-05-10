using System;

namespace EscapeFromTheWoods
{
    public class Tree
    {
        public int x;
        public int y;
        public int id;
        public bool occupied = false;

        public Tree(int id, int x , int y)
        {
            this.id = id;
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is Tree tree &&
                   x == tree.x &&
                   y == tree.y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }
    }
}
