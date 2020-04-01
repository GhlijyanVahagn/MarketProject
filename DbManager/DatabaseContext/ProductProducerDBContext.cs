using DbModel.Products;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager
{
    public class ProductProducerDbContext : DataBaseManager
    {
        //public virtual DbSet<Producer> Producers { get; set; }

        public ProductProducerDbContext()
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Producer>().HasKey(x => x.Id);
            modelBuilder.Entity<Producer>().Property(x => x.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Producer>().Property(x => x.Country).HasMaxLength(250);
            modelBuilder.Entity<Producer>().Property(x => x.Description).HasMaxLength(250);

        }

    }
}
