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

        public ToolRepository(DataContext db)
        {
            dbContext = db;
        }

        public List<Tool> toolList = new List<Tool>();

        public void AddTool(Tool tool)
        {
            dbContext.Tools.Add(tool);
            dbContext.SaveChanges();
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
    }
}
