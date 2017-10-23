using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF8_2016.Model
{
    [Serializable]
    public class Furniture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public FurnitureType Type { get; set; }
        
    }
}
