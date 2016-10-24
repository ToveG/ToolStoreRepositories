using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolApplication.Domain.Entities
{
    public class Tool
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
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

