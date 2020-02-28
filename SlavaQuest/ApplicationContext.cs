using Microsoft.EntityFrameworkCore;
using SlavaQuest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlavaQuest
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Tenant> Tenants { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-KHEAJKL;Database=Cleaner;Trusted_Connection=True;");
        }
    }
}
