using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Model
{
    public enum TypeOfUser
    {
        Admin = 1,
        Salesman = 2
    }

    [Serializable]
    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static User GetByUsername(string username)
        {
            foreach (User user in Singleton.Instance.Users)
            {
                if (user.Username != username)
                    continue;
                return user;
            }
            return null;
        }

        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string surname;

        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private TypeOfUser userType;

        public TypeOfUser UserType
        {
            get { return userType; ; }
            set
            {
                userType = value;
                OnPropertyChanged("UserType");
            }
        }

        private bool deleted;

        public bool Deleted
        {
            get { return deleted; }
            set
            {
                deleted = value;
                OnPropertyChanged("Deleted");
            }
        }

        public override string ToString()
        {
            return String.Format("{0,-5}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-18}|{6,-5}", Id, Name, Surname, Username, Password, UserType, Deleted);
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

