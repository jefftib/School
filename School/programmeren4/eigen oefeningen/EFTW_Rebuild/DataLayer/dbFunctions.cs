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
                context.ForestLogs.Add(f);
                context.SaveChanges();
            }
        }
        public void addMonkey(Monkeylog m)
        {
            using (var context = new MyDBContext())
            {
                context.MonkeyLogs.Add(m);
                context.SaveChanges();
            }
        }
        public void addTxtLog(txtLog l) 
        {
            using(var context = new MyDBContext()) 
            {
                context.TxtLogs.Add(l);
                context.SaveChanges();
            }
        }

        public static int GetForest()
        {
            int lastForest = 0;
            using (var context = new MyDBContext())
            {
               lastForest = context.ForestLogs.ToList().Last().ForestId;
             
            }
            return lastForest;
        }
        public static int GetTree()
        {
            int lastTree = 0;
            using (var context = new MyDBContext())
            {
                lastTree = context.ForestLogs.ToList().Last().TreeId;
            }
            return lastTree;
        }

        public static int GetMonkey()
        {
            int lastMonkey = 0;
            using (var context = new MyDBContext())
            {
                lastMonkey = context.TxtLogs.Select(x => x.MonkeyId).ToList().Max();
            }
            return lastMonkey;
        }

      

    }
}
