using System;
using LogicLayer; 

namespace EscapeFromTheWoods
{
    class Program
    {
        /// <summary>
        /// Dit project hou je voor alles van UI te doen
        /// Best in een gescheiden project om de code in lagen te houden
        /// Om een project toe te voegen aan een solution en te laten werken met code:
        /// Rechts klik op Dependencies in project A > Add Reference... > vink Project B aan
        /// </summary>
        static void Main(string[] args)
        {
            GameLogic.PlayGame();
            /*
             * TODO: implement bitmap <= is een piece of cake
             * TODO: implement database
             * TODO: save to db
             * TODO: implement async/treading <= hou da maar voor t laatste
             * 
             * Async gaat ge maar op 4 plaatsen moeten gebruiken in mijn ogen:
             * => Elke game dat er runt kan in een aparte Thread, dus elke game draait async
             * => SaveLogsToDB gaat ook in async, aangezien we niet hoeven te wachten op respons van de DB
             */
        }
    }
}
