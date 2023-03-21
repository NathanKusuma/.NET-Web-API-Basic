using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Test.Models
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(_configuration.GetConnectionString("SQLite"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<HeaderTransaction> HeaderTransactions { get; set; }
        public DbSet<DetailTransaction> DetailTransactions { get; set; }
        public DbSet<Item> Items { get; set; }

    }
}