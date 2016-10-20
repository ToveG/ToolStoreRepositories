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
            toolList = t_service.Get_Tools();
            foreach(var t in toolList)
            {
                toolListView.Items.Add(t);
            }
        }


        private void newToolBtn_Click(object sender, RoutedEventArgs e)
        {
            AddToolWindow addTool = new AddToolWindow(t_service);
            addTool.ShowDialog(); 
        }

        //private void showBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    Tool item = (Tool)(sender as Button).DataContext;
        //    ShowForm showForm = new ShowForm(item, t_service);
        //    showForm.ShowDialog();
        //}

        //private void deleteBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    Tool item = (Tool)(sender as Button).DataContext;
        //    t_service.DeleteTool(item);
        //}

        private void showBtn_Click_1(object sender, RoutedEventArgs e)
        {
            Tool item = (Tool)toolListView.SelectedItem;
            ShowForm showForm = new ShowForm(item, t_service);
            showForm.ShowDialog();
        }

        private void deleteBtn_Click_1(object sender, RoutedEventArgs e)
        {
         //MessageBoxResult result = MessageBox.Show("Would you like to greet the world with a \"H//ello, world\"?", "My App", MessageBoxButton.YesNoCancel);
            //  MessageBox.Show("Är du säker på att du vill radera produkten?", "Question",
            //   MessageBoxButton.YesNo, MessageBoxImage.Warning);
            //    Tool item = (Tool)toolListView.SelectedItem;
            //    t_service.DeleteTool(item);
        }
    }
}
