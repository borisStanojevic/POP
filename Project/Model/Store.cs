using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF8_2016.Model
{
    [Serializable]
    public class Store
    {
        public int Id { get; set; }
        public int TaxingId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Account { get; set; }
        public bool Deleted { get; set; }
    }


}
