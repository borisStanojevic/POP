using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF8_2016.Model
{
    public class Sale

    {
        public List<Furniture> FurnitureForSale { get; set; }
        public int BillNumber { get; set; }
        public DateTime DateOfSale { get; set; }
        public List<AdditionalService> AdditionalServices { get; set; }
        public double Tax { get; set; }
        public double FullPrice { get; set; }
        public string Buyer { get; set; }

    }
}
