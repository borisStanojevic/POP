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

            foreach (var item in new UserDAO().GetAll())
            {
                Users.Add(item);
            }


            foreach (var item in new SaleDAO().GetAll())
            {
                Sales.Add(item);
            }


            foreach (var item in new FurnitureTypeDAO().GetAll())
            {
                FurnitureTypes.Add(item);
            }


            foreach (var item in new FurnitureDAO().GetAll())
            {
                Furniture.Add(item);
            }


            foreach (var item in new AdditionalServiceDAO().GetAll())
            {
                AdditionalServices.Add(item);
            }

            foreach (var item in new ActionSaleDAO().GetAll())
            {
                ActionSales.Add(item);
            }
        }
    }
}
