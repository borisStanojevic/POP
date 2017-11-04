using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAO
{
    class EntityDAO<T>
    {
        private List<T> entitiesList;
        private string fileName;

        public List<T> GetAll()
        {
            this.entitiesList = GenericSerializer.Deserialize<T>(fileName);
            return this.entitiesList;
        }

        public EntityDAO(string fileName)
        {
            this.entitiesList = GenericSerializer.Deserialize<T>(fileName);
            this.fileName = fileName;
        }

        //Kreiranje genericke metode za dobavljanje entiteta po id-u (istovremeno provjera postojanja)
        public T Get(int id)
        {
            foreach (T item in this.GetAll())
            {
                int itemId = (int)item.GetType().GetProperty("Id").GetValue(item, null);
                if (itemId == id)
                {
                    return item;
                }
            }
            return default(T);
        }

        public bool Add(T entity)
        {
            /*Upotrebom refleksije, za vrijeme runtime-a, dobavljam vrijednost svojstva Id proslijedjenog objekta
              jer znam da ce svaki entitet u mom modelu imati Id.
             */
            int entityId = (int)entity.GetType().GetProperty("Id").GetValue(entity, null);
            if (this.Get(entityId) != null)
            {
                return false;
            }
            this.GetAll().Add(entity);
            GenericSerializer.Serialize<T>(fileName, this.entitiesList);
            return true;
        }

        public bool DeleteEntity(int id)
        {
            T entityToBeDeleted = Get(id);
            if (entityToBeDeleted == null)
            {
                return false;
            }

            foreach (T item in this.GetAll())
            {
                int itemId = (int)item.GetType().GetProperty("Id").GetValue(item, null);
                if (itemId == id)
                {
                    item.GetType().GetProperty("Deleted").SetValue(item, true);
                    break;
                }
            }
            GenericSerializer.Serialize<T>(fileName, this.entitiesList);
            return true;
        }

    }
}
