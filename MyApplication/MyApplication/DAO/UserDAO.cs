using MyApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Configuration;

namespace MyApplication.DAO
{
    public class UserDAO : DAOInterface<User>
    {

        private static SqlConnection con;

        public void Add(User user)
        {
            string commandText = @"INSERT INTO User (Name,Surname,Username,Password,UserType) VALUES (@Name,@Surname,@Username,@Password,@UserType)";

            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = commandText;

                command.Parameters.Add(new SqlParameter("@Name", user.Name));
                command.Parameters.Add(new SqlParameter("@Surname", user.Surname));
                command.Parameters.Add(new SqlParameter("@Username", user.Username));
                command.Parameters.Add(new SqlParameter("@Password", user.Password));
                command.Parameters.Add(new SqlParameter("@UserType", user.UserType));

                command.ExecuteNonQuery();
            }
        }

        public void Update(User user)
        {
            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                if (user.Username != "")
                {
                    con.Open();
                    string commandText = @"UPDATE User SET Name = @Name, Surname = @Surname, Password = @Password, UserType = @UserType WHERE Username = @Username";

                    SqlCommand command = con.CreateCommand();
                    command.CommandText = commandText;

                    command.Parameters.Add(new SqlParameter("@Name", user.Name));
                    command.Parameters.Add(new SqlParameter("@Surname", user.Surname));
                    command.Parameters.Add(new SqlParameter("@Password", user.Password));
                    command.Parameters.Add(new SqlParameter("@UserType", user.UserType));
                    command.Parameters.Add(new SqlParameter("@Username", user.Username));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(User user)
        {
            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                if (user.Username != "")
                {
                    con.Open();
                    string commandText = @"UPDATE User SET Deleted = 1 WHERE Username = @Username";
                    SqlCommand command = con.CreateCommand();
                    command.CommandText = commandText;
                    command.Parameters.Add(new SqlParameter("@Username", user.Username));

                    command.ExecuteNonQuery();
                }
            }
        }

        public User Get(int entityId)
        {
            throw new NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            string commandText = @"SELECT * FROM USER WHERE Deleted = 0 AND Username = @Username";

            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = commandText;
                command.Parameters.Add(new SqlParameter("@Username", username));

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        string name = (string)dataReader["Name"];
                        string surname = (string)dataReader["Surname"];
                        string password = (string)dataReader["Password"];
                        TypeOfUser userType = (TypeOfUser)((int)dataReader["UserType"]);
                        bool deleted = (bool)dataReader["Deleted"];

                        return new User()
                        {
                            Name = name,
                            Surname = surname,
                            Username = username,
                            Password = password,
                            UserType = userType,
                            Deleted = deleted
                        };
                    }
                    return null;
                }
            }
        }

        public ObservableCollection<User> GetAll(string nameFilter = "")
        {
            ObservableCollection<User> users = new ObservableCollection<User>();

            string commandText = $"SELECT * FROM USERS WHERE Deleted = 0 AND Name = {nameFilter}";

            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                con.Open();
                SqlCommand command = con.CreateCommand();
                command.CommandText = commandText;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    string name = (string)dataReader["Name"];
                    string surname = (string)dataReader["Surname"];
                    string username = (string)dataReader["Username"];
                    string password = (string)dataReader["Password"];
                    TypeOfUser userType = (TypeOfUser)((int)dataReader["UserType"]);
                    bool deleted = (bool)dataReader["Deleted"];

                    users.Add(new User()
                    {
                        Name = name,
                        Surname = surname,
                        Username = username,
                        Password = password,
                        UserType = userType,
                        Deleted = deleted
                    });
                }

                dataReader.Close();

            }
            return users;
        }
    }
}
