namespace DbManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DbManager.DataBaseManager>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
      
        }

        protected override void Seed(DbManager.DataBaseManager context)
        {
                context.Gender.AddOrUpdate(
                  new DbModel.Gender {Id=1, Name="Mail" },
                  new DbModel.Gender { Id=2,Name = "Femail" }
                );

        }
    }
}
