using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscapeFromTheWoods
{
  public  class Monkey
    {
        #region attributes
        int id { get; set; }
        string naam { get; set; }
     public Tree tree;
        List<Tree> VisitedTrees = new List<Tree>();

        #endregion

        #region methods

        public Monkey(int id, string naam, Tree tree)
        {
            this.id = id;
            this.naam = naam;
            this.tree = tree;
        }

        public void setTree(Tree tree) 
        {
            this.tree = tree;
        }

        public void jump(Forest forest)
        {
            double dtb = distanceToBorder(forest, this.tree);
            Tree closestTree = GetClosestTree(forest);
            double distanceToClosestTree = distanceToTree(this.tree, closestTree);
            if (dtb < distanceToClosestTree)
            {
                // Monkey left forest
                Console.WriteLine("monkey left");
               setTree(this.tree = null);
                // TODO: LOG deze move
            }
            else
            {
                // Monkey Jumps function here
                Console.WriteLine("monkey jumps");
                this.setTree(this.GetClosestTree(forest));
                // TODO: LOG deze move
            }
        }
        public Tree GetClosestTree(Forest forest)
        {
            Tree closestTree = null;
            double closestDistance = forest.maxWidth; // afstand gelijk met breedte van bos
            foreach (Tree t in forest.treelist)
            {
                if (distanceToTree(t, this.tree) > closestDistance && t != this.tree && !this.VisitedTrees.Contains(t))
                {
                    closestTree = t; // als deze boom dichter is dan closestDistance, en niet de huidige monkey-boom is en niet een vorige boom is van monkey
                    closestDistance = distanceToTree(t, this.tree); // stellen we deze in als dichtste boom
                }
            }
            return closestTree;
        }

        public static double distanceToTree(Tree treeFrom, Tree treeTo) 
        {
            return Math.Sqrt(Math.Pow(treeFrom.x - treeFrom.x, 2) + Math.Pow(treeTo.y - treeTo.y, 2));
        }

        public static double distanceToBorder(Forest f, Tree t)
        {

            Forest currentForest = f;
            double distance = (new List<double>()
            {
                currentForest.maxWidth - t.x,
                currentForest.maxHeight - t.y,
                t.x - 0,
                t.y - 0 
            }).Min();
            return distance;

        }

        #endregion
    }
}
