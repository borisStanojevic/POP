using Project.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class ProjectMain
    {
        public static ProjectMain Instance { get; } = new ProjectMain();
        private List<User> users;

        public List<User> Users
        {
            get
            {
                this.users = GenericSerializer.Deserialize<User>("users.xml");
                return this.users;
            }
            set
            {
                this.users = value;
                GenericSerializer.Serialize<User>("users.xml", this.users);
            }
        }

        //Za svaki entitet...
    }
}
