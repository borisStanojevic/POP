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

        public FurnitureTypeWindow(FurnitureType furnitureType, Mode mode)
        {

            InitializeComponent();
            InititalizeValues(furnitureType);
        }

        private void InititalizeValues(FurnitureType furnitureType)
        {
            MessageBox.Show(furnitureType.ToString());
        }

        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            List<FurnitureType> existingFurnitureType = new EntityDAO<FurnitureType>("furniture_type.xml").GetAll();

            switch (mode)
            {
                case Mode.ADD:
                    var newFurnitureType = new FurnitureType()
                    {
                    };
                    new EntityDAO<FurnitureType>("furniture_types.xml").Add(newFurnitureType);
                    break;
                default:
                    break;
            }
        }

    }
}
