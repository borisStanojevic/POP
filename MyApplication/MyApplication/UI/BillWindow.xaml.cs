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

    public partial class BillWindow : Window
    {
        public static Sale Sale { get; set; }

        public BillWindow()
        {
            InitializeComponent();

            tbId.Text = Sale.Id.ToString();
            tbBuyer.Text = Sale.Buyer;
            tbDateOfSale.Text = Sale.DateOfSale.Date.ToString();

            foreach (var item in Sale.FurnitureForSale)
            {
                tbItemsForSale.Text = tbItemsForSale.Text + "\n" + item.ProductForSale.Name + ", " + item.Pieces + ", " + item.ProductForSale.Price * item.Pieces + "\n";
            }
            foreach (var item in Sale.ServicesForSale)
            {
                tbItemsForSale.Text = tbItemsForSale.Text + "\n" + item.ProductForSale.Name + ", " + item.Pieces + ", " + item.ProductForSale.Price * item.Pieces + "\n";
            }

            tbFullPrice.Text = Sale.FullPrice.ToString();
        }
    }
}
