using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ToolApplication.Domain.Entities;

namespace ToolApplication
{
    public class Validation
    {
        decimal _result;
        int result;

      public int ValidateInt(string _int)
        {
            if (int.TryParse(_int, out result))
            {
                    return result;
            }
            else throw new Exception();
        }

        public decimal ValidateDecimal(string _decimal)
        {
            if (decimal.TryParse(_decimal, out _result))
            {
                    return _result;
            }
            else throw new Exception();
        }

        public bool ValidateToolType(ToolType toolType)
        {
            if (toolType != ToolType.Strömverktyg || toolType != ToolType.Batteriverktyg || toolType != ToolType.Verktyg)
            {
                return false;
            }
            else
                return true;
        }

        public int isIntNegative(int number)
        {
            if (number >= 0)
            {
                return number;
            }
            else throw new Exception();
        }

        public decimal isDecimalNegative(decimal number)
        {
            if (number >= 0)
            {
                return number;
            }
            else throw new Exception();
        }
    }
}
