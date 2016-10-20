using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolApplication.Domain.Entities;

namespace ToolApplication.Domain.Repositories
{
    public class InventoryRepositiory
    {
        public readonly DataContext dbContext;
        public List<Inventory> inventoryList = new List<Inventory>();

        public InventoryRepositiory(DataContext db)
        {
            dbContext = db;
        }

        public List<Inventory> Get_Inventory()
        {
            var inventory = from i in dbContext.Inventories
                             select i;
            foreach (var item in inventory)
            {
                inventoryList.Add(item);
            }
            return inventoryList;
        }

        public void AddInventory(Inventory inventory)
        {
            dbContext.Inventories.Add(inventory);
            dbContext.SaveChanges();
        }

    }
}
