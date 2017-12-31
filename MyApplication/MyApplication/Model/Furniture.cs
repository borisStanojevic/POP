using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyApplication.Model
{
    [Serializable]
    public class Furniture : Product
    {

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

        private FurnitureType furnitureType;

        public FurnitureType FurnitureType
        {
            get
            {
                return furnitureType;
            }
            set
            {
                furnitureType = value;
                OnPropertyChanged("FurnitureType");
            }

        }

        private ActionSale actionSale;

        public ActionSale ActionSale
        {
            get
            {
                return actionSale;
            }
            set
            {
                actionSale = value;
                OnPropertyChanged("ActionSale");
            }
        }
    }
}
