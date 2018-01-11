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

        public MainWindow()
        {

            InitializeComponent();

            furnitureList = Singleton.Instance.Furniture;
            furnitureView = CollectionViewSource.GetDefaultView(furnitureList);
            dgFurniture.ItemsSource = furnitureView;
            dgFurniture.IsSynchronizedWithCurrentItem = true;
            dgFurniture.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            ftList = Singleton.Instance.FurnitureTypes;
            ftView = CollectionViewSource.GetDefaultView(ftList);
            dgFurnitureTypes.ItemsSource = ftView;
            dgFurnitureTypes.IsSynchronizedWithCurrentItem = true;
            dgFurnitureTypes.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            usersList = Singleton.Instance.Users;
            usersView = CollectionViewSource.GetDefaultView(usersList);
            dgUsers.ItemsSource = usersView;
            dgUsers.IsSynchronizedWithCurrentItem = true;
            dgUsers.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            actionSalesList = Singleton.Instance.ActionSales;
            actionSalesView = CollectionViewSource.GetDefaultView(actionSalesList);
            dgActionSales.ItemsSource = actionSalesView;
            dgActionSales.IsSynchronizedWithCurrentItem = true;
            dgActionSales.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            additionalServicesList = Singleton.Instance.AdditionalServices;
            additionalServicesView = CollectionViewSource.GetDefaultView(additionalServicesList);
            dgAdditionalService.ItemsSource = additionalServicesView;
            dgAdditionalService.IsSynchronizedWithCurrentItem = true;
            dgAdditionalService.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void dgFurniture_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
                e.Cancel = true;
            if ((string)e.Column.Header == "Deleted")
                e.Cancel = true;
        }

        private void dgFurnitureTypes_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
                e.Cancel = true;
            if ((string)e.Column.Header == "Deleted")
                e.Cancel = true;
        }

        private void dgUsers_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Deleted")
                e.Cancel = true;
        }

        private void dgAdditionalService_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
                e.Cancel = true;
            if ((string)e.Column.Header == "Quantity")
                e.Cancel = true;
            if ((string)e.Column.Header == "Deleted")
                e.Cancel = true;
        }

        private void dgActionSales_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
                e.Cancel = true;
            if ((string)e.Column.Header == "Deleted")
                e.Cancel = true;
        }

        #region RadSaTipom
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
            int furnitureTypeId = furnitureType.Id;
            if (MessageBox.Show($"Are you sure you want to delete : {furnitureType.Name} ?", "Deleting", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                FurnitureDAO furnitureDAO = new FurnitureDAO();

                ftList.Remove(furnitureType);
                ftView.Refresh();
                //Posle brisanja tipa namjestaja implementirati brisanje svih namhjestaja koji pripadaju tom tipu namjestaja
                foreach (Furniture item in furnitureList)
                {
                    if (item.FurnitureType.Id == furnitureTypeId)
                    {
                        furnitureList.Remove(item);
                        furnitureView.Refresh();
                    }
                }
                /*
                 Nakon uklanjanja tipa namjestaja iz radne memorije, zatim uklanjanja svih namjestaja koji pripadaju tom tipu i iz radne memorije
                 uklanjam i sam tip namjestaja iz baze.
                 */
                new FurnitureTypeDAO().Delete(furnitureType);
            }
        }
        #endregion

        #region RadSaKorisnikom
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            new UserWindow(null).ShowDialog();
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            new UserWindow(dgUsers.SelectedItem as User, UserWindow.Mode.EDIT).ShowDialog();
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            User user = (User)dgUsers.SelectedItem;
            if (MessageBox.Show($"Are you sure you want to delete : {user.Username} ?", "Deleting", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                usersList.Remove(user);
                usersView.Refresh();

                new UserDAO().Delete(user);
            }
        }
        #endregion

        #region RadSaAkcijom
        private void btnAddActionSale_Click(object sender, RoutedEventArgs e)
        {
            new ActionSaleWindow(null).ShowDialog();
        }

        private void btnEditActionSale_Click(object sender, RoutedEventArgs e)
        {
            new ActionSaleWindow(dgActionSales.SelectedItem as ActionSale, ActionSaleWindow.Mode.EDIT).ShowDialog();
        }

        private void btnDeleteActionSale_Click(object sender, RoutedEventArgs e)
        {
            ActionSale actionSale = (ActionSale)dgActionSales.SelectedItem;
            if (MessageBox.Show($"Are you sure you want to delete : {actionSale.Name} ?", "Deleting", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                actionSalesList.Remove(actionSale);
                actionSalesView.Refresh();

                new ActionSaleDAO().Delete(actionSale);
            }
        }
        #endregion

        #region RadSaUslugom
        private void btDeleteAdditionalService_Click(object sender, RoutedEventArgs e)
        {
            AdditionalService additionalService = (AdditionalService)dgAdditionalService.SelectedItem;
            if (MessageBox.Show($"Are you sure you want to delete : {additionalService.Name} ?", "Deleting", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                additionalServicesList.Remove(additionalService);
                additionalServicesView.Refresh();

                new AdditionalServiceDAO().Delete(additionalService);
            }
        }

        private void btEditAdditionalService_Click(object sender, RoutedEventArgs e)
        {
            new AdditionalServiceWindow(dgAdditionalService.SelectedItem as AdditionalService, AdditionalServiceWindow.Mode.EDIT).ShowDialog();
        }

        private void btAddAdditionalService_Click(object sender, RoutedEventArgs e)
        {
            new AdditionalServiceWindow(null).ShowDialog();
        }
        #endregion

        #region RadSaNamjestajem
        private void btnDeleteFurniture_Click(object sender, RoutedEventArgs e)
        {
            Furniture furniture = (Furniture)dgFurniture.SelectedItem;
            if (MessageBox.Show($"Are you sure you want to delete : {furniture.Name} ?", "Deleting", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                furnitureList.Remove(furniture);
                furnitureView.Refresh();

                new FurnitureDAO().Delete(furniture);
            }
        }

        private void btnEditFurniture_Click(object sender, RoutedEventArgs e)
        {
            new FurnitureWindow(dgFurniture.SelectedItem as Furniture, FurnitureWindow.Mode.EDIT).ShowDialog();
        }

        private void btnAddFurniture_Click(object sender, RoutedEventArgs e)
        {
            new FurnitureWindow(null).ShowDialog();

        }
        #endregion

        private void tbSearchUsers_TextChanged(object sender, TextChangedEventArgs e)
        {
            usersView.Filter = x =>
            {
                User u = x as User;
                return u.Username.ToLower().Contains(tbSearchUsers.Text.ToLower().Trim()) || u.Name.ToLower().Contains(tbSearchUsers.Text.ToLower().Trim());
            };
        }

        private void tbSearchFT_TextChanged(object sender, TextChangedEventArgs e)
        {
            ftView.Filter = x =>
            {
                FurnitureType ft = x as FurnitureType;
                return ft.Name.ToLower().Contains(tbSearchFT.Text.ToLower().Trim());
            };
        }

        private void tbSearchFurniture_TextChanged(object sender, TextChangedEventArgs e)
        {
            furnitureView.Filter = x =>
            {
                Furniture f = x as Furniture;
                return f.Name.ToLower().Contains(tbSearchFurniture.Text.ToLower().Trim());
            };
        }

        private void tbSearchActions_TextChanged(object sender, TextChangedEventArgs e)
        {
            actionSalesView.Filter = x =>
            {
                ActionSale asale = x as ActionSale;
                return asale.Name.ToLower().Contains(tbSearchActions.Text.ToLower().Trim());
            };
        }

        private void tbSearchAS_TextChanged(object sender, TextChangedEventArgs e)
        {
            additionalServicesView.Filter = x =>
            {
                AdditionalService aservice = x as AdditionalService;
                return aservice.Name.ToLower().Contains(tbSearchAS.Text.ToLower().Trim());
            };
        }

        ICollectionView furnitureView;
        public static ObservableCollection<Furniture> furnitureList;
        ICollectionView ftView;
        public static ObservableCollection<FurnitureType> ftList;
        ICollectionView usersView;
        public static ObservableCollection<User> usersList;
        ICollectionView actionSalesView;
        public static ObservableCollection<ActionSale> actionSalesList;
        ICollectionView additionalServicesView;
        public static ObservableCollection<AdditionalService> additionalServicesList;

    }
}
