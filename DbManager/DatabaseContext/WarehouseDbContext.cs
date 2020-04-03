using DbModel.Products;
using DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DbManager
{
    public class WarehouseDbContext:DataBaseManager
    {
        
        public WarehouseDbContext()
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Warehouse>().HasKey(u => u.Id);
            modelBuilder.Entity<Warehouse>().Property(x => x.TotalRemind);
            modelBuilder.Entity<Warehouse>().Property(x => x.RetailPrice);
            modelBuilder.Entity<Warehouse>().Property(x => x.Price).IsRequired();
            modelBuilder.Entity<Warehouse>().Property(x => x.WholeSalePrice);



            modelBuilder.Entity<Warehouse>()
           .HasRequired<Product>(s => s.Products)
           .WithMany(g => g.Warehouses)
           .HasForeignKey<int>(s => s.ProductId);
           

        }
    }
}
