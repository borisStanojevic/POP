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
    public class Furniture : SaleItem
    {
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


        private FurnitureType furnitureType;

        [XmlIgnore]
        public FurnitureType FurnitureType
        {
            get
            {
                if (furnitureType == null)
                {
                    //furnitureType = Singleton.Instance.FurnitureTypeDAO.Get(furnitureTypeId);
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

        //public override string ToString()
        //{
        //    return String.Format("{0,-5}|{1,-15}|{2,-10}|{3,-5}|{4,-5}|{5,-5}", Id, Name, Price, Quantity, Singleton.Instance.FurnitureTypeDAO.Get(furnitureTypeId).Name, ActionSale.Id, Deleted);
        //}

    }
}
