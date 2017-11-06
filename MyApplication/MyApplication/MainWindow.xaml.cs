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
        }

        private void Refresh()
        {
            lbUsers.Items.Clear();

            foreach (var item in new EntityDAO<FurnitureType>("furniture_types.xml").GetAll())
            {
                lbUsers.Items.Add(item);
            }

            lbUsers.SelectedValue = 0;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var furnitureTypeWindow = new FurnitureTypeWindow(null);
          

            furnitureTypeWindow.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var furnitureType = (FurnitureType)lbUsers.SelectedItem;
            var furnitureTypeWindow = new FurnitureTypeWindow(furnitureType);

        }
    }
}
