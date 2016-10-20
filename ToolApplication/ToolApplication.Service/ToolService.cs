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

        decimal p;
        decimal w;
        decimal c;
        decimal b; 
        int s;

       

        public ToolService()
        {
            tool_rep = new ToolRepository(dbContext);
            inventory_rep = new InventoryRepositiory(dbContext);
        }

        public void Update(Tool tool, ToolType t_Type, Category category, string name, string description, string weight, string price, string stock, string battery, string cord, string shelf, string ailes)
        {
            tool.ToolType = t_Type;
            tool.Name = name;
            tool.Description = description;
            tool.Weight = Decimal.Parse(weight);
            tool.Price = Decimal.Parse(price);
            tool.Stock = Int32.Parse(stock);
            tool.BatteryTime = Decimal.Parse(battery);
            tool.WireLength = Decimal.Parse(cord);
            tool.Inventory.Ailes = ailes;
            tool.Inventory.Shelf = Int32.Parse(shelf);
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

        public void AddTool(string name, string description, string weight, string price, ToolType t_Type, Inventory inventory, string stock, string battery, string cord)
        {
            if (decimal.TryParse(weight, out w))
            {
                if (decimal.TryParse(price, out p))
                {
                    if(int.TryParse(stock, out s))
                    {
                        if (decimal.TryParse(battery, out b))
                        {
                            Tool _tool = new Tool { Price = p, Description = description, Name = name, Weight = w, ToolType = t_Type, Stock = s, Inventory = inventory, BatteryTime = b, WireLength = c };
                            tool_rep.AddTool(_tool);
                        }
                        else if(decimal.TryParse(cord, out c))
                        {
                            Tool _tool = new Tool { Price = p, Description = description, Name = name, Weight = w, ToolType = t_Type, Stock = s, Inventory = inventory, BatteryTime = b, WireLength = c };
                            tool_rep.AddTool(_tool);

                        }
                        else
                        {
                            Tool _tool = new Tool { Price = p, Description = description, Name = name, Weight = w, ToolType = t_Type, Stock = s, Inventory = inventory, BatteryTime = b, WireLength = c };
                            tool_rep.AddTool(_tool);
                        }

                    
                    }
                }
            }
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
