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

    public partial class AllSalesWindow : Window
    {
        public AllSalesWindow()
        {
            InitializeComponent();

            dgAllSales.ItemsSource = SalesmanWindow.salesList;
            dgAllSales.IsSynchronizedWithCurrentItem = true;
            dgAllSales.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void dgAllSales_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Deleted")
                e.Cancel = true;
            if ((string)e.Column.Header == "Id")
                e.Cancel = true;
        }
    }
}
