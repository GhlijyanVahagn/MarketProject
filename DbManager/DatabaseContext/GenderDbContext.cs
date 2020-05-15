using DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.DatabaseContext
{
    public class GenderDbContext:DataBaseManager
    {
        public GenderDbContext()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Gender>().HasKey(x => x.Id);
            modelBuilder.Entity<Gender>().Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}
