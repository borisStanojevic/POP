using MyApplication.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyApplication.Model
{
    [Serializable]
    public class Furniture : INotifyPropertyChanged
    {
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private double price;

        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        private int furnitureTypeId;

        public int FurnitureTypeId
        {
            get { return furnitureTypeId; }
            set
            {
                furnitureTypeId = value;
                OnPropertyChanged("FurnitureTypeId");
            }
        }

        private ActionSale actionSale;

        public ActionSale ActionSale
        {
            get { return actionSale; }
            set
            {
                actionSale = value;
                OnPropertyChanged("ActionSale");
            }
        }

        private bool deleted;

        public bool Deleted
        {
            get { return deleted; }
            set
            {
                deleted = value;
                OnPropertyChanged("Deleted");
            }
        }

        private FurnitureType furnitureType;

        public event PropertyChangedEventHandler PropertyChanged;

        [XmlIgnore]
        public FurnitureType FurnitureType
        {
            get
            {
                if (furnitureType == null)
                {
                    furnitureType = Singleton.Instance.FurnitureTypeDAO.Get(furnitureTypeId);
                }
                return furnitureType;
            }
            set
            {
                furnitureType = value;
                furnitureTypeId = furnitureType.Id;
                //OnPropertyChanged(furnitureType);
            }
        }

        public override string ToString()
        {
            return String.Format("{0,-5}|{1,-15}|{2,-10}|{3,-5}|{4,-5}|{5,-5}", Id, Name, Price, Quantity, Singleton.Instance.FurnitureTypeDAO.Get(furnitureTypeId).Name, ActionSale.Id, Deleted);
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
