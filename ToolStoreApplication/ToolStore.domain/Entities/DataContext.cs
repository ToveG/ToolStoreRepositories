using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ToolStore.domain.Entities;

namespace ToolStore.domain
{
    class DataContext : DbContext
    {
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<ToolType> ToolTypes { get; set; }

        public DataContext() : base("name = Tool")
        {
                
        }
    }


}
