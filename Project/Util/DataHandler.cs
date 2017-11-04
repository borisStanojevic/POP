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
        //Kreiranje genericke metode za dobavljanje entiteta po id-u (istovremeno provjera postojanja)
        public static T GetEntity<T>(int id, List<T> entitiesList)
        {
            foreach (T item in entitiesList)
            {
                int itemId = (int)item.GetType().GetProperty("Id").GetValue(item, null);
                if (itemId == id)
                {
                    return item;
                }
            }
            return default(T);
        }

        public static bool AddEntity<T>(T entity, string fileName)
        {
            List<T> entitesList = GenericSerializer.Deserialize<T>(fileName);
            /*Upotrebom refleksije, za vrijeme runtime-a, dobavljam vrijednost svojstva Id proslijedjenog objekta
              jer znam da ce svaki entitet u mom modelu imati Id.
             */
            int entityId = (int)entity.GetType().GetProperty("Id").GetValue(entity, null);
            if (GetEntity<T>(entityId, entitesList) != null)
            {
                return false;
            }
            entitesList.Add(entity);
            GenericSerializer.Serialize<T>(fileName, entitesList);
            return true;
        }

        public static void ListEntities<T>(List<T> entitiesList)
        {
            entitiesList.ForEach(i => Console.WriteLine(i.ToString()));
        }

        public static void ListUsers()
        {
            ProjectSingleton.Instance.UsersList.ForEach(i => Console.WriteLine(i.ToString()));
        }

        public static void ListSales()
        {
            ProjectSingleton.Instance.SalesList.ForEach(i => Console.WriteLine(i.ToString()));
        }

        public static void ListFurnitureTypes()
        {
            ProjectSingleton.Instance.FurnitureTypesList.ForEach(i => Console.WriteLine(i.ToString()));
        }

        public static void ListFurniture()
        {
            ProjectSingleton.Instance.FurnitureList.ForEach(i => Console.WriteLine(i.ToString()));
        }

        public static void ListAdditionalServices()
        {
            ProjectSingleton.Instance.AdditionalServicesList.ForEach(i => Console.WriteLine(i.ToString()));
        }

        public static void ListActionSales()
        {
            ProjectSingleton.Instance.ActionSalesList.ForEach(i => Console.WriteLine(i.ToString()));
        }

        public static bool AddUser(User user)
        {
            List<User> usersList = ProjectSingleton.Instance.UsersList;
            if (GetEntity<User>(user.Id, usersList) != null)
            {
                return false;
            }
            usersList.Add(user);
            ProjectSingleton.Instance.UsersList = usersList;
            return true;
        }

        public static bool AddFurnitureType(FurnitureType furnitureType)
        {
            List<FurnitureType> furnitureTypesList = ProjectSingleton.Instance.FurnitureTypesList;
            if (GetEntity<FurnitureType>(furnitureType.Id,furnitureTypesList) != null)
            {
                return false;
            }
            furnitureTypesList.Add(furnitureType);
            ProjectSingleton.Instance.FurnitureTypesList = furnitureTypesList;
            return true;
        }

        public static bool AddFurniture(Furniture furniture)
        {
            List<Furniture> furnitureList = ProjectSingleton.Instance.FurnitureList;
            if (GetEntity<Furniture>(furniture.Id, furnitureList) != null)
            {
                return false;
            }
            furnitureList.Add(furniture);
            ProjectSingleton.Instance.FurnitureList = furnitureList;
            return true;
        }

        public static bool AddAdditionalService(AdditionalService additionalService)
        {
            List<AdditionalService> additionalServicesList = ProjectSingleton.Instance.AdditionalServicesList;
            if (GetEntity<AdditionalService>(additionalService.Id,additionalServicesList) != null)
            {
                return false;
            }
            additionalServicesList.Add(additionalService);
            ProjectSingleton.Instance.AdditionalServicesList = additionalServicesList;
            return true;
        }

        // Dodati AddActionSale()

        //Dodati AddSale()
    }
}
