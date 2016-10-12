using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolStore.domain
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int ailes { get; set; }
        public int shelf { get; set; }

        public List<Tool> Tools { get; set; }

    }
}
