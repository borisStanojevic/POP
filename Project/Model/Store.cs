using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF8_2016.Model
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public int PIB { get; set; }
        public int MaticniBroj { get; set; }
        public string ZiroRacun { get; set; }
        public bool Deleted { get; set; }
    }
}
