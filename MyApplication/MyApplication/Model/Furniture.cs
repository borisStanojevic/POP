using MyApplication.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyApplication.Model
{
    [Serializable]
    public class Furniture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int TypeId { get; set; }
        public ActionSale Action { get; set; }
        public bool Deleted { get; set; }

        private FurnitureType furnitureType;

        [XmlIgnore]
        public FurnitureType FurnitureType
        {
            get
            {
                if (furnitureType == null)
                {
                    furnitureType = Singleton.Instance.FurnitureTypes.Get(TypeId);
                }
                return furnitureType;
            }
            set
            {
                furnitureType = value;
                TypeId = furnitureType.Id;
                //OnPropertyChanged(furnitureType);
            }
        }

        public override string ToString()
        {
            return String.Format("{0,-5}|{1,-15}|{2,-10}|{3,-5}|{4,-5}|{5,-5}", Id, Name, Price, Quantity, Singleton.Instance.FurnitureTypes.Get(TypeId).Name, Action.Id, Deleted);
        }
    }
}
