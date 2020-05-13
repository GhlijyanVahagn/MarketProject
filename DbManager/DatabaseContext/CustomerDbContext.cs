using DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.DatabaseContext
{
    public class CustomerDbContext : DataBaseManager
    {
        public CustomerDbContext()
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().HasKey(x => x.Id);
            modelBuilder.Entity<Customer>().Property(x => x.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Customer>().Property(x => x.Surname).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Customer>().Property(x => x.Gender);
            modelBuilder.Entity<Customer>().Property(x => x.Birthday);
            modelBuilder.Entity<Customer>().Property(x => x.Email);
            modelBuilder.Entity<Customer>().Property(x => x.Address).HasMaxLength(500);
            modelBuilder.Entity<Customer>().Property(x => x.Phone).HasMaxLength(100);
        }
    }
}
