using System;
using System.Threading.Tasks;
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
            public int forestId { get; set; } = DataLayer.dbFunctions.GetForest();
            public int gamesplayed = 0;
            public  int width;
            public  int height;
            public  int trees;
            public  int monkeys;
            public  int forests;
           
           LoggingLogic logging = new LoggingLogic();
        public void info()
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
        
        public async Task PlayGame() 
        {
            {
                Forest forest = Forest.BuildForest(forestId++, width, height, trees, monkeys);
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
                        }
                        else
                        {
                            ToRemove.Add(m);
                        }
                     }
                   await Task.Run((() => logging.save(forest.image, forest)));
                    monkeysNotDone.RemoveRange(0, ToRemove.Count) ;
                 }
            }
        }
    }
}
