using DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.DatabaseContext
{
    class BuyDbContext:DataBaseManager
    {
        public BuyDbContext()
        {

        }
        public virtual DbSet<Buy> Buy { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Buy>().HasKey(x => x.Id);

            modelBuilder.Entity<Buy>()
                .HasRequired<Product>(x => x.Product)
                .WithMany(x => x.Buy)
                .HasForeignKey(x => x.ProductId);


            modelBuilder.Entity<Buy>()
                .HasRequired<Transaction>(x => x.Transaction)
                .WithMany(x => x.Buys)
                .HasForeignKey(x => x.TransactionId);

            modelBuilder.Entity<Buy>().Property(x => x.Count).IsRequired();
            modelBuilder.Entity<Buy>().Property(x => x.Price).IsRequired();
            modelBuilder.Entity<Buy>().Property(x => x.ProductId).IsRequired();

            modelBuilder.Entity<Buy>().Property(x => x.Payed).IsRequired();
        }


    }
}
