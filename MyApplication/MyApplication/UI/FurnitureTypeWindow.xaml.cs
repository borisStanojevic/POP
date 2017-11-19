using MyApplication.DAO;
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
    /// Interaction logic for UsersWindow.xaml
    /// </summary>
    public partial class FurnitureTypeWindow : Window
    {

        public enum Mode
        {
            ADD,
            EDIT
        }
        private FurnitureType furnitureType;
        private Mode mode;

        public FurnitureTypeWindow(FurnitureType furnitureType, Mode mode = Mode.ADD)
        {
            this.furnitureType = furnitureType;
            this.mode = mode;

            InitializeComponent();
            if (furnitureType != null && mode.Equals(Mode.EDIT))
            {
                InititalizeValues(furnitureType);
                btnAddEdit.Content = "Edit";
            }
        }

        private void InititalizeValues(FurnitureType furnitureType)
        {
            tbId.Text = furnitureType.Id.ToString();
            tbId.IsReadOnly = true;
            tbName.Text = furnitureType.Name;

        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
