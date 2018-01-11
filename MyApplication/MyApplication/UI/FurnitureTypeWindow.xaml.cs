using MyApplication.DAO;
using MyApplication.Model;
using MyApplication.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public partial class FurnitureTypeWindow : Window
    {
        public enum Mode
        {
            ADD,
            EDIT
        }
        private Mode mode;
        private FurnitureType furnitureType;


        public FurnitureTypeWindow(FurnitureType furnitureType, Mode mode = Mode.ADD)
        {
            InitializeComponent();

            this.furnitureType = furnitureType;
            this.mode = mode;

            if (mode == Mode.EDIT)
            {
                tbName.DataContext = furnitureType;
                btnAddEditFurnitureType.Content = "Edit";
            }
        }

        private void btnAddEditFurnitureType_Click(object sender, RoutedEventArgs e)
        {
            FurnitureTypeDAO furnitureTypeDAO = new FurnitureTypeDAO();

            if (mode == Mode.ADD)
            {
                FurnitureType furnitureType = new FurnitureType()
                {
                    Name = tbName.Text.Trim()
                };

                MainWindow.ftList.Add(furnitureType);
                furnitureTypeDAO.Add(furnitureType);
            }
            else
            {
                furnitureType.Name = tbName.Text.Trim();

                furnitureTypeDAO.Update(furnitureType);
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
    }
}
