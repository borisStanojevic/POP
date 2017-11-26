﻿using MyApplication.DAO;
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

            //Izvor podataka za ovaj DataGrid je lista tipova namjestaja u okviru objekta za rukovanje podacima o tipovima namjestaja
            ftList = Singleton.Instance.FurnitureTypes;
            ftView = CollectionViewSource.GetDefaultView(ftList);
            dgFurnitureTypes.ItemsSource = ftView;
            dgFurnitureTypes.IsSynchronizedWithCurrentItem = true;
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
 
            }
        }

    }
}
