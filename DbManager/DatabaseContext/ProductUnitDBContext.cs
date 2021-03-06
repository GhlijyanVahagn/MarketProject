﻿using DbModel.Products;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager
{
    public  class ProductUnitDbContext: DataBaseManager
    {
      
        //public virtual DbSet<Unit> Unit { get; set; }
        public ProductUnitDbContext():base()
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Unit>().HasKey(u => u.Id);
            modelBuilder.Entity<Unit>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Unit>().Property(x => x.Name).HasMaxLength(100);
    


        }

    }
}
