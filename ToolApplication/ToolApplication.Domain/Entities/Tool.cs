using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolApplication.Domain.Entities
{
    public class Tool
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public ToolType ToolType { get; set; }
        public decimal? BatteryTime { get; set; }
        public decimal? WireLength { get; set; }

        public virtual Inventory Inventory { get; set; }
    }

    public enum ToolType
    {
        Verktyg,
        Strömverktyg,
        Batteriverktyg
    }
}

