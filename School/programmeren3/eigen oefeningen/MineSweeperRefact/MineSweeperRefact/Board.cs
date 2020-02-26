using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperRefact
{
     public class Board
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int Mines { get; set; }

        public Board( int Width, int Height)
        {
            
        }

        public void Generateboard() 
        {
            Board board = new Board(Console.WindowWidth, Console.WindowHeight);
        }
        public int MinePosition()
        {
            //TODO write this
            return;
        }
    }
}
