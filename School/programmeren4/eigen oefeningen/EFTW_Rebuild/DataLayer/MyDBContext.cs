using Microsoft.Data.SqlClient;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using DataLayer.Mmodel;
namespace DataLayer
{
    public class MyDBContext : DbContext
    {
        public DbSet<ForestLog> forestlogs { get; set; }
        public DbSet<Monkeylog> Monkeylogs { get; set; }
        public DbSet<txtLog> txtLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-HK7G5H0N\SQLEXPRESS; Initial Catalog = EFTW;Integrated Security=True");
        }
    }

}