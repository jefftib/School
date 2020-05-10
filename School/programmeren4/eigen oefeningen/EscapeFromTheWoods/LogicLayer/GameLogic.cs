using System;
using EscapeFromTheWoods;


namespace LogicLayer
{
    public class GameLogic
    {
        ///
        /// <summary>
        /// Deze klasse is verantwoordelijk voor het uitvoeren van elke Game
        /// Hier kunnen methods zoals PlayGame (single) en PlayGame(many) in terecht bvb
        /// </summary>
        /// 

        ///
        /// <todo>
        /// - PlayGames (many)
        /// </todo>
        /// 
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

            for (int i = 0; i < forests; i++)
            {
                Console.WriteLine($"hoe breed is het bos {i+1} ");
                width = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine($"hoe hoog is het bos {i + 1} ");
                height = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine($"hoeveel bomen zijn er in het bos {i + 1}");
                trees = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine($"hoeveel apen zijn er in het bos {i + 1}");
                monkeys = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            }
        }
        
        public static void PlayGame() 
        {
            info();
            for (int i = 0; i < forests; i++)
            {
                Forest forest = Forest.BuildForest(i, width, height, trees, monkeys);
                forest.GenerateTrees();
                forest.PlaceMonkey();
                foreach (Monkey m in forest.Monkeylist)
                {
                    while (m.tree != null)
                    {
                        m.jump(forest);
                    }
                    logging.save(forest.image, forest);
                }
            }
        }

    }
}
