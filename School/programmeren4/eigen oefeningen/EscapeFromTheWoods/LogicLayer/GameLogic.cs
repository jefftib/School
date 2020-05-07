using System;
using EscapeFromTheWoods;
using System.Collections.Generic;


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
        /// - PlayGame (single)
        /// </todo>
        /// 
        /// Potentiele game structuur:
        /// PlayGame(){
        ///     BuildForest(params=> treeAmount, monkeyAmount)
        ///     GenerateTrees(params=> treeAmount)
        ///     GenerateMonkeys(params=> monkeyAmount)
        ///     foreach (Monkey m in Forest.Trees)
        ///          while (m.Tree != null)
        ///             m.Jump();
        ///     LOG.SaveTextLogs()
        ///     LOG.SaveBitmapImage()
        /// }
        /// 

            public static int width;
            public static int height;
            public static int trees;
            public static int monkeys; 
        public static  void info() 
        {
            Console.WriteLine("hoe breed is het bos");
         width = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("hoe hoog is het bos");
            height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("hoeveel bomen zijn er in het bos");
            trees = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("hoeveel apen zijn er in het bos");
            monkeys = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

        }
        
        public static void PlayGame() 
        {
            info();
            Forest forest = Forest.BuildForest(width, height, trees, monkeys);
            forest.GenerateTrees();
            forest.PlaceMonkey();
            foreach (Monkey m in forest.Monkeylist) 
            {
                while(m.tree != null)
                {
                    m.jump(forest);
                }
            }
        }

    }
}
