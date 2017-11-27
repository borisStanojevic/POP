using MyApplication.DAO;
using MyApplication.Model;
using MyApplication.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyApplication
{
    public partial class MainWindow : Window
    {
        ICollectionView ftView;
        public static ObservableCollection<FurnitureType> ftList;

        public MainWindow()
        {
            InitializeComponent();

            ftList = Singleton.Instance.FurnitureTypes;
            ftView = CollectionViewSource.GetDefaultView(ftList);
            ftView.Filter = x => { return ((FurnitureType)x).Deleted == false; };
            dgFurnitureTypes.ItemsSource = ftView;
            dgFurnitureTypes.IsSynchronizedWithCurrentItem = true;
            dgFurnitureTypes.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

        }

        private void AddFurnitureType(object sender, RoutedEventArgs e)
        {
            new FurnitureTypeWindow(null).ShowDialog();
        }

        private void EditFurnitureType(object sender, RoutedEventArgs e)
        {
            new FurnitureTypeWindow(dgFurnitureTypes.SelectedItem as FurnitureType, FurnitureTypeWindow.Mode.EDIT).ShowDialog();
        }

        private void DeleteFurnitureType(object sender, RoutedEventArgs e)
        {
            FurnitureType furnitureType = (FurnitureType)dgFurnitureTypes.SelectedItem;
            if (MessageBox.Show($"Are you sure you want to delete : {furnitureType.Name} ?", "Deleting", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                ftList.Remove(furnitureType);
                ftView.Refresh();
                //Posle brisanja tipa namjestaja implementirati brisanje svih namhjestaja koji pripadaju tom tipu namjestaja
            }
        }

        private void dgFurnitureTypes_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
                e.Cancel = true;
            if ((string)e.Column.Header == "Deleted")
                e.Cancel = true;
        }
    }
}
