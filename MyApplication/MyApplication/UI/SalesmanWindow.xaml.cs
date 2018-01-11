using MyApplication.DAO;
using MyApplication.Model;
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
    /// <summary>
    /// Interaction logic for SalesmanWindow.xaml
    /// </summary>
    public partial class SalesmanWindow : Window
    {
        public static ObservableCollection<Sale> salesList;
        public static ObservableCollection<SaleItem<Furniture>> furnitureForSale = new ObservableCollection<SaleItem<Furniture>>();
        public static ObservableCollection<SaleItem<AdditionalService>> servicesForSale = new ObservableCollection<SaleItem<AdditionalService>>();

        public SalesmanWindow()
        {

            InitializeComponent();

            salesList = Singleton.Instance.Sales;

            dgFurnitureForSale.ItemsSource = furnitureForSale;
            dgFurnitureForSale.IsSynchronizedWithCurrentItem = true;
            dgFurnitureForSale.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgServicesForSale.ItemsSource = servicesForSale;
            dgServicesForSale.IsSynchronizedWithCurrentItem = true;
            dgServicesForSale.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

        }

        private void btnRemoveFurnitureFromSale_Click(object sender, RoutedEventArgs e)
        {
            SaleItem<Furniture> furniture = (SaleItem<Furniture>)dgFurnitureForSale.SelectedItem;
            furnitureForSale.Remove(furniture);
        }

        private void btnRemoveServiceFromSale_Click(object sender, RoutedEventArgs e)
        {
            SaleItem<AdditionalService> additionalService = (SaleItem<AdditionalService>)dgServicesForSale.SelectedItem;
            servicesForSale.Remove(additionalService);
        }

        private void btnAddFurnitureToSale_Click(object sender, RoutedEventArgs e)
        {
            new AllFurnitureWindow().ShowDialog();
        }

        private void btnAddServiceToSale_Click(object sender, RoutedEventArgs e)
        {
            new AllAdditionalServicesWindow().ShowDialog();
        }

        //private void btnSaveSale_Click(object sender, RoutedEventArgs e)
        //{
        //    Sale sale = new Sale();
        //    foreach (var item in furnitureForSale)
        //    {
        //        sale.FurnitureForSale.Add(item);
        //    }
        //    foreach (var item in servicesForSale)
        //    {
        //        sale.ServicesForSale.Add(item);
        //    }
        //    sale.Id = new Random().Next();
        //    sale.DateOfSale = dpDateOfSale.SelectedDate.Value.Date;
        //    sale.Buyer = tbBuyer.Text.Trim();

        //    salesList.Add(sale);
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AllSalesWindow().ShowDialog();
        }

        private void dgFurnitureForSale_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Deleted")
                e.Cancel = true;
            if ((string)e.Column.Header == "Id")
                e.Cancel = true;
        }

        private void dgServicesForSale_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Deleted")
                e.Cancel = true;
            if ((string)e.Column.Header == "Id")
                e.Cancel = true;
        }
    }
}
