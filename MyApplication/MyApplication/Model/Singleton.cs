using MyApplication.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Model
{
    class Singleton
    {
        public static Singleton Instance { get { return new Singleton(); } }

        public ObservableCollection<User> Users { get; }
        public ObservableCollection<Sale> Sales { get; }
        public ObservableCollection<FurnitureType> FurnitureTypes { get; }
        public ObservableCollection<Furniture> Furniture { get; }
        public ObservableCollection<AdditionalService> AdditionalServices { get; }
        public ObservableCollection<ActionSale> ActionSales { get; }

        private Singleton()
        {
            Users = new ObservableCollection<User>();
            Sales = new ObservableCollection<Sale>();
            FurnitureTypes = new ObservableCollection<FurnitureType>();
            Furniture = new ObservableCollection<Furniture>();
            AdditionalServices = new ObservableCollection<AdditionalService>();
            ActionSales = new ObservableCollection<ActionSale>();
            FillWithData();
        }

        private void FillWithData()
        {

            ObservableCollection<User> usersList = GenericSerializer.Deserialize<User>("users.xml");
            foreach (var item in usersList)
            {
                Users.Add(item);
            }

            ObservableCollection<Sale> salesList = GenericSerializer.Deserialize<Sale>("sales.xml");
            foreach (var item in salesList)
            {
                Sales.Add(item);
            }

            ObservableCollection<FurnitureType> furnitureTypesList = GenericSerializer.Deserialize<FurnitureType>("furniture_types.xml");
            foreach (var item in furnitureTypesList)
            {
                FurnitureTypes.Add(item);
            }


            ObservableCollection<Furniture> furnitureList = GenericSerializer.Deserialize<Furniture>("furniture.xml");
            foreach (var item in furnitureList)
            {
                Furniture.Add(item);
            }


            ObservableCollection<AdditionalService> additionalServicesList = GenericSerializer.Deserialize<AdditionalService>("additional_services.xml");
            foreach (var item in additionalServicesList)
            {
                AdditionalServices.Add(item);
            }

            ObservableCollection<ActionSale> actionSalesList = GenericSerializer.Deserialize<ActionSale>("action_sales.xml");
            foreach (var item in actionSalesList)
            {
                ActionSales.Add(item);
            }
        }
    }
}
