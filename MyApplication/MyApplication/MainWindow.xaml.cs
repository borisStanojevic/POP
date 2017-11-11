using MyApplication.DAO;
using MyApplication.Model;
using MyApplication.UI;
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

namespace MyApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Refresh();

            new LoginWindow().Show();
        }

        private void Refresh()
        {
            //lbUsers.Items.Clear();

            foreach (FurnitureType item in new EntityDAO<FurnitureType>("furniture_types.xml").GetAll())
            {
                lbFurnitureTypes.Items.Add(item);
            }
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Add user");
        }

        private void AddFurnitureType(object sender, RoutedEventArgs e)
        {
            new FurnitureTypeWindow(lbFurnitureTypes.SelectedItem as FurnitureType, FurnitureTypeWindow.Mode.ADD).Show();
        }

        private void AddFurniture(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Add furniture");
        }

        private void AddAdditionalService(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Add as");
        }

        private void AddActionSale(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("add action sale");
        }
    }
}