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
    /// <summary>
    /// Interaction logic for FurnitureWindow.xaml
    /// </summary>
    public partial class FurnitureWindow : Window
    {
        private Furniture furniture;
        public enum Mode
        {
            ADD,
            EDIT
        }
        private Mode mode;

        public FurnitureWindow(Furniture furniture, Mode mode = Mode.ADD)
        {
            InitializeComponent();
            this.furniture = furniture;
            this.mode = mode;

            cbFurnitureType.ItemsSource = MainWindow.ftList;
            cbActionSale.ItemsSource = MainWindow.actionSalesList;
            cbFurnitureType.SelectedIndex = 0;

            if (mode == Mode.EDIT)
            {
                tbName.DataContext = furniture;
                tbPrice.DataContext = furniture;
                tbQuantity.DataContext = furniture;
                btnAddEditFurniture.Content = "Edit";

                cbFurnitureType.SelectedValue = furniture.FurnitureType.Id;
                try
                {
                    cbActionSale.SelectedValue = furniture.ActionSale.Id;
                }
                catch (Exception)
                {
                    cbActionSale.SelectedValue = null;
                }
            }

        }

        private void btnAddEditFurniture_Click(object sender, RoutedEventArgs e)
        {

            FurnitureDAO furnitureDAO = new FurnitureDAO();
            FurnitureType furnitureType;
            ActionSale actionSale;
            try
            {
                furnitureType = new FurnitureTypeDAO().Get((int)cbFurnitureType.SelectedValue);
                actionSale = cbActionSale.SelectedItem == null ? null : new ActionSaleDAO().Get((int)cbActionSale.SelectedValue);
            }
            catch (Exception)
            {
                furnitureType = null;
                actionSale = null;
            }

            if (mode == Mode.ADD)
            {

                Furniture furniture = new Furniture()
                {
                    Name = tbName.Text.Trim(),
                    Price = decimal.Parse(tbPrice.Text.Trim()),
                    Quantity = int.Parse(tbQuantity.Text.Trim()),
                    FurnitureType = furnitureType,
                    ActionSale = actionSale
                };

                MainWindow.furnitureList.Add(furniture);

                furnitureDAO.Add(furniture);
            }
            else
            {
                furniture.Name = tbName.Text.Trim();
                furniture.Price = decimal.Parse(tbPrice.Text.Trim());
                furniture.Quantity = int.Parse(tbQuantity.Text.Trim());
                furniture.FurnitureType = furnitureType;
                furniture.ActionSale = actionSale;

                furnitureDAO.Update(furniture);
            }

            Close();
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

        private void tbPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputValidator.ValidatePrice(tbPrice.Text.Trim()) == false)
            {
                tbPrice.BorderBrush = new SolidColorBrush(Colors.Red);
                tbPrice.BorderThickness = new Thickness(2);
            }
            else
            {
                tbPrice.BorderBrush = new SolidColorBrush(Colors.Blue);
                tbPrice.BorderThickness = new Thickness(1);
            }
        }

        private void tbQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputValidator.ValidateInteger(tbQuantity.Text.Trim()) == false)
            {
                tbQuantity.BorderBrush = new SolidColorBrush(Colors.Red);
                tbQuantity.BorderThickness = new Thickness(2);
            }
            else
            {
                tbQuantity.BorderBrush = new SolidColorBrush(Colors.Blue);
                tbQuantity.BorderThickness = new Thickness(1);
            }
        }
    }
}
