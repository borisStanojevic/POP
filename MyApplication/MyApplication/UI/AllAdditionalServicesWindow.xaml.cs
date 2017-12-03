using MyApplication.Model;
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
            SalesmanWindow.servicesForSale.Add(additionalService);
            this.Close();
        }

        private void dgAllAdditionalServices_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Deleted")
                e.Cancel = true;
            if ((string)e.Column.Header == "Id")
                e.Cancel = true;
        }
    }
}
