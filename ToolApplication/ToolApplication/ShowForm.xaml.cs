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
        Validation val = new Validation();
        int _shelf;
        int _stock;
        decimal _weight;
        decimal _price;
        decimal _cord;
        decimal _battery;
        bool textChanged;
        public ShowForm(Tool tool, ToolService t_service)
        {
            InitializeComponent();
            _tool = tool;
            tService = t_service;


            //toolList = t_service.Get_Tools();
            //foreach (var item in toolList.GroupBy(t => t.ToolType))
            //{
            //    prod_type_cBox.Items.Add(item.Key);
            //}
            //List<Inventory> invList = t_service.GetInventories();

            //foreach (var item in invList.GroupBy(i => i.Category))
            //{
            //    prod_cat_cBox.Items.Add(item.Key);
            //}
            //foreach (var item in invList.GroupBy(i => i.Ailes))
            //{
            //    prod_ailes_cBox.Items.Add(item.Key);
            //}


            //prod_name_txt.Text = _tool.Name;
            //prod_dec_txt.Text = _tool.Description;
            //prod_price_txt.Text = _tool.Price.ToString();
            //prod_battery_txt.Text = _tool.BatteryTime.ToString();
            //prod_shelf_txt.Text = _tool.Inventory.Shelf.ToString();
            //prod_stock_txt.Text = _tool.Stock.ToString();
            //prod_weight_txt.Text = _tool.Weight.ToString();
            //prod_cord_txt.Text = _tool.WireLength.ToString();
            //prod_cat_cBox.SelectedItem = _tool.Inventory.Category;
            //prod_ailes_cBox.SelectedItem = _tool.Inventory.Ailes;
            //prod_type_cBox.SelectedItem = _tool.ToolType;
            //var tooltype = _tool.ToolType.ToString();
            //setVisibility(tooltype);
            loadData();
            textChanged = false;
    }

        private void loadData()
        {
            toolList = tService.Get_Tools();
            foreach (var item in toolList.GroupBy(t => t.ToolType))
            {
                prod_type_cBox.Items.Add(item.Key);
            }
            List<Inventory> invList = tService.GetInventories();

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
            var tooltype = _tool.ToolType.ToString();
            setVisibility(tooltype);

        }



        private void show_simular_tools_btn_Click(object sender, RoutedEventArgs e)
        {
            Category category = (Category)prod_cat_cBox.SelectedItem;
            ToolForm tForm = new ToolForm(category);
            tForm.ShowDialog();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            var _name = prod_name_txt.Text;
            var _desc = prod_dec_txt.Text;
            var price = prod_price_txt.Text;
            var battery = prod_battery_txt.Text;
            var shelf = prod_shelf_txt.Text;
            var stock = prod_stock_txt.Text;
            var weight = prod_weight_txt.Text;
            var cord = prod_cord_txt.Text;
            Category _category = (Category)prod_cat_cBox.SelectedItem;
            var _ailes = prod_ailes_cBox.SelectedItem.ToString();
            ToolType _type = (ToolType)prod_type_cBox.SelectedItem;
            try
            {
                _shelf = val.ValidateInt(shelf);
                _cord = val.ValidateDecimal(cord);
                _weight = val.ValidateDecimal(weight);
                _price = val.ValidateDecimal(price);
                _battery = val.ValidateDecimal(battery);
                _stock = val.ValidateInt(stock);
            }
            catch (Exception)
            {
                MessageBox.Show("Ett fält är felaktigt inmatat");
            }


            if (_type ==  ToolType.Batteriverktyg)
            {
                cord = "0";
            }
            else if(_type == ToolType.Strömverktyg)
            {
                battery = "0";
            }

            tService.Update(_tool, _type, _category, _name, _desc, _weight, _price, _stock, _battery, _cord,  _shelf, _ailes);

            Close();
    }

        public void prod_name_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            textChanged = true;
        }


        private void prod_type_cBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textChanged = true;
            string type = prod_type_cBox.SelectedValue.ToString();
            setVisibility(type);
        }

         private void setVisibility(string typ)
        {
            if(typ == "Verktyg")
            {
                prod_battery_txt.Visibility = Visibility.Hidden;
                battery_label.Visibility = Visibility.Hidden;
                prod_cord_txt.Visibility = Visibility.Hidden;
                cord_label.Visibility = Visibility.Hidden;
            }
            else if(typ == "Strömverktyg")
            {
                prod_cord_txt.Visibility = Visibility.Visible;
                cord_label.Visibility = Visibility.Visible;
                prod_battery_txt.Visibility = Visibility.Hidden;
                battery_label.Visibility = Visibility.Hidden;
            }
            else if(typ == "Batteriverktyg")
            {
                prod_cord_txt.Visibility = Visibility.Hidden;
                cord_label.Visibility = Visibility.Hidden;
                prod_battery_txt.Visibility = Visibility.Visible;
                battery_label.Visibility = Visibility.Visible;

            }
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            if(textChanged == true)
            {
                MessageBox.Show("Du har osparad data.");
            }
            else
            {
                this.Close();
            }
        }

        private void prod_dec_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            textChanged = true;
        }

        private void prod_weight_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            textChanged = true;
        }

        private void prod_cord_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            textChanged = true;
        }

        private void prod_battery_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            textChanged = true;
        }

        private void prod_stock_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            textChanged = true;
        }

        private void prod_price_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            textChanged = true;
        }

        private void prod_shelf_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            textChanged = true;
        }

        private void prod_cat_cBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textChanged = true;
        }

        private void prod_ailes_cBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textChanged = true;
        }
    }
}
