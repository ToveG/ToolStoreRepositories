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
using ToolApplication.Service;

namespace ToolApplication
{
    /// <summary>
    /// Interaction logic for ShowForm.xaml
    /// </summary>
    public partial class ShowForm : Window
    {
        Tool _tool;
        List<Tool> toolList = new List<Tool>();
        ToolService tService;
        public ShowForm(Tool tool, ToolService t_service)
        {
            InitializeComponent();
            _tool = tool;
            tService = t_service;

            toolList = t_service.Get_Tools();
            foreach (var item in toolList.GroupBy(t => t.ToolType))
            {
                prod_type_cBox.Items.Add(item.Key);
            }
            List<Inventory> invList = t_service.GetInventories();

            foreach (var item in invList.GroupBy(i => i.Category))
            {
                prod_cat_cBox.Items.Add(item.Key);
            }
            foreach (var item in invList.GroupBy(i => i.Ailes))
            {
                prod_ailes_cBox.Items.Add(item.Key);
            }

            prod_name_txt.Text = _tool.Name;
            prod_dec_txt.Text = _tool.Description;
            prod_price_txt.Text = _tool.Price.ToString();
            prod_battery_txt.Text = _tool.BatteryTime.ToString();
            prod_shelf_txt.Text = _tool.Inventory.Shelf.ToString();
            prod_stock_txt.Text = _tool.Stock.ToString();
            prod_weight_txt.Text = _tool.Weight.ToString();
            prod_cord_txt.Text = _tool.WireLength.ToString();
            prod_cat_cBox.SelectedItem = _tool.Inventory.Category;
            prod_ailes_cBox.SelectedItem = _tool.Inventory.Ailes;
            prod_type_cBox.SelectedItem = _tool.ToolType;
            if (_tool.ToolType == ToolType.Strömverktyg)
            {
                prod_battery_txt.Visibility = Visibility.Hidden;
                battery_label.Visibility = Visibility.Hidden;
            }
            else if(_tool.ToolType == ToolType.Batteriverktyg)
            {
                prod_cord_txt.Visibility = Visibility.Hidden;
                cord_label.Visibility = Visibility.Hidden;
            }
            else
            {
                prod_battery_txt.Visibility = Visibility.Hidden;
                battery_label.Visibility = Visibility.Hidden;
                prod_cord_txt.Visibility = Visibility.Hidden;
                cord_label.Visibility = Visibility.Hidden;
            }
        }

        private void show_simular_tools_btn_Click(object sender, RoutedEventArgs e)
        {
            Category category = (Category)prod_cat_cBox.SelectedItem;
            ToolForm tForm = new ToolForm(category);
            tForm.ShowDialog();
        }
    }
}
