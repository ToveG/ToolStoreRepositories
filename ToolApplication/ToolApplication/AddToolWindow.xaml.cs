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
using ToolApplication.Service;
using ToolApplication.Domain;
using ToolApplication.Domain.Entities;

namespace ToolApplication
{
    /// <summary>
    /// Interaction logic for AddToolWindow.xaml
    /// </summary>
    public partial class AddToolWindow : Window
    {
        List<Inventory> inventoryList = new List<Inventory>();
        ToolService tool_service;
        ToolType t_type;
        Validation val = new Validation();
        MainWindow mainWindow;
        decimal _weight;
        decimal _battery;
        decimal _cord;
        decimal _price;
        int _stock;
        int _shelf;
       
        public AddToolWindow(ToolService t_service, MainWindow mw)
        {
            InitializeComponent();
            this.tool_service = t_service;
            this.mainWindow = mw;
            inventoryList = tool_service.GetInventories();

            foreach(var item in inventoryList.GroupBy(a => a.Ailes))
            {
                inventoryAisleBox.Items.Add(item.Key);
            }
        }
        
        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            var name = toolNameTxt.Text;
            var price = toolPriceTxt.Text;
            var weight = toolWeightTxt.Text;
            var desc = toolDescTxt.Text;
            var shelf = inventoryShelfTxt.Text;

            if (inventoryAisleBox.SelectedItem == null || categoryComboBox.SelectedItem == null)
            {
                MessageBox.Show("Fyll i all information.");
            }
            else
            {
                var btnResult = CheckRadioBtn();
                if(btnResult != true)
                {
                    MessageBox.Show("Välj en verktygstyp");
                }
                else
                {
                    Category category = (Category)categoryComboBox.SelectedItem;
                    var ailes = inventoryAisleBox.SelectedItem.ToString();
                    var stock = productStockText.Text;
                    var bat_Time = toolBattTxt.Text;
                    var cord = toolCordTxt.Text;

                    if (bat_Time == "")
                    {
                        bat_Time = "0";
                    }
                    if (cord == "")
                    {
                        cord = "0";
                    }

                    try
                    {
                        var _shelf_ = val.ValidateInt(shelf);
                        _shelf = val.isIntNegative(_shelf_);
                        var _stock_ = val.ValidateInt(stock);
                        _stock = val.isIntNegative(_stock_);
                        var _weight_ = val.ValidateDecimal(weight);
                        _weight = val.isDecimalNegative(_weight_);
                        var _battery_ = val.ValidateDecimal(bat_Time);
                        _battery = val.isDecimalNegative(_battery_);
                        var _cord_ = val.ValidateDecimal(cord);
                        _cord = val.isDecimalNegative(_cord_);
                        var _price_ = val.ValidateInt(price);
                       _price = val.isDecimalNegative(_price_);

                        Inventory _inventory = new Inventory { Category = category, Ailes = ailes, Shelf = _shelf };
                        tool_service.AddInventory(_inventory);
                        Tool tool = tool_service.AddTool(name, desc, _weight, _price, t_type, _inventory, _stock, _battery, _cord);
                        
                        mainWindow.FetchTool(tool);
                        Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ett fält är felaktigt inmatat");
                    }
                }
            }
        }
        
        private bool CheckRadioBtn()
        {
            if (toolRadio.IsChecked == true)
            {
                t_type = ToolType.Verktyg;
                return true;
            }
            else if (batteryRadio.IsChecked == true)
            {
                t_type = ToolType.Batteriverktyg;
                return true;
            }
            else if (powerRadio.IsChecked == true)
            {
                t_type = ToolType.Strömverktyg;
                return true;
            }
            bool t_typeResult = val.ValidateToolType(t_type);

            if (t_typeResult != true)
            {
                return false;
            }
            return false;
        }

        private void X_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Du försöker stänga utan att spara. Vill du avsluta?", "Tool Application", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

    
    }
}
