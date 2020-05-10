using System;
using LogicLayer; 

namespace EscapeFromTheWoods
{
    class Program
    {
        /// <summary>
      
        /// </summary>
        static void Main(string[] args)
        {
            GameLogic.PlayGame();
            /*
             * TODO: first tree not logged ?
             * TODO: fix mutliple gameloop parameters
             * TODO:  unieke monkey id
             * TODO: Create multiple games
             * TODO: implement database
             * TODO: save to db
             * TODO: implement async/treading <= hou da maar voor t laatste
            
             * Async gaat ge maar op 4 plaatsen moeten gebruiken in mijn ogen:
             * => Elke game dat er runt kan in een aparte Thread, dus elke game draait async
             * => SaveLogsToDB gaat ook in async, aangezien we niet hoeven te wachten op respons van de DB
             */
        }
    }
}
