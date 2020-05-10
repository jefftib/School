using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Mmodel;
using System.Linq;

namespace DataLayer
{
    public class dbFunctions
    {
        public void addForest(ForestLog f)
        {
            using (var context = new MyDBContext())
            {
                context.forestlogs.Add(f);
                context.SaveChanges();
            }
        }
        public void addMonkey(Monkeylog m)
        {
            using (var context = new MyDBContext())
            {
                context.Monkeylogs.Add(m);
                context.SaveChanges();
            }
        }
        public void addTxtLog(txtLog l) 
        {
            using(var context = new MyDBContext()) 
            {
                context.txtLogs.Add(l);
                context.SaveChanges();
            }
        }

        public static int GetForest()
        {
            int lastForest = 0;
            using (var context = new MyDBContext())
            {
                lastForest = context.forestlogs.ToList().Last().ForestId;
            }
            return lastForest;
        }
        public static int GetTree()
        {
            int lastTree = 0;
            using (var context = new MyDBContext())
            {
                lastTree = context.forestlogs.ToList().Last().TreeId;
            }
            return lastTree;
        }

        public static int GetMonkey()
        {
            int lastMonkey = 0;
            using (var context = new MyDBContext())
            {
                lastMonkey = context.txtLogs.Select(x => x.MonkeyId).ToList().Max();
            }
            return lastMonkey;
        }

      

    }
}
