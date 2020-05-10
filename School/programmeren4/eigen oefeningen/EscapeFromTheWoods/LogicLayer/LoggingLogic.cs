using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using EscapeFromTheWoods;
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

        public  Bitmap CreateImage(Forest f) 
        {

            Bitmap bm = new Bitmap((f.maxWidth) *Config.drawingFactor , (f.maxHeight) *Config.drawingFactor);
            Graphics g = Graphics.FromImage(bm);
            Pen p = new Pen(Color.Green, 1);
            foreach (Tree tree in f.treelist)
            {
                g.DrawEllipse(p, tree.x * Config.drawingFactor, tree.y * Config.drawingFactor, Config.drawingFactor, Config.drawingFactor);
            }
           
                return bm;
        }
        public void DrawMonkey(Bitmap bm,Monkey monkey)
        {
            Graphics g = Graphics.FromImage(bm);
            Brush b = new SolidBrush(Color.Yellow);
            g.FillEllipse(b, monkey.tree.x * Config.drawingFactor, monkey.tree.y * Config.drawingFactor, Config.drawingFactor, Config.drawingFactor);
        }
        public void DrawPath(Bitmap bm, Tree treeFrom, Tree TreeTo)
        {
            Graphics g = Graphics.FromImage(bm);
            Pen p = new Pen(Color.White, 1);
            g.DrawLine(p, treeFrom.x * Config.drawingFactor, treeFrom.y * Config.drawingFactor, TreeTo.x * Config.drawingFactor, TreeTo.y * Config.drawingFactor);
        }
        public void save(Bitmap bm, Forest f)
        {
            bm.Save(Path.Combine(Config.StoragePath + f.Id  + "_escapeRoutes.jpg"), ImageFormat.Jpeg);
        }

        public void TextLogs(Monkey m, Forest f)
        {
            using (StreamWriter sw = new StreamWriter(Config.StoragePath + f.Id + "escapefromthewoods.txt", true))
            {
                if (m.tree != null)
                {
                    sw.WriteLine(m.naam + " jumps to boom " + m.tree.id + " at(" + m.tree.x + "," + m.tree.y + ")");

                }
                else {
                    sw.WriteLine(m.naam + " has left the forest");
                }
               

            }

        }

        ///
        /// <todo>
        /// - methode(s) voor:
        ///     - Save action logs to db => wordt async
        ///     - Save woods logs to db => wordt async
        ///     - Save monkey logs to db => wordt async
        /// </todo>
        /// 
      





    }
}
