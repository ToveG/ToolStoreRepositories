using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolStore.domain.Entities
{
    public class ToolType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Tool> Tools { get; set; }
    }
}
