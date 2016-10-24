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

        //public void AddTool(string name, string description, string weight, string price, ToolType t_Type, Inventory inventory, string stock, string battery, string cord)
        //{
        //    if (decimal.TryParse(weight, out w))
        //    {
        //        if (decimal.TryParse(price, out p))
        //        {
        //            if (int.TryParse(stock, out s))
        //            {
        //                if (decimal.TryParse(battery, out b))
        //                {
        //                    Tool _tool = new Tool { Price = p, Description = description, Name = name, Weight = w, ToolType = t_Type, Stock = s, Inventory = inventory, BatteryTime = b, WireLength = c };
        //                    tool_rep.AddTool(_tool);
        //                }
        //                else if (decimal.TryParse(cord, out c))
        //                {
        //                    Tool _tool = new Tool { Price = p, Description = description, Name = name, Weight = w, ToolType = t_Type, Stock = s, Inventory = inventory, BatteryTime = b, WireLength = c };
        //                    tool_rep.AddTool(_tool);

        //                }
        //                else
        //                {
        //                    Tool _tool = new Tool { Price = p, Description = description, Name = name, Weight = w, ToolType = t_Type, Stock = s, Inventory = inventory, BatteryTime = b, WireLength = c };
        //                    tool_rep.AddTool(_tool);
        //                }


        //            }
        //        }
        //    }


    }
}
