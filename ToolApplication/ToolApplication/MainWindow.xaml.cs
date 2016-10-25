using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToolApplication.Domain.Entities;
using ToolApplication.Service;

namespace ToolApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ToolService t_service = new ToolService();
        List<Tool> toolList = new List<Tool>();
        
        public MainWindow()
        {
            InitializeComponent();
            PopulateListview();
            
        }

        private void PopulateListview()
        {
            toolList = t_service.Get_Tools();
            foreach (var t in toolList)
            {
                toolListView.Items.Add(t);
            }
        }

        private void newToolBtn_Click(object sender, RoutedEventArgs e)
        {
            AddToolWindow addTool = new AddToolWindow(t_service, this);
            addTool.ShowDialog(); 
        }

        private void showBtn_Click_1(object sender, RoutedEventArgs e)
        {
            Tool item = (Tool)toolListView.SelectedItem;
            if(item == null){
                MessageBox.Show("Du måste välja ett verktyg i listan som du vill visa.", "ToolApplication", MessageBoxButton.OK);
            }
            else
            {
                ShowForm showForm = new ShowForm(item, t_service);
                showForm.ShowDialog();
            }
        }

        private void deleteBtn_Click_1(object sender, RoutedEventArgs e)
        {
            Tool item = (Tool)toolListView.SelectedItem;
            if(item == null)
            {
                MessageBox.Show("Välj ett verktyg i listan som du vill ta bort.", "ToolApplication", MessageBoxButton.OK);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Är du säker på att du vill radera: " + item.Name + "?", "Tool Application", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        t_service.DeleteTool(item);
                        toolListView.Items.Remove(item);
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        public void FetchTool(Tool _tool)
        {
            toolListView.Items.Add(_tool);
            toolListView.Items.Refresh();
        }
    }
}
