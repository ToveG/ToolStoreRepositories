using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolApplication.Domain.Entities
{
    public class Inventory
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public int ailes { get; set; }
        public int shelf { get; set; }

        public List<Tool> Tools { get; set; }

    }

    public enum Category
    {
        Borrmaskiner,
        Skruvdagare,
        Hylsnyckelsatser,
        Tänger,
        Skruvmejslar,
        Skiftnyckel,
        Borrsatser,
        Övrigt
    }
}
