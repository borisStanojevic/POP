using MyApplication.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Model
{


    class Singleton
    {
        public static Singleton Instance { get { return new Singleton(); } }

        public EntityDAO<User> UsersDAO
        {
            get
            {
                return new EntityDAO<User>("users.xml");
            }
        }
        public EntityDAO<FurnitureType> FurnitureTypeDAO
        {
            get
            {
                return new EntityDAO<FurnitureType>("furniture_types.xml");
            }
        }
        public EntityDAO<Furniture> FurnitureDAO
        {
            get
            {
                return new EntityDAO<Furniture>("furniture.xml");
            }
        }
        public EntityDAO<AdditionalService> AdditionalServicesDAO
        {
            get
            {
                return new EntityDAO<AdditionalService>("additional_services.xml");
            }
        }
        public EntityDAO<ActionSale> ActionSalesDAO
        {
            get
            {
                return new EntityDAO<ActionSale>("action_sales.xml");
            }
        }

        private Singleton() { }
    }
}
