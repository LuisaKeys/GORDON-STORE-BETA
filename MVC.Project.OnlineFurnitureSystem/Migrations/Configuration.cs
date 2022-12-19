namespace MVC.Project.OnlineFurnitureSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC.Project.OnlineFurnitureSystem.Models.Data.Db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVC.Project.OnlineFurnitureSystem.Models.Data.Db";
        }

        protected override void Seed(MVC.Project.OnlineFurnitureSystem.Models.Data.Db context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
