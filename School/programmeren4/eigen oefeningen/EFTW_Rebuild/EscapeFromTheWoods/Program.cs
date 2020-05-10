using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using LogicLayer;

namespace EscapeFromTheWoods
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<Task> TaskList = new List<Task>();
            GameLogic glogic = new GameLogic();
            glogic.info();
             while(glogic.gamesplayed != glogic.forests)
             {
                 glogic.PlayGame();
                TaskList.Add(glogic.PlayGame());
                glogic.gamesplayed++;
             }
            await Task.WhenAll(TaskList);
        }
    }
}
