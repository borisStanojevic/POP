using MyApplication.DAO;
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

            if (mode == Mode.EDIT)
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
            ActionSaleDAO actionSaleDAO = new ActionSaleDAO();

            if (mode == Mode.ADD)
            {
                ActionSale actionSale = new ActionSale()
                {
                    Name = tbName.Text.Trim(),
                    Discount = decimal.Parse(tbDiscount.Text.Trim()),
                    StartDate = dpStartDate.SelectedDate.Value.Date,
                    EndDate = dpEndDate.SelectedDate.Value.Date
                };
                MainWindow.actionSalesList.Add(actionSale);
                actionSaleDAO.Add(actionSale);
            }
            else
            {
                actionSale.Name = tbName.Text.Trim();
                actionSale.Discount = decimal.Parse(tbDiscount.Text.Trim());
                actionSale.StartDate = dpStartDate.SelectedDate.Value.Date;
                actionSale.EndDate = dpEndDate.SelectedDate.Value.Date;

                actionSaleDAO.Update(actionSale);
            }

            Close();
        }

        private void tbDiscount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputValidator.ValidateDiscount(tbDiscount.Text.Trim()) == false)
            {
                tbDiscount.BorderBrush = new SolidColorBrush(Colors.Red);
                tbDiscount.BorderThickness = new Thickness(2);
            }
            else
            {
                tbDiscount.BorderBrush = new SolidColorBrush(Colors.Blue);
                tbDiscount.BorderThickness = new Thickness(1);
            }
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputValidator.ValidateString(tbName.Text.Trim()) == false)
            {
                tbName.BorderBrush = new SolidColorBrush(Colors.Red);
                tbName.BorderThickness = new Thickness(2);
            }
            else
            {
                tbName.BorderBrush = new SolidColorBrush(Colors.Blue);
                tbName.BorderThickness = new Thickness(1);
            }
        }
    }
}