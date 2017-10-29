using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public enum TypeOfUser
    {
        Admin,
        Salesman
    }

    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public TypeOfUser UserType { get; set; }
        public bool Deleted { get; set; }
    }
}
