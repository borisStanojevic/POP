using POP_SF8_2016.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Store s1 = new Store()
            {
                Id = 1,
                Name = "Forma FTNale",
                Address = "Trg Dositeja obradovica 6",
                Account = "840-00076899-83",
                Email = "kontakt@uns.ac.ftn.ac.rs",
                TaxingId = 12223124,
                Phone = "021/445-342",
                Website = "www.nekisalon.com",
                Deleted = false

            };

            Console.WriteLine($"Welcome to our furniture store {s1.Name}");
            Console.Read();
        }
    }
}
