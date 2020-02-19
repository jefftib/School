using System;
using System.Collections.Generic;


namespace MineSweeper
{
    class Program
    {
        #region fields

        const int _mine = -1;
        static readonly  int _height = Console.WindowHeight;
        static readonly int _width = Console.WindowWidth;
        static readonly Random _random = new Random();
        static readonly float _mineRatio = .1f;
        static readonly int _mineCount = (int)(_width * _height * _mineRatio);
        static  (int value, bool visible)[,] _board;
        static  (int Column, int Row) _position = (_width / 2, _height / 2);
        #endregion
        static void Main(string[] args)
        {
            GenerateBoard();
            RenderBoard();
            EventLoop();
        }

        private static void GenerateBoard() 
        {
            _board = new (int value, bool Visible)[_width, _height];

            var coordinates = new List<(int Column, int Row)>(); //lijst om te weten waar een mijn staat.
         
            // coordinate voor iedere cel 
            for (int row = 0; row < _height; row++) 
            {

                for( int column = 0; column <_width; column ++)
                {
                    coordinates.Add((column, row));

                }
            }
            for (int i = 0; i < _mineCount; i++)
            {
                //op deze coordinat word een mijn geplaatst
                int randomIndex = _random.Next(0, coordinates.Count);
                (int column, int Row) = coordinates[randomIndex];
                coordinates.RemoveAt(randomIndex);
                //Mijn plaatsen en visible false cel onzichtbaar bij opstart
                _board[column, Row] = (_mine, false);
            }
            foreach (var tile in adjacentTiles(column, Row))
                if (_board[tile.column, tile.row].value != _mine)
                {
                    _board[tile.column, tile.row].value++;

                    switch (_board[tile.column, tile.row].value)
                    {
                        case -1:
                            Console.WriteLine("@");
                            break;
                        case 0:
                            Console.WriteLine(" ");
                            break;
                        case 1:
                            Console.WriteLine("1");
                            break;
                        case 2:
                            Console.WriteLine("2");
                            break;
                        case 3:
                            Console.WriteLine("3");
                            break;
                        case 4:
                            Console.WriteLine("4");
                            break;
                        case 5:
                            Console.WriteLine("5");
                            break;
                        case 6:
                            Console.WriteLine("6");
                            break;
                        case 7:
                            Console.WriteLine("7");
                            break;
                        case 8:
                            Console.WriteLine("8");
                            break;
                        case 9:
                            Console.WriteLine("9");
                            break;

                    }
                }
        }

        private static void RenderBoard()
        {

        }
        private static void EventLoop()
        {

        }

        private static bool IsConsoleResized()
        {
            if (Console.WindowHeight != _height || Console.WindowWidth == _width)
            {
                Console.Clear();
                /*Quit.(ExitState.Quit, "Console Resized: MineSweeper is closed.");*/
                return true;
            }
            return false;
        }
       
    }
}
