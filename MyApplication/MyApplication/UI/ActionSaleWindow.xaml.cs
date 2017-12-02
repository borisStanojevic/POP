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
    public partial class ActionSaleWindow : Window
    {
        private ActionSale actionSale;
        public enum Mode
        {
            ADD,
            EDIT
        }
        private Mode mode;

        public ActionSaleWindow(ActionSale actionSale, Mode mode = Mode.ADD)
        {
            InitializeComponent();
            this.actionSale = actionSale;
            this.mode = mode;

            if(mode == Mode.EDIT)
            {
                tbName.DataContext = actionSale;
                tbDiscount.DataContext = actionSale;
                dpStartDate.DataContext = actionSale;
                dpEndDate.DataContext = actionSale;
                btnAddEditActionSale.Content = "Edit";
            }
        }

        private void btnAddEditActionSale_Click(object sender, RoutedEventArgs e)
        {
            if (this.mode == Mode.ADD)
            {
                int lastElementIndex = MainWindow.actionSalesList.Count - 1;
                int lastElementId = MainWindow.actionSalesList.ElementAt(lastElementIndex).Id;

                MainWindow.actionSalesList.Add(new ActionSale
                {
                    Id = lastElementId + 1,
                    Name = tbName.Text,
                    Discount = double.Parse(tbDiscount.Text),
                    StartDate = dpStartDate.SelectedDate.Value.Date,
                    EndDate = dpEndDate.SelectedDate.Value.Date
                });
            }
            this.Close();
        }
    }
}
  