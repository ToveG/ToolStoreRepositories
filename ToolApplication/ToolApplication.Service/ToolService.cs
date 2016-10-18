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
        List<Tool> _toolList = new List<Tool>();

        public ToolService()
        {
            tool_rep = new ToolRepository(dbContext);
        }

        public void AddTool(string name, string description, string weight, string price)
        {
            decimal p;
            decimal w;
            if (decimal.TryParse(weight, out w))
            {
                if (decimal.TryParse(price, out p))
                {
                    Tool _tool = new Tool { Price = p, Description = description, Name = name, Weight = w };
                    tool_rep.AddTool(_tool);

                }
            }
        }

        public List<Tool> Get_Tools()
        {
            _toolList = tool_rep.GetTools();
            return _toolList;
        }



    }
}
