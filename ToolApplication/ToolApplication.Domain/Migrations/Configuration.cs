namespace ToolApplication.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ToolApplication.Domain.Entities.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ToolApplication.Domain.Entities.DataContext context)
        {
            context.Inventories.AddOrUpdate(new Entities.Inventory{Category = Entities.Category.Borrmaskiner, Ailes = "A", Shelf = 1 });
            context.Inventories.AddOrUpdate(new Entities.Inventory { Category = Entities.Category.Borrmaskiner, Ailes = "A", Shelf = 2 });
            context.Inventories.AddOrUpdate(new Entities.Inventory { Category = Entities.Category.Borrsatser, Ailes = "B", Shelf = 1 });
            context.Inventories.AddOrUpdate(new Entities.Inventory { Category = Entities.Category.Hylsnyckelsatser, Ailes = "B", Shelf = 3 });
            context.Inventories.AddOrUpdate(new Entities.Inventory { Category = Entities.Category.Skiftnyckel, Ailes = "B", Shelf = 4 });
            context.Inventories.AddOrUpdate(new Entities.Inventory { Category = Entities.Category.Skruvdagare, Ailes = "C", Shelf = 1 });
            context.Inventories.AddOrUpdate(new Entities.Inventory { Category = Entities.Category.Skruvmejslar, Ailes = "C", Shelf = 2 });
            context.Inventories.AddOrUpdate(new Entities.Inventory { Category = Entities.Category.Tänger, Ailes = "B", Shelf = 5 });
            context.Inventories.AddOrUpdate(new Entities.Inventory { Category = Entities.Category.Övrigt, Ailes = "D", Shelf = 1 });


            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
