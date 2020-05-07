using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Linq;


namespace EscapeFromTheWoods
{
    public class Forest
    {
        private int Id; // wordt vervangen door DB-call naar laatste ID
        public int maxWidth { get; set; } // gebaseerd op aantal bomen in bos
        public int maxHeight { get; set; } // idem
        public int TreesInforest = 100; // wordt variabel
        public int monkeys = 3; // wordt variabel
        private Random _random = new Random();
        public List<Tree> treelist = new List<Tree>();
        public List<Monkey> Monkeylist = new List<Monkey>();

        private Forest(int maxWidth, int maxHeight, int trees, int monkeys)
        {

            this.maxWidth = maxWidth;
            this.maxHeight = maxHeight;
            this.TreesInforest = trees;
            this.monkeys = monkeys;
        }

        public static Forest BuildForest(int maxWidth, int maxHeight, int trees, int monkeys)
        {
            Forest forest = new Forest(maxWidth, maxHeight, trees, monkeys);
            return forest;
        }

        public void GenerateTrees()
        {
            for (int i = 0; i < TreesInforest; i++)
            {
                Tree t = new Tree(1, _random.Next(0, maxWidth), _random.Next(0, maxHeight));
                if (treelist.Contains(t))
                {
                    i--;
                }
                else
                {
                    treelist.Add(t);
                }

            }

        }

        public void PlaceMonkey()
        {
            for (int i = 0; i < monkeys; i++)
            {
                for (int i2 = 0; i2 < treelist.Count; i2++)
                {
                    int RandomTree = _random.Next(treelist.Count);
                    Monkey m = new Monkey(1, "Brian", treelist[RandomTree]); // MonkeyID komt later van de DB
                    var emptyTree = treelist.Where(x => x.occupied == false);
                    if (emptyTree.Contains(treelist[RandomTree]))
                    {
                        m.setTree(treelist[RandomTree]);
                        _ = treelist[RandomTree].occupied == true;
                        Monkeylist.Add(m);
                    }
                    else
                    {
                        i--;
                    }
                }
            }

        }

    }
}
 