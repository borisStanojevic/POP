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

            if (mode == Mode.EDIT)
            {
                tbName.DataContext = furniture;
                tbPrice.DataContext = furniture;
                cbFurnitureType.DataContext = furniture;
                cbFurnitureType.SelectedValue = furniture.FurnitureTypeId;
                cbActionSale.DataContext = furniture;
                cbActionSale.SelectedValue = furniture.ActionSaleId;
                btnAddEditFurniture.Content = "Edit";
            }

        }

        private void btnAddEditFurniture_Click(object sender, RoutedEventArgs e)
        {
            if (this.mode == Mode.ADD)
            {
                int lastElementIndex = MainWindow.furnitureList.Count - 1;
                int lastElementId = MainWindow.furnitureList.ElementAt(lastElementIndex).Id;

                MainWindow.furnitureList.Add(new Furniture
                {
                    Id = lastElementId + 1,
                    Name = tbName.Text.Trim(),
                    Price = double.Parse(tbPrice.Text.Trim()),
                    FurnitureTypeId = (int)cbFurnitureType.SelectedValue,
                    ActionSaleId = (int)cbActionSale.SelectedValue
                });
            }
            this.Close();
        }
    }
}
