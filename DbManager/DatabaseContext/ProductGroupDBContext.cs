using DbModel.Products;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager
{
    public class ProductGroupDbContext:DataBaseManager
    {
       // public virtual DbSet<ProductGroup> ProductGroup { get; set; }
        public ProductGroupDbContext()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductGroup>().Property(b => b.Name).IsRequired();
            modelBuilder.Entity<ProductGroup>().Property(b => b.Name).HasMaxLength(100);
            modelBuilder.Entity<ProductGroup>().HasKey(b => b.Id);
        }
    }
}
