using Project.DAO;
using Project.Model;
using Project.UI;
using Project.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            EntityDAO<FurnitureType> ed = new EntityDAO<FurnitureType>("furniture_types.xml");
            ed.Add(new FurnitureType()
            {
                Id = 3,
                Name = "Luster",
                Deleted = false
            });
            foreach (var item in ed.GetAll())
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }
    }
}
