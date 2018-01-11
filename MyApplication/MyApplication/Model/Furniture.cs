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
    public class Furniture : Product
    {

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

        public override decimal Price { get => actionSale != null ? base.Price - (base.Price * actionSale.Discount) : base.Price; set => base.Price = value; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
