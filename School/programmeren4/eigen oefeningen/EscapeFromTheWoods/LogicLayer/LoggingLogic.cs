using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace LogicLayer
{
    class LoggingLogic
    {
        ///
        /// <summary>
        /// Deze klasse is verantwoordelijk voor alles te loggen
        /// TextLogs, SaveBitmap, ActionLogToDB, WoodsLogToDB, MonkeyLogToDB, etc...
        /// </summary>
        /// 

        public void Rapport()
        {
            using (StreamWriter sw = new StreamWriter(Config.StoragePath + "escapefromthewoods.txt"))
            {

                

            }

        }

        ///
        /// <todo>
        /// - methode(s) voor:
        ///     - TextLogs (.txt)
        ///     - Create bitmap image
        ///     - Save action logs to db => wordt async
        ///     - Save woods logs to db => wordt async
        ///     - Save monkey logs to db => wordt async
        /// </todo>
        /// 
        /// Voor de DAl (data access layer) zou ik persoonlijk ook een extra project gebruiken, maar das u eigen keuze
        /// Kies voor een zo simpel mogelijke DB connectie, want uiteindelijk gaat ge gwn schrijven naar de DB en af en toe nekeer leze om de laatste ID te krijgen voor Forest en Monkey
        /// 





    }
}
