using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Model
{
    [Serializable]
    public class Sale

    {
        public const double Tax = 0.02;

        public int Id { get; set; }
        public List<Furniture> FurnitureForSale { get; set; }
        public int BillNumber { get; set; }
        public DateTime DateOfSale { get; set; }
        public List<AdditionalService> AdditionalServices { get; set; }
        public double FullPrice { get; set; }
        public string Buyer { get; set; }

    }
}
