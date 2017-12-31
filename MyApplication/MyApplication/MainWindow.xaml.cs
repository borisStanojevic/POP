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

        public MainWindow()
        {

            InitializeComponent();

            furnitureList = Singleton.Instance.Furniture;
            furnitureView = CollectionViewSource.GetDefaultView(furnitureList);
            furnitureView.Filter = x => { return ((Furniture)x).Deleted == false; };
            dgFurniture.ItemsSource = furnitureView;
            dgFurniture.IsSynchronizedWithCurrentItem = true;
            dgFurniture.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            //Instanciram listu, view, postavljam filter na view, postavljam izvor podataka data grid-a, postavljam sirine kolona da budu iste
            ftList = Singleton.Instance.FurnitureTypes;
            ftView = CollectionViewSource.GetDefaultView(ftList);
            ftView.Filter = x => { return ((FurnitureType)x).Deleted == false; };
            dgFurnitureTypes.ItemsSource = ftView;
            dgFurnitureTypes.IsSynchronizedWithCurrentItem = true;
            dgFurnitureTypes.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            usersList = Singleton.Instance.Users;
            usersView = CollectionViewSource.GetDefaultView(usersList);
            usersView.Filter = x => { return ((User)x).Deleted == false; };
            dgUsers.ItemsSource = usersView;
            dgUsers.IsSynchronizedWithCurrentItem = true;
            dgUsers.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            actionSalesList = Singleton.Instance.ActionSales;
            actionSalesView = CollectionViewSource.GetDefaultView(actionSalesList);
            actionSalesView.Filter = x => { return ((ActionSale)x).Deleted == false; };
            dgActionSales.ItemsSource = actionSalesView;
            dgActionSales.IsSynchronizedWithCurrentItem = true;
            dgActionSales.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            additionalServicesList = Singleton.Instance.AdditionalServices;
            additionalServicesView = CollectionViewSource.GetDefaultView(additionalServicesList);
            additionalServicesView.Filter = x => { return ((AdditionalService)x).Deleted == false; };
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
            if ((string)e.Column.Header == "FurnitureTypeId")
                e.Cancel = true;
            if ((string)e.Column.Header == "ActionSaleId")
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
            if ((string)e.Column.Header == "Id")
                e.Cancel = true;
            if ((string)e.Column.Header == "Deleted")
                e.Cancel = true;
        }

        private void dgAdditionalService_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
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

        private void AddFurnitureType(object sender, RoutedEventArgs e)
        {
            new FurnitureTypeWindow(null).ShowDialog();
            GenericSerializer.Serialize<FurnitureType>("furniture_types.xml", ftList);
        }

        private void EditFurnitureType(object sender, RoutedEventArgs e)
        {
            new FurnitureTypeWindow(dgFurnitureTypes.SelectedItem as FurnitureType, FurnitureTypeWindow.Mode.EDIT).ShowDialog();
            GenericSerializer.Serialize<FurnitureType>("furniture_types.xml", ftList);
        }

        private void DeleteFurnitureType(object sender, RoutedEventArgs e)
        {
            FurnitureType furnitureType = (FurnitureType)dgFurnitureTypes.SelectedItem;
            int furnitureTypeId = furnitureType.Id;
            if (MessageBox.Show($"Are you sure you want to delete : {furnitureType.Name} ?", "Deleting", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                ftList.Remove(furnitureType);
                ftView.Refresh();
                //Posle brisanja tipa namjestaja implementirati brisanje svih namhjestaja koji pripadaju tom tipu namjestaja
                foreach (Furniture item in furnitureList)
                {
                    if (item.FurnitureType.Id == furnitureTypeId)
                    {
                        furnitureList.Remove(item);
                        GenericSerializer.Serialize<Furniture>("furniture_xml", furnitureList);
                        furnitureView.Refresh();
                        break;
                    }
                }
                GenericSerializer.Serialize<FurnitureType>("furniture_types.xml", ftList);
            }
        }


        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            new UserWindow(null).ShowDialog();
            GenericSerializer.Serialize<User>("users.xml", usersList);
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            new UserWindow(dgUsers.SelectedItem as User, UserWindow.Mode.EDIT).ShowDialog();
            GenericSerializer.Serialize<User>("users.xml", usersList);
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            User user = (User)dgUsers.SelectedItem;
            if (MessageBox.Show($"Are you sure you want to delete : {user.Username} ?", "Deleting", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                usersList.Remove(user);
                usersView.Refresh();
                GenericSerializer.Serialize<User>("users.xml", usersList);
            }
        }

        private void btnAddActionSale_Click(object sender, RoutedEventArgs e)
        {
            new ActionSaleWindow(null).ShowDialog();
            GenericSerializer.Serialize<ActionSale>("action_sales.xml", actionSalesList);
        }

        private void btnEditActionSale_Click(object sender, RoutedEventArgs e)
        {
            new ActionSaleWindow(dgActionSales.SelectedItem as ActionSale, ActionSaleWindow.Mode.EDIT).ShowDialog();
            GenericSerializer.Serialize<ActionSale>("action_sales.xml", actionSalesList);
        }

        private void btnDeleteActionSale_Click(object sender, RoutedEventArgs e)
        {
            ActionSale actionSale = (ActionSale)dgActionSales.SelectedItem;
            if (MessageBox.Show($"Are you sure you want to delete : {actionSale.Name} ?", "Deleting", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                actionSalesList.Remove(actionSale);
                actionSalesView.Refresh();
                GenericSerializer.Serialize<ActionSale>("action_sales.xml", actionSalesList);
            }
        }

        private void btDeleteAdditionalService_Click(object sender, RoutedEventArgs e)
        {
            AdditionalService additionalService = (AdditionalService)dgAdditionalService.SelectedItem;
            if (MessageBox.Show($"Are you sure you want to delete : {additionalService.Name} ?", "Deleting", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                additionalServicesList.Remove(additionalService);
                additionalServicesView.Refresh();
                GenericSerializer.Serialize<AdditionalService>("additional_services.xml", additionalServicesList);
            }
        }

        private void btEditAdditionalService_Click(object sender, RoutedEventArgs e)
        {
            new AdditionalServiceWindow(dgAdditionalService.SelectedItem as AdditionalService, AdditionalServiceWindow.Mode.EDIT).ShowDialog();
            GenericSerializer.Serialize<AdditionalService>("additional_services.xml", additionalServicesList);
        }

        private void btAddAdditionalService_Click(object sender, RoutedEventArgs e)
        {
            new AdditionalServiceWindow(null).ShowDialog();
            GenericSerializer.Serialize<AdditionalService>("additional_services.xml", additionalServicesList);
        }

        private void btnDeleteFurniture_Click(object sender, RoutedEventArgs e)
        {
            Furniture furniture = (Furniture)dgFurniture.SelectedItem;
            if (MessageBox.Show($"Are you sure you want to delete : {furniture.Name} ?", "Deleting", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                furnitureList.Remove(furniture);
                furnitureView.Refresh();
                GenericSerializer.Serialize<Furniture>("furniture.xml", furnitureList);
            }
        }

        private void btnEditFurniture_Click(object sender, RoutedEventArgs e)
        {
            new FurnitureWindow(dgFurniture.SelectedItem as Furniture, FurnitureWindow.Mode.EDIT).ShowDialog();
            GenericSerializer.Serialize<Furniture>("furniture.xml", furnitureList);
        }

        private void btnAddFurniture_Click(object sender, RoutedEventArgs e)
        {
            new FurnitureWindow(null).ShowDialog();
            GenericSerializer.Serialize<Furniture>("furniture.xml", furnitureList);
        }
    }
}
