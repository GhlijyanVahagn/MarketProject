
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DbModel;

using System.Data.Entity.Migrations;
using DbModel.Products;

namespace DbManager
{
    public class DataBaseManager : DbContext
    {
        public  DataBaseManager() : base("DefaultConnection")
        {
          
            Database.SetInitializer<DataBaseManager>(new CreateDatabaseIfNotExists<DataBaseManager>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Buy> Buy { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductGroup> ProductGroup { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }


        #region Product
        //public virtual DbSet<Producer> Producers { get; set; }
        //public virtual DbSet<ProductGroup> ProductGroup { get; set; }
        //public virtual DbSet<Unit> Unit { get; set; }
        // public virtual DbSet<Product> Product { get; set; }
        // public virtual DbSet<Buy> Buy { get; set; }
        //public virtual DbSet<Warehouse> Warehouse { get; set; }
        //public virtual DbSet<Transaction> Transaction { get; set; }
        //public virtual DbSet<Sale> Sale { get; set; }

        #endregion



        //public virtual DbSet<IdentityUser> IdentityUser { get;set;}

        //protected virtual  void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    #region ProductGroup

        //    modelBuilder.Entity<ProductGroup>().Property(b => b.Name).IsRequired();
        //    modelBuilder.Entity<ProductGroup>().Property(b => b.Name).HasMaxLength(100);
        //    modelBuilder.Entity<ProductGroup>().HasKey(b => b.Id);

        //    #endregion

        //    #region Unit
        //    modelBuilder.Entity<Unit>().HasKey(u => u.Id);
        //    modelBuilder.Entity<Unit>().Property(x => x.Name).IsRequired();
        //    modelBuilder.Entity<Unit>().Property(x => x.Name).HasMaxLength(100);
        //    #endregion

        //    #region Producer
        //    modelBuilder.Entity<Producer>().HasKey(x => x.Id);
        //    modelBuilder.Entity<Producer>().Property(x => x.Name).IsRequired().HasMaxLength(100);

        //    #endregion

        //    #region Product
        //    modelBuilder.Entity<Product>().HasKey(x => x.Id);
        //    modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired().HasMaxLength(100);
        //    modelBuilder.Entity<Product>().Property(x => x.UnicCode).IsRequired().HasMaxLength(100);

        //    modelBuilder.Entity<Product>()
        //        .HasRequired<Unit>(s => s.Unit)
        //        .WithMany(s => s.Products)
        //        .HasForeignKey(s => s.UnitId);

        //    modelBuilder.Entity<Product>()
        //        .HasRequired<Producer>(s => s.Producer)
        //        .WithMany(s => s.Products)
        //        .HasForeignKey(s => s.ProducerId);

        //    modelBuilder.Entity<Product>()
        //        .HasRequired<ProductGroup>(x => x.ProductGroup)
        //        .WithMany(x => x.Products)
        //        .HasForeignKey(s => s.GroupId);
        //    #endregion

        //    #region Buy
        //    modelBuilder.Entity<Buy>().HasKey(x => x.Id);

        //    modelBuilder.Entity<Buy>()
        //        .HasRequired<Product>(x => x.Product)
        //        .WithMany(x => x.Buy)
        //        .HasForeignKey(x => x.ProductId);


        //    modelBuilder.Entity<Buy>()
        //        .HasRequired<Transaction>(x => x.Transaction)
        //        .WithMany(x => x.Buys)
        //        .HasForeignKey(x => x.TransactionId);

        //    modelBuilder.Entity<Buy>().Property(x => x.Count).IsRequired();
        //    modelBuilder.Entity<Buy>().Property(x => x.Price).IsRequired();
        //    modelBuilder.Entity<Buy>().Property(x => x.ProductId).IsRequired();

        //    modelBuilder.Entity<Buy>().Property(x => x.Payed).IsRequired();

        //    #endregion

        //    #region Warehouse
        //    modelBuilder.Entity<Warehouse>().HasKey(u => u.Id);
        //    modelBuilder.Entity<Warehouse>().Property(x => x.TotalRemind);
        //    modelBuilder.Entity<Warehouse>().Property(x => x.RetailPrice);

        //    modelBuilder.Entity<Warehouse>()
        //   .HasRequired<Product>(s => s.Products)
        //   .WithMany(g => g.Warehouses)
        //   .HasForeignKey<int>(s => s.ProductId);



        //    #endregion

        //    #region Transaction
        //    modelBuilder.Entity<Transaction>().HasKey(u => u.Id);
        //    modelBuilder.Entity<Transaction>().Property(x => x.Type).IsRequired();
        //    modelBuilder.Entity<Transaction>().Property(x => x.Date).IsRequired();
        //    modelBuilder.Entity<Transaction>().Property(x => x.UserName).IsRequired();




        //    #endregion

        //    #region Sale
        //    modelBuilder.Entity<Sale>().HasKey(x => x.Id);

        //    modelBuilder.Entity<Sale>()
        //        .HasRequired<Product>(x => x.Product)
        //        .WithMany(x => x.Sales)
        //        .HasForeignKey(x => x.ProductId);


        //    modelBuilder.Entity<Sale>()
        //        .HasRequired<Transaction>(x => x.Transaction)
        //        .WithMany(x => x.Sales)
        //        .HasForeignKey(x => x.TransactionId);

        //    modelBuilder.Entity<Buy>().Property(x => x.Count).IsRequired();
        //    modelBuilder.Entity<Buy>().Property(x => x.Price).IsRequired();
        //    modelBuilder.Entity<Buy>().Property(x => x.ProductId).IsRequired();


        //    #endregion



    }


}
