using MyApplication.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.DAO
{
    public class AdditionalServiceDAO
    {
        private static SqlConnection con;

        public void Add(AdditionalService additionalService)
        {
            string commandText = @"INSERT INTO AdditionalService (Name,Price) VALUES (@Name,@Price)";

            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = commandText;

                command.Parameters.Add(new SqlParameter("@Name", additionalService.Name));
                command.Parameters.Add(new SqlParameter("@Price", additionalService.Price));

                command.ExecuteNonQuery();
            }
        }

        public void Update(AdditionalService additionalService)
        {
            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                if (additionalService.Id != 0)
                {
                    con.Open();
                    string commandText = @"UPDATE AdditionalService SET Name = @Name, Price = @Price WHERE Id = @Id";

                    SqlCommand command = con.CreateCommand();
                    command.CommandText = commandText;

                    command.Parameters.Add(new SqlParameter("@Name", additionalService.Name));
                    command.Parameters.Add(new SqlParameter("@Price", additionalService.Price));
                    command.Parameters.Add(new SqlParameter("@Id", additionalService.Id));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(AdditionalService additionalService)
        {
            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                if (additionalService.Id != 0)
                {
                    con.Open();
                    string commandText = @"UPDATE AdditionalService SET Deleted = 1 WHERE Id = @Id";
                    SqlCommand command = con.CreateCommand();
                    command.CommandText = commandText;
                    command.Parameters.Add(new SqlParameter("@Id", additionalService.Id));

                    command.ExecuteNonQuery();
                }
            }
        }

        public AdditionalService Get(AdditionalService additionalService)
        {
            string commandText = @"SELECT * FROM AdditionalService WHERE Id = @Id";
            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                con.Open();
                SqlCommand command = con.CreateCommand();
                command.CommandText = commandText;

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        int id = (int)dataReader["Id"];
                        string name = (string)dataReader["Name"];
                        decimal price = (decimal)dataReader["Price"];
                        bool deleted = (bool)dataReader["Deleted"];

                        return new AdditionalService()
                        {
                            Id = id,
                            Name = name,
                            Price = price,
                            Deleted = deleted
                        };
                    }
                }
            }
            return null;
        }

        public ObservableCollection<AdditionalService> GetAll(String nameFilter = "")
        {
            ObservableCollection<AdditionalService> additionalServices = new ObservableCollection<AdditionalService>();

            string commandText = $"SELECT * FROM AdditionalService WHERE Name LIKE '%{nameFilter}%' AND Deleted = 0;";
            //Treba mi SqlConnection, SqlCommand i DataReader

            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                con.Open();
                SqlCommand command = con.CreateCommand();
                command.CommandText = commandText;

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["Id"];
                        string name = (string)dataReader["Name"];
                        decimal price = (decimal)dataReader["Price"];
                        bool deleted = (bool)dataReader["Deleted"];

                        additionalServices.Add(new AdditionalService()
                        {
                            Id = id,
                            Name = name,
                            Price = price,
                            Deleted = deleted
                        });
                    }
                }
                dataReader.Close();
            }
            return additionalServices;
        }
    }
}
