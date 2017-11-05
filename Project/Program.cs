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
            TypeOfUser userType = Login.DoLogin();
            if(userType != default(TypeOfUser))
            {
                if (userType.Equals(TypeOfUser.Admin))
                {
                    new AdminUI().Run();
                }
                else
                {
                    new SalesmanUI().Run();
                }
            }
            Console.ReadLine();
            
        }
    }
}
