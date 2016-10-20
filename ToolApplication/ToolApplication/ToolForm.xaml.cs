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
    /// Interaction logic for ToolForm.xaml
    /// </summary>
    public partial class ToolForm : Window
    {
        ToolService t_service = new ToolService();
        List<Tool> toolList = new List<Tool>();
      
        public ToolForm(Category category)
        {
            InitializeComponent();
            toolList = t_service.Get_SpecificTools(category);
            foreach(var t in toolList)
            {
                toolListView.Items.Add(t);
            }

        }

        private void showBtn_Click(object sender, RoutedEventArgs e)
        {
            Tool item = (Tool)(sender as Button).DataContext;
            ShowForm showForm = new ShowForm(item, t_service);
            showForm.ShowDialog();

        }

    }
}
