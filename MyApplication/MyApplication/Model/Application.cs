using MyApplication.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Model
{
    class Application
    {
        public static Application Instance { get { return new Application(); } }

        public EntityDAO<User> Users
        {
            get
            {
                return new EntityDAO<User>("users.xml");
            }
        }
        public EntityDAO<FurnitureType> FurnitureTypes
        {
            get
            {
                return new EntityDAO<FurnitureType>("furniture_types.xml");
            }
        }
        public EntityDAO<Furniture> Furniture
        {
            get
            {
                return new EntityDAO<Furniture>("furniture.xml");
            }
        }
        public EntityDAO<AdditionalService> AdditionalServices
        {
            get
            {
                return new EntityDAO<AdditionalService>("additional_services.xml");
            }
        }
        public EntityDAO<ActionSale> ActionSales
        {
            get
            {
                return new EntityDAO<ActionSale>("action_sales.xml");
            }
        }

        private Application() { }
    }
}
