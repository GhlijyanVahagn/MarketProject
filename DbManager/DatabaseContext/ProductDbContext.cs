using DbModel.Products;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager
{
    class ProductDbContext:DataBaseManager
    {
        public ProductDbContext()
        {

        }
        //public virtual DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(x => x.UnicCode).IsRequired().HasMaxLength(100);
     


            modelBuilder.Entity<Product>()
                .HasRequired<Unit>(s => s.Unit)
                .WithMany(s => s.Products)
                .HasForeignKey(s => s.UnitId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasRequired<Producer>(s => s.Producer)
                .WithMany(s => s.Products)
                .HasForeignKey(s => s.ProducerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasRequired<ProductGroup>(x => x.ProductGroup)
                .WithMany(x => x.Products)
                .HasForeignKey(s => s.GroupId)
                .WillCascadeOnDelete(false);
        }
    }
}
