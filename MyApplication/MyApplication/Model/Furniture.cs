using MyApplication.DAO;
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

        private int actionSaleId;

        public int ActionSaleId
        {
            get { return ActionSaleId; }
            set
            {
                actionSaleId = value;
                OnPropertyChanged("ActionSaleId");
            }
        }


        private ActionSale actionSale;

        [XmlIgnore]
        public ActionSale ActionSale
        {
            get
            {
                if (actionSale == null)
                {
                    actionSale = new EntityDAO<ActionSale>("action_sales.xml").Get(actionSaleId);
                }
                return actionSale;
            }
            set
            {
                actionSale = value;
                actionSaleId = actionSale.Id;
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
                    furnitureType = new EntityDAO<FurnitureType>("furniture_types.xml").Get(furnitureTypeId);
                }
                return furnitureType;
            }
            set
            {
                furnitureType = value;
                furnitureTypeId = furnitureType.Id;
                OnPropertyChanged("FurnitureType");
            }

        }

    }
}
