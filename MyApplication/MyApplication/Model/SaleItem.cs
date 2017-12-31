using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Model
{
    public class SaleItem<T> where T : Product
    {
        public T ProductForSale { get; set; }
        public int Pieces { get; set; }


        //bool test()
        //{
        //    if(ProductForSale is Furniture)
        //    {
        //        int x = ((Furniture)ProductForSale).Quantity
        //    }
        //}
    }
}
