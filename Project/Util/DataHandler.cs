using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Util
{
    class DataHandler
    {
        public static User GetUser(int id)
        {
            foreach (var item in ProjectMain.Instance.UsersList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static Sale GetSale(int id)
        {
            foreach (var item in ProjectMain.Instance.SalesList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static FurnitureType GetFurnitureType(int id)
        {
            foreach (var item in ProjectMain.Instance.FurnitureTypesList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static Furniture GetFurniture(int id)
        {
            foreach (var item in ProjectMain.Instance.FurnitureList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static AdditionalService GetAdditionalService(int id)
        {
            foreach (var item in ProjectMain.Instance.AdditionalServicesList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static ActionSale GetActionSale(int id)
        {
            foreach (var item in ProjectMain.Instance.ActionSalesList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static void ListUsers()
        {
            ProjectMain.Instance.UsersList.ForEach(i => Console.WriteLine(i.ToString()));
        }

        public static void ListSales()
        {
            ProjectMain.Instance.SalesList.ForEach(i => Console.WriteLine(i.ToString()));
        }

        public static void ListFurnitureTypes()
        {
            ProjectMain.Instance.FurnitureTypesList.ForEach(i => Console.WriteLine(i.ToString()));
        }

        public static void ListFurniture()
        {
            ProjectMain.Instance.FurnitureList.ForEach(i => Console.WriteLine(i.ToString()));
        }

        public static void ListAdditionalServices()
        {
            ProjectMain.Instance.AdditionalServicesList.ForEach(i => Console.WriteLine(i.ToString()));
        }

        public static void ListActionSales()
        {
            ProjectMain.Instance.ActionSalesList.ForEach(i => Console.WriteLine(i.ToString()));
        }

        public static bool AddUser(int id, string name, string surname, string username, string password, TypeOfUser userType, bool deleted)
        {
            foreach (var item in ProjectMain.Instance.UsersList)
            {
                if (id == item.Id || username == item.Username)
                {
                    return false;
                }
            }
            List<User> usersList = ProjectMain.Instance.UsersList;
            usersList.Add(new User()
            {
                Id = id,
                Name = name,
                Surname = surname,
                Username = username,
                Password = password,
                UserType = userType,
                Deleted = deleted
            });
            ProjectMain.Instance.UsersList = usersList;
            return true;
        }

        public static bool AddFurnitureType(int id, string name, bool deleted)
        {
            foreach (var item in ProjectMain.Instance.FurnitureTypesList)
            {
                if (id == item.Id)
                {
                    return false;
                }
            }
            List<FurnitureType> furnitureTypesList = ProjectMain.Instance.FurnitureTypesList;
            furnitureTypesList.Add(new FurnitureType()
            {
                Id = id,
                Name = name,
                Deleted = deleted
            });
            ProjectMain.Instance.FurnitureTypesList = furnitureTypesList;
            return true;
        }

        public static bool AddFurniture(int id, string name, double price, int quantity, int furnitureTypeId, bool deleted)
        {
            if (GetFurnitureType(furnitureTypeId) == null)
            {
                return false;
            }

            foreach (var item in ProjectMain.Instance.FurnitureList)
            {
                if (item.Id == id)
                {
                    return false;
                }
            }
            List<Furniture> furnitureList = ProjectMain.Instance.FurnitureList;
            furnitureList.Add(new Furniture()
            {
                Id = id,
                Name = name,
                Price = price,
                Quantity = quantity,
                Type = GetFurnitureType(furnitureTypeId),
                Deleted = deleted
            });
            return true;
        }

        public static bool AddAdditionalService(int id, string name, double price, bool deleted)
        {
            if (GetAdditionalService(id) != null)
            {
                return false;
            }
            List<AdditionalService> additionalServicesList = ProjectMain.Instance.AdditionalServicesList;
            additionalServicesList.Add(new AdditionalService()
            {
                Id = id,
                Name = name,
                Price = price,
                Deleted = deleted
            });
            return true;
        }

        // Dodati AddActionSale()

        //Dodati AddSale()
    }
}
