using DbModel;
using DbModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager
{
    public class TransactionDbContext:DataBaseManager
    {
        public TransactionDbContext()
        {

        }

        //public virtual DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Transaction>().HasKey(u => u.Id);
            modelBuilder.Entity<Transaction>().Property(x => x.Type).IsRequired();
            modelBuilder.Entity<Transaction>().Property(x => x.Date).IsRequired();
            modelBuilder.Entity<Transaction>().Property(x => x.UserName).IsRequired();

           
        }
    }
}
