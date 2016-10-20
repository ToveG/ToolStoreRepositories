using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolApplication
{
    public class Validation
    {
        int _shelf;
      public int CheckValue(string shelf)
        {
            if (int.TryParse(shelf, out _shelf))
                {
                return _shelf;
            }
            return 0;
        }


    }
}
