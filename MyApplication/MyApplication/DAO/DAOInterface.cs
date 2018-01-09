using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.DAO
{
    public interface DAOInterface<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(int entityId);
        ObservableCollection<T> GetAll(string nameFilter);
    }
}
