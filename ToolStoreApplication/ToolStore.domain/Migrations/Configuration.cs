namespace ToolStore.domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ToolStore.domain.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ToolStore.domain.DataContext context)
        {
            //context.Inventories.AddOrUpdate(new Inventory
            //{
            //    Category = "",
                 
            //    //    Id = 1,
            //    //    AccountType = AccountType.Checking,
            //    //    Balance = 1000,
            //    //    CustomerId = 1

            //});
            ////context.Accounts.AddOrUpdate(new Account
            //{
            //    Id = 1,
            //    AccountType = AccountType.Checking,
            //    Balance = 1000,
            //    CustomerId = 1
            //});
            //context.Customers.AddOrUpdate(new Customer { Id = 1, UserName = "user", Pin = "1234", AccountId = 1 });

            //context.SaveChanges();

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
