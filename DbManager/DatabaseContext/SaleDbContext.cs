using DbModel;
using DbModel.Products;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.DatabaseContext
{
    public class SaleDbContext:DataBaseManager
    {
        public SaleDbContext()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>().HasKey(x => x.Id);

            modelBuilder.Entity<Sale>()
                .HasRequired<Product>(x => x.Product)
                .WithMany(x => x.Sales)
                .HasForeignKey(x => x.ProductId);


            modelBuilder.Entity<Sale>()
                .HasRequired<Transaction>(x => x.Transaction)
                .WithMany(x => x.Sales)
                .HasForeignKey(x => x.TransactionId);

            modelBuilder.Entity<Sale>().Property(x => x.Count).IsRequired();
            modelBuilder.Entity<Sale>().Property(x => x.Price).IsRequired();
            modelBuilder.Entity<Sale>().Property(x => x.ProductId).IsRequired();
        }
    }
}
