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
        int _shelf;

        public AddToolWindow(ToolService t_service)
        {
            InitializeComponent();
            this.tool_service = t_service;
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
            var ailes = inventoryAisleBox.SelectedItem.ToString();
            var stock = productStockText.Text;
            var bat_Time = toolBattTxt.Text;
            var cord = toolCordTxt.Text;
                                    
             if( toolRadio.IsChecked == true)
            {
                t_type = ToolType.Verktyg;
            }
             else if( batteryRadio.IsChecked == true)
            {
                t_type = ToolType.Batteriverktyg;
            }
             else if(powerRadio.IsChecked == true)
            {
                t_type = ToolType.Strömverktyg;
            }
            int result = val.CheckValue(shelf);
            if(result == 0)
            {
                MessageBox.Show("fel");
            }
            else { _shelf = result; }
                 
            Category category = (Category)categoryComboBox.SelectedItem;
            Inventory _inventory = new Inventory { Category = category, Ailes = ailes, Shelf = _shelf };
            tool_service.AddInventory(_inventory);
            tool_service.AddTool(name, desc, weight, price, t_type, _inventory, stock, bat_Time, cord );

            Close();
        }
    }
}
