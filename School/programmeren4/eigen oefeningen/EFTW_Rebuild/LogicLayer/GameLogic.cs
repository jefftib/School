using System;
using System.Collections.Generic;
using EscapeFromTheWoods;


namespace LogicLayer
{
    public class GameLogic
    {
        ///
        /// <summary>
        /// Deze klasse is verantwoordelijk voor het uitvoeren van elke Game
        /// </summary>
        /// 
            public static int width;
            public static int height;
            public static int trees;
            public static int monkeys;
            public static int forests;
           
         static  LoggingLogic logging = new LoggingLogic();
        public static void info()
        {
                Console.WriteLine("Hoeveel bossen moeten er gemaakt worden");
                forests = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("hoe breed is bos");
                width = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("hoe hoog is bos");
                height = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("hoeveel bomen zijn er in bos");
                trees = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine($"hoeveel apen zijn er in bos");
                monkeys = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            
        }
        
        public static void PlayGame() 
        {
            info();
            for (int i = 0; i < forests; i++)
            {
                Forest forest = Forest.BuildForest(DataLayer.dbFunctions.GetForest()+1, width, height, trees, monkeys);
                List<Monkey> monkeysNotDone = new List<Monkey>();
                
                forest.GenerateTrees();
                forest.PlaceMonkey();
                monkeysNotDone.AddRange(forest.Monkeylist);
                 while(monkeysNotDone.Count != 0)
                 {
                    List<Monkey> ToRemove = new List<Monkey>();
                     foreach (Monkey m in monkeysNotDone)
                     {
                        if(m.tree != null) 
                        {
                            m.jump(forest);
                            logging.save(forest.image, forest);
                        }
                        else
                        {
                            ToRemove.Add(m);
                        }
                     }
                    monkeysNotDone.RemoveRange(0, ToRemove.Count) ;
                }
            }
        }
    }
}
