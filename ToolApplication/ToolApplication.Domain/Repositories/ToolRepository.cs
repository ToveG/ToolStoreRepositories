using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolApplication.Domain.Entities;


namespace ToolApplication.Domain.Repositories
{
    public class ToolRepository
    {
        public readonly DataContext dbContext;
        public List<Tool> toolList = new List<Tool>();

        public ToolRepository(DataContext db)
        {
            dbContext = db;
        }

        public List<Tool> Get_SpecificTools(Category category)
        {
                List<Tool> tools = dbContext.Tools.Where(c => c.Inventory.Category == category).ToList();
                return tools;
        }

        public List<Tool> GetTools()
        {
            var tool = from t in dbContext.Tools
                       select t;
            foreach (var item in tool)
            {
                toolList.Add(item);
            }
            return toolList;
        }

        public void DeleteTool(Tool tool)
        {
            try{
                dbContext.Tools.Remove(tool);
                dbContext.SaveChanges();
            }
            catch(Exception)
            {
            }
          }

        public void UpdateTool()
        {
            dbContext.SaveChanges();
        }

        public void AddTool(Tool tool)
        {
            try
            {
                dbContext.Tools.Add(tool);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
   }
}
