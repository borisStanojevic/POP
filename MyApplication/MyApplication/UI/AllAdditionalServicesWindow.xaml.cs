using MyApplication.Model;
using MyApplication.Util;
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

namespace MyApplication.UI
{
    /// <summary>
    /// Interaction logic for AllAdditionalServicesWindow.xaml
    /// </summary>
    public partial class AllAdditionalServicesWindow : Window
    {
        public AllAdditionalServicesWindow()
        {
            InitializeComponent();

            dgAllAdditionalServices.ItemsSource = Singleton.Instance.AdditionalServices;
            dgAllAdditionalServices.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdditionalService additionalService = (AdditionalService)dgAllAdditionalServices.SelectedItem;
            int pieces = int.Parse(tbPieces.Text.Trim());

            SaleItem<AdditionalService> asSaleItem = new SaleItem<AdditionalService>()
            {
                ProductForSale = additionalService,
                Pieces = pieces
            };

            SalesmanWindow.servicesForSale.Add(asSaleItem);

            Close();
        }

        private void dgAllAdditionalServices_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
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
