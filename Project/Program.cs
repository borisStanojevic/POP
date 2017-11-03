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
            //AdminUI adminUI = new AdminUI();
            //adminUI.Run();

            //SalesmanUI sui = new SalesmanUI();
            //sui.Run();

            List<User> users = ProjectMain.Instance.UsersList;
            //users.add(new User()...);
            //ProjectMain.Instance.Users = users; upise u fajl
            foreach (var user in users)
            {
                Console.WriteLine(user.Name + user.Surname);
            }

            Console.ReadLine();
            

        }

    }
}
