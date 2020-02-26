using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MineSweeper
{
    class Program
    {
        #region fields

        const int _mine = -1;
        static bool _dead = false;
        static readonly  int _height = Console.WindowHeight;
        static readonly int _width = Console.WindowWidth;
        static readonly Random _random = new Random();
        static readonly float _mineRatio = .1f;
        static readonly int _mineCount = (int)(_width * _height * _mineRatio);
      

        static (int value, bool visible)[,] _board;
        static  (int Column, int Row) _position = (_width / 2, _height / 2);
        #endregion
        static void Main(string[] args)
        {
            GenerateBoard();
             RenderBoard();
                EventLoop();
            }
        private static IEnumerable<(int Column, int Row )> AdjacentTiles(int column, int row)
        {
            var AdjacentTiles = new List<(int Column, int Row)>();
            for (int c = column -1 ; c <= column + 1; c++)
            {
                for (int r = row -1; r <= row +1 ; r++)
                {
                    if((r >= 0 && c >= 0 )  && (r < _height && c < _width ) ) 
                    {
                        if(r != row || c != column)
                        {
                            AdjacentTiles.Add((c, r));
                        }
                    }
                }
            }
            return AdjacentTiles;
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
                (int column, int row) = coordinates[randomIndex];
                coordinates.RemoveAt(randomIndex);
                //Mijn plaatsen en visible false cel onzichtbaar bij opstart
                _board[column, row] = (_mine, false);

                foreach (var tile in AdjacentTiles(column, row))
                {
                    if (_board[tile.Column, tile.Row].value != _mine)
                    {
                        _board[tile.Column, tile.Row].value++;

                    }

                }
            }
        }

        public static string ShowStringAsIntended(int value, bool visible)
        {
            if (!visible) return "█" ;
            switch (value)
            {
                case -1:
                    return "@";

                case 0:
                    return " ";

                default:
                    return ""+ value;

            }
        }

        private static void RenderBoard()
        {
                // te gebruiken functies

                           StringBuilder stringBuilder = new StringBuilder(_width * _height);
            for (int row = 0; row < _height; row++)
            {

                for (int column = 0; column < _width; column++)
                {


                    stringBuilder.Append(ShowStringAsIntended(_board[column, row].value, _board[column, row].visible));

                }
            }
             Console.Write(stringBuilder.ToString());
                


        }
        private static void EventLoop()
        {
            /*   Console.SetCursorPosition(int left, int top);
               • Console.ReadKey(true).Key
               • ConsoleKey.UpArrow
               • ConsoleKey.DownArrow
               • ConsoleKey.LeftArrow
               • ConsoleKey.RightArrow
               • ConsoleKey.Enter
               • ConsoleKey.Escape*/

            Console.SetCursorPosition(_position.Column, _position.Row);
            var key = Console.ReadKey(true).Key;
            while(key != ConsoleKey.Escape && IsConsoleResized() == false && _dead == false)
            {
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        if(_position.Column > 0)
                        _position.Column--;
                        Console.SetCursorPosition(_position.Column, _position.Row);
                        break;
                    case ConsoleKey.RightArrow:
                        if (_position.Column < _width -1)
                            _position.Column++;
                        Console.SetCursorPosition(_position.Column, _position.Row);
                        break;
                    case ConsoleKey.UpArrow:
                        if (_position.Row > 0)
                            _position.Row--;
                        Console.SetCursorPosition(_position.Column, _position.Row);
                        break;
                    case ConsoleKey.DownArrow:
                        if (_position.Row < _height - 1)
                            _position.Row++;
                        Console.SetCursorPosition(_position.Column, _position.Row);
                        break;
                    case ConsoleKey.Enter:
                        Reveal(_position.Column, _position.Row);
                        if(_board[_position.Column, _position.Row].value == -1)
                        {
                            _dead = true;
                        }
                        Console.Clear();
                        RenderBoard();
                        Console.SetCursorPosition(_position.Column, _position.Row);
                        break;
                    default:
                        break;
                }
                key = Console.ReadKey(true).Key;
                 
            }
            Console.Clear();

        }

        private static bool IsConsoleResized()
        {
            if (Console.WindowHeight != _height || Console.WindowWidth != _width)
            {
                Console.Clear();
                /*Quit.(ExitState.Quit, "Console Resized: MineSweeper is closed.");*/
                return true;
            }
            return false;
        }

        private static void Reveal(int column , int row)
        {
              if(_board[column, row].visible == false)
            {
                _board[column, row].visible = true;
                if (_board[column, row].value == 0) //stopcondition
                {
                    foreach(var tile in AdjacentTiles(column, row))
                    {
                        Reveal(tile.Column, tile.Row);
                    }
                }
               
            }
           
        }
       
    }
}
