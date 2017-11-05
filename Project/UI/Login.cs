using Project.DAO;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.UI
{
    public class Login
    {
        public static TypeOfUser DoLogin()
        {
            EntityDAO<User> userDAO = new EntityDAO<User>("users.xml");
            List<User> users = userDAO.GetAll();

            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            Console.Clear();
      
            foreach (var item in users)
            {
                if (item.Username != username)
                    continue;
                if (item.Password != password)
                    continue;
                return item.UserType;
            }
            return default(TypeOfUser);
        }
    }
}
