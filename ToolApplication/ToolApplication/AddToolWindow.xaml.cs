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

namespace ToolApplication
{
    /// <summary>
    /// Interaction logic for AddToolWindow.xaml
    /// </summary>
    public partial class AddToolWindow : Window
    {

        ToolService tool_service;

        public AddToolWindow(ToolService t_service)
        {
            InitializeComponent();
            this.tool_service = t_service;
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            var name = toolNameTxt.Text;
            var price = toolPriceTxt.Text;
            var weight = toolWeightTxt.Text;
            var desc = toolDescTxt.Text;

            tool_service.AddTool(name, desc, weight, price);
        }
    }
}
