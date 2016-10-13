using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ToolStore.domain
{
    public class DataContext : DbContext
    {
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        public DataContext() : base("name = Tool")
        {
                
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tool>().Property(t => t.Name).IsRequired();
            modelBuilder.Entity<Tool>().Property(t => t.Price).IsRequired();
            modelBuilder.Entity<Tool>().Property(t => t.Weight).IsRequired();
            modelBuilder.Entity<Tool>().Property(t => t.ToolType).IsRequired();
            modelBuilder.Entity<Tool>().Property(t => t.Description).IsRequired();

            modelBuilder.Entity<Inventory>().Property(i => i.ailes).IsRequired();
            modelBuilder.Entity<Inventory>().Property(i => i.Category).IsRequired();
            modelBuilder.Entity<Inventory>().Property(i => i.shelf).IsRequired();
        }
    }


}
