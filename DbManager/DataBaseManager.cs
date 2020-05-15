
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
        public virtual DbSet<Gender> Gender { get; set; }



    }


}
