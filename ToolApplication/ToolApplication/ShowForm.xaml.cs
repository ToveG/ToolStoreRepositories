using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToolApplication.Domain.Entities;

namespace ToolApplication
{
    /// <summary>
    /// Interaction logic for ShowForm.xaml
    /// </summary>
    public partial class ShowForm : Window
    {
        Tool _tool;
        public ShowForm(Tool tool)
        {
            InitializeComponent();
            _tool = tool;
            
          
            prod_name_txt.Text = _tool.Name;
            prod_dec_txt.Text = _tool.Description;
            prod_price_txt.Text = _tool.Price.ToString();
            prod_battery_txt.Text = _tool.BatteryTime.ToString();
         // prod_shelf_txt.Text = _tool.Inventory.Shelf.ToString();
            prod_stock_txt.Text = _tool.Stock.ToString();
            prod_weight_txt.Text = _tool.Weight.ToString();
            prod_cord_txt.Text = _tool.WireLength.ToString();
            if (_tool.ToolType == ToolType.Verktyg)
            {
                prod_battery_txt.IsReadOnly = true;
                prod_battery_txt.Background = Brushes.Gainsboro;
                prod_cord_txt.IsReadOnly = true;

            }

        }

        
    }
}
