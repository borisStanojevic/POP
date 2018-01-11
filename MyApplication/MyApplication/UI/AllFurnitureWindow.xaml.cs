using MyApplication.Model;
using MyApplication.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MyApplication.UI
{

    public partial class AllFurnitureWindow : Window
    {

        public AllFurnitureWindow()
        {
            InitializeComponent();

            dgAllFurniture.ItemsSource = Singleton.Instance.Furniture;
            dgAllFurniture.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Furniture furniture = (Furniture)dgAllFurniture.SelectedItem;
            int pieces = int.Parse(tbPieces.Text.Trim());

            SaleItem<Furniture> furnitureSaleItem = new SaleItem<Furniture>
            {
                ProductForSale = furniture,
                Pieces = pieces
            };

            SalesmanWindow.furnitureForSale.Add(furnitureSaleItem);

            Close();
        }

        private void dgAllFurniture_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Deleted")
                e.Cancel = true;
            if ((string)e.Column.Header == "Id")
                e.Cancel = true;
            if ((string)e.Column.Header == "Quantity")
                e.Cancel = true;
        }

        private void tbPieces_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputValidator.ValidateInteger(tbPieces.Text.Trim()) == false)
            {
                tbPieces.BorderBrush = new SolidColorBrush(Colors.Red);
                tbPieces.BorderThickness = new Thickness(2);
            }
            else
            {
                tbPieces.BorderBrush = new SolidColorBrush(Colors.Blue);
                tbPieces.BorderThickness = new Thickness(1);
            }
        }
    }
}
