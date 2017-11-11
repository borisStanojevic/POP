using MyApplication.DAO;
using MyApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Util
{
    class UserUtil
    {
        public static User GetByUsername(string username)
        {
            foreach (User user in new EntityDAO<User>("users.xml").GetAll())
            {
                if (user.Username != username)
                    continue;
                return user;
            }
            return null;
        }
    }
}
