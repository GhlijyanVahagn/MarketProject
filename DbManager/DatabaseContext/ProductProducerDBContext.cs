using DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.DatabaseContext
{
    class ProductProducerDbContext : DataBaseManager
    {
        public virtual DbSet<Producer> Producers { get; set; }

        public ProductProducerDbContext()
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Producer>().HasKey(x => x.Id);
            modelBuilder.Entity<Producer>().Property(x => x.Name).IsRequired().HasMaxLength(100);
        }
        
    }
}
