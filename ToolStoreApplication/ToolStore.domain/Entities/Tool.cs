using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolStore.domain.Entities;

namespace ToolStore.domain
{
    public class Tool
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int? BatteryTime { get; set; }
        public int? WireLength { get; set; }


        public virtual Inventory Inventory { get; set; }
        public virtual ToolType ToolType{ get; set; }

    }
}
