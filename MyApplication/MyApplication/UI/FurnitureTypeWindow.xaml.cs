using MyApplication.DAO;
using MyApplication.Model;
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
    /// <summary>
    /// Interaction logic for UsersWindow.xaml
    /// </summary>
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
                tbId.DataContext = furnitureType;
                tbId.IsReadOnly = true;
                tbName.DataContext = furnitureType;
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddEditFurnitureType_Click(object sender, RoutedEventArgs e)
        {
            if (this.mode == Mode.ADD)
            {
                MainWindow.ftList.Add(new FurnitureType()
                {
                    Id = int.Parse(tbId.Text),
                    Name = tbName.Text,
                    Deleted = false
                });
                this.Close();
            }
        }
    }
}
