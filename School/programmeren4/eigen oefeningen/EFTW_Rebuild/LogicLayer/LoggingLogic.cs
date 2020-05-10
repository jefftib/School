using System;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using EscapeFromTheWoods;
using DataLayer.Mmodel;
using DataLayer;
namespace LogicLayer
{
  public  class LoggingLogic
    {
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
            Brush b = new SolidBrush(monkey.Colour);
            g.FillEllipse(b, monkey.tree.x * Config.drawingFactor, monkey.tree.y * Config.drawingFactor, Config.drawingFactor, Config.drawingFactor);
        }
        public void DrawPath(Bitmap bm, Tree treeFrom, Tree TreeTo, Monkey monkey)
        {
            Graphics g = Graphics.FromImage(bm);
            Pen p = new Pen(monkey.Colour, 1);
            g.DrawLine(p, treeFrom.x * Config.drawingFactor, treeFrom.y * Config.drawingFactor, TreeTo.x * Config.drawingFactor, TreeTo.y * Config.drawingFactor);
        }
        public void save(Bitmap bm, Forest f)
        {
            bm.Save(Path.Combine(Config.StoragePath + f.Id  + "_escapeRoutes.jpg"), ImageFormat.Jpeg);
        }

        public void LogJumps(Monkey m, Forest f)
        {
            using (StreamWriter sw = new StreamWriter(Config.StoragePath + f.Id + "escapefromthewoods.txt", true))
            {
                if (m.tree != null)
                {
                    Console.WriteLine(m.naam + " jumps to tree " + m.tree.id + " at(" + m.tree.x + "," + m.tree.y + ") bos"  + f.Id);
                    sw.WriteLine(m.naam + " jumps to tree " + m.tree.id + " at(" + m.tree.x + "," + m.tree.y + ")");
                    this.MakeTxtLog(f, m, m.naam + " jumps to tree " + m.tree.id + " at(" + m.tree.x + "," + m.tree.y + ")");

                }
                else {
                    Console.WriteLine(m.naam + " has left the forest" + f.Id);
                    sw.WriteLine(m.naam + " has left the forest");
                    this.MakeTxtLog(f, m, m.naam + " has left the forest");

                }


            }

        }

      public void MakeForestLog(Forest f, Tree t)
        {

            ForestLog flog = new ForestLog(f.Id, t.id, t.x, t.y);
            dbFunctions dbFunctions = new dbFunctions();

           Task.Run(()=>dbFunctions.addForest(flog));
           
        }
    public void MakeMonkeyLog(Forest f, Tree t , Monkey m)
        {
            Monkeylog mlog = new Monkeylog(m.id, m.naam,f.Id, m.CountJumps(), t.id, t.x, t.y);
            dbFunctions dbFunctions = new dbFunctions();
          Task.Run(()=>dbFunctions.addMonkey(mlog));
        }

        public void MakeTxtLog(Forest f, Monkey m, string message)
        {
            txtLog tlog = new txtLog(f.Id, m.id, message);
            dbFunctions dbFunctions = new dbFunctions();
          Task.Run(()=>dbFunctions.addTxtLog(tlog));

        }


    }
}
