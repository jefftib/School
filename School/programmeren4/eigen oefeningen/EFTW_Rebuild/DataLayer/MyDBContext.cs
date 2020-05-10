
using Microsoft.EntityFrameworkCore;
using DataLayer.Mmodel;
namespace DataLayer
{
    public class MyDBContext : DbContext
    {
        public DbSet<ForestLog> ForestLogs { get; set; }
        public DbSet<Monkeylog> MonkeyLogs { get; set; }
    
        public DbSet<txtLog> TxtLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-HK7G5H0N\SQLEXPRESS; Initial Catalog = EFTW;Integrated Security=True");
        }
    }

}