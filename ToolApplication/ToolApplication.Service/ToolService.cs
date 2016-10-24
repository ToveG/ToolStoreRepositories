using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolApplication.Domain.Entities;
using ToolApplication.Domain.Repositories;

namespace ToolApplication.Service
{
    public class ToolService
    {
        DataContext dbContext = new DataContext();
        private ToolRepository tool_rep;
        private InventoryRepositiory inventory_rep;
        List<Tool> _toolList = new List<Tool>();
        List<Inventory> _inventoryList = new List<Inventory>();

       

        public ToolService()
        {
            tool_rep = new ToolRepository(dbContext);
            inventory_rep = new InventoryRepositiory(dbContext);
        }

        public void Update(Tool tool, ToolType t_Type, Category category, string name, string description, decimal weight, decimal price, int stock, decimal battery, decimal cord, int shelf, string ailes)
        {
            tool.ToolType = t_Type;
            tool.Name = name;
            tool.Description = description;
            tool.Weight = weight;
            tool.Price = price;
            tool.Stock = stock;
            tool.BatteryTime = battery;
            tool.WireLength = cord;
            tool.Inventory.Ailes = ailes;
            tool.Inventory.Shelf = shelf;
            tool.Inventory.Category = category;
            tool_rep.UpdateTool();
        }

        public List<Tool> Get_SpecificTools(Category category)
        {
            _toolList = tool_rep.Get_SpecificTools(category);
            return _toolList;
        }

        public void UpdateTool()
        {

        }

        public Tool AddTool(string name, string description, decimal weight, decimal price, ToolType t_Type, Inventory inventory, int stock, decimal battery, decimal cord)
        {
            Tool _tool = new Tool { Price = price, Description = description, Name = name, Weight = weight, ToolType = t_Type, Stock = stock, Inventory = inventory, BatteryTime = battery, WireLength = cord };
            tool_rep.AddTool(_tool);
            return _tool;
        }

        public void AddInventory(Inventory inventory)
        {
            inventory_rep.AddInventory(inventory);
        }

        public List<Inventory> GetInventories()
        {
            _inventoryList = inventory_rep.Get_Inventory();
            return _inventoryList;
        }

        public List<Tool> Get_Tools()
        {
            _toolList = tool_rep.GetTools();
            return _toolList;
        }

        public void DeleteTool(Tool tool)
        {
            tool_rep.DeleteTool(tool);
        }

    }
}
