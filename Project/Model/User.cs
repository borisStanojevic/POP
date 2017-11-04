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

        public override string ToString()
        {
            return String.Format("{0,-5}|{1,-10}|{2,-15}|{3,-15}|{4,-15}|{5,-18}|{6,-5}",Id, Name, Surname, Username, Password, UserType, Deleted);
        }
    }
}

