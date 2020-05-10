using System;
using System.Collections.Generic;
using System.Linq;
using LogicLayer;
using System.Drawing;
namespace EscapeFromTheWoods
{
    public class Monkey
    {
        #region attributes
        public  int id { get; set; }
        public string naam { get; set; }
        public Tree tree;
        public List<Tree> VisitedTrees = new List<Tree>();
        LoggingLogic logging = new LoggingLogic();
        private static Random _random = new Random();
        public static List<Color> Colours = new List<Color> { Color.AliceBlue, Color.Yellow, Color.DarkTurquoise, Color.DeepPink, Color.Fuchsia, Color.Honeydew, Color.Indigo };
        public Color Colour;
        private int RandomColour = _random.Next(Colours.Count);

        #endregion

        #region methods

        public Monkey(int id, string naam, Tree tree)
        {
            this.id = id;
            this.naam = naam;
            this.tree = tree;
            this.Colour = Colours[RandomColour];
        }

        public void setTree(Tree tree)
        {
            this.tree = tree;
        }

        public  int CountJumps() 
        {
            return this.VisitedTrees.Count();
        }
        public void jump(Forest forest)
        {
            double dtb = distanceToBorder(forest, this.tree);
            Tree closestTree = GetClosestTree(forest);
            double distanceToClosestTree = distanceToTree(this.tree, closestTree);
            if (dtb < distanceToClosestTree)
            {
                this.setTree(this.tree = null);
                logging.LogJumps(this, forest);
             
            }
            else
            {
                logging.DrawPath(forest.image, this.tree, this.GetClosestTree(forest),this); ;
                this.setTree(this.GetClosestTree(forest));
                this.VisitedTrees.Add(this.tree);
                logging.LogJumps(this, forest);
            }
        }
        public Tree GetClosestTree(Forest forest)
        {
            Tree closestTree = null;
            double closestDistance = forest.maxWidth; // afstand gelijk met breedte van bos
            foreach (Tree t in forest.treelist)
            {
                if (distanceToTree(t, this.tree) < closestDistance && t != this.tree && !this.VisitedTrees.Contains(t))
                {
                    closestTree = t; // als deze boom dichter is dan closestDistance, en niet de huidige monkey-boom is en niet een vorige boom is van monkey
                    closestDistance = distanceToTree(t, this.tree); // stellen we deze in als dichtste boom
                }
            }
            return closestTree;
        }

        public static double distanceToTree(Tree treeFrom, Tree treeTo) 
        {
            return Math.Sqrt(Math.Pow(treeFrom.x - treeTo.x, 2) + Math.Pow(treeFrom.y - treeTo.y, 2));
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
