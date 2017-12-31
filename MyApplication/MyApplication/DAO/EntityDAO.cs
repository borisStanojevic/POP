//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyApplication.DAO
//{
//    class EntityDAO<T>
//    {
//        private ObservableCollection<T> entitiesList = new ObservableCollection<T>();
//        public ObservableCollection<T> EntitiesList
//        {
//            get
//            {
//                return this.entitiesList;
//            }
//        }
//        private string fileName;

//        /*
//        public ObservableCollection<T> GetAll()
//        {
//            this.entitiesList.Clear();
//            foreach (var item in GenericSerializer.Deserialize<T>(fileName))
//            {
//                this.entitiesList.Add(item);
//            }
//            return this.entitiesList;
//        }
//        */

//        // Kada kreiramo objekat ucitaju se svi etiteti u listu entitiesList
//        public EntityDAO(string fileName)
//        {
//            this.fileName = fileName;

//            foreach (var item in GenericSerializer.Deserialize<T>(fileName))
//            {
//                this.entitiesList.Add(item);
//            }
//        }

//        //Kreiranje genericke metode za dobavljanje entiteta po id-u (istovremeno provjera postojanja)
//        public T Get(int id)
//        {
//            foreach (T item in this.entitiesList)
//            {
//                //Refleksijom dobavljam vrijednost Id property-ja
//                int itemId = (int)item.GetType().GetProperty("Id").GetValue(item, null);
//                if (itemId == id)
//                {
//                    return item;
//                }
//            }
//            return default(T);
//        }

//        public bool Add(T entity)
//        {
//            /*Upotrebom refleksije, za vrijeme runtime-a, dobavljam vrijednost svojstva Id proslijedjenog objekta
//              jer znam da ce svaki entitet u mom modelu imati Id.
//             */
//            int entityId = (int)entity.GetType().GetProperty("Id").GetValue(entity, null);
//            if (this.Get(entityId) != null)
//            {
//                return false;
//            }
//            this.entitiesList.Add(entity);
//            GenericSerializer.Serialize<T>(fileName, this.entitiesList);
//            return true;
//        }

//        public void Delete(T entity)
//        {
//            int entityId = (int)entity.GetType().GetProperty("Id").GetValue(entity, null);
//            foreach (T item in this.entitiesList)
//            {
//                if ((int)entity.GetType().GetProperty("Id").GetValue(item, null) == entityId)
//                {
//                    item.GetType().GetProperty("Deleted").SetValue(item, true);
//                    break;
//                }
//            }
//            GenericSerializer.Serialize<T>(fileName, this.entitiesList);
//        }
//        //Implementacija Edit metode


//    }
//}
