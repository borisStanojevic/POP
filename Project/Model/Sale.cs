using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF8_2016.Model
{
    class Sale
    {
        public int Id { get; set; }
        public int MyProperty { get; set; }
        public DateTime DateOfSale { get; set; }
        public string BillId { get; set; }
        public List<AdditionalService> AdditionalServices { get; set; }
        public double PDV { get; set; }
        public double FullPrice { get; set; }
        public string Buyer { get; set; }

    }
}
