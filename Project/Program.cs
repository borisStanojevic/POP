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
            AdminUI adminUI = new AdminUI();
            adminUI.Run();

     
            Console.ReadLine();
        }

    }
}
