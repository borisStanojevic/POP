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
    public class ActionSaleDAO : DAOInterface<ActionSale>
    {
        private static SqlConnection con;

        public void Add(ActionSale actionSale)
        {
            string commandText = @"INSERT INTO ActionSale (Name,Discount,StartDate,EndDate) VALUES (@Name,@Discount,@StartDate,@EndDate)";

            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = commandText;

                command.Parameters.Add(new SqlParameter("@Name", actionSale.Name));
                command.Parameters.Add(new SqlParameter("@Discount", actionSale.Discount));
                command.Parameters.Add(new SqlParameter("@StartDate", actionSale.StartDate));
                command.Parameters.Add(new SqlParameter("@EndDate", actionSale.EndDate));

                command.ExecuteNonQuery();
            }
        }

        public void Update(ActionSale actionSale)
        {
            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                if (actionSale.Id != 0)
                {
                    con.Open();
                    string commandText = @"UPDATE ActionSale SET Name = @Name, Discount = @Discount, StartDate = @StartDate, EndDate = @EndDate WHERE Id = @Id";

                    SqlCommand command = con.CreateCommand();
                    command.CommandText = commandText;

                    command.Parameters.Add(new SqlParameter("@Name", actionSale.Name));
                    command.Parameters.Add(new SqlParameter("@Discount", actionSale.Discount));
                    command.Parameters.Add(new SqlParameter("@StartDate", actionSale.StartDate));
                    command.Parameters.Add(new SqlParameter("@EndDate", actionSale.EndDate));
                    command.Parameters.Add(new SqlParameter("@Id", actionSale.Id));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(ActionSale actionSale)
        {
            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                if (actionSale.Id != 0)
                {
                    con.Open();
                    string commandText = @"UPDATE ActionSale SET Deleted = 1 WHERE Id = @Id";
                    SqlCommand command = con.CreateCommand();
                    command.CommandText = commandText;
                    command.Parameters.Add(new SqlParameter("@Id", actionSale.Id));

                    command.ExecuteNonQuery();
                }
            }
        }

        public ActionSale Get(int actionSaleId)
        {
            string commandText = @"SELECT * FROM ActionSale WHERE Id = @Id";

            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                con.Open();
                SqlCommand command = con.CreateCommand();
                command.CommandText = commandText;
                command.Parameters.Add(new SqlParameter("@Id", actionSaleId));

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        int id = (int)dataReader["Id"];
                        string name = (string)dataReader["Name"];
                        decimal discount = Convert.ToDecimal(dataReader["Discount"]);
                        DateTime startDate = (DateTime)dataReader["StartDate"];
                        DateTime endDate = (DateTime)dataReader["EndDate"];
                        bool deleted = (bool)dataReader["Deleted"];

                        return new ActionSale()
                        {
                            Id = id,
                            Name = name,
                            Discount = discount,
                            StartDate = startDate,
                            EndDate = endDate,
                            Deleted = deleted
                        };
                    }
                }
            }
            return null;
        }

        public ObservableCollection<ActionSale> GetAll(string nameFilter = "")
        {
            ObservableCollection<ActionSale> actionSales = new ObservableCollection<ActionSale>();

            string commandText = $"SELECT * FROM ActionSale WHERE Name LIKE '%{nameFilter}%' AND Deleted = 0;";
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
                        decimal discount = Convert.ToDecimal(dataReader["Discount"]);
                        DateTime startDate = (DateTime)dataReader["StartDate"];
                        DateTime endDate = (DateTime)dataReader["EndDate"];
                        bool deleted = (bool)dataReader["Deleted"];

                        actionSales.Add(new ActionSale()
                        {
                            Id = id,
                            Name = name,
                            Discount = discount,
                            StartDate = startDate,
                            EndDate = endDate,
                            Deleted = deleted
                        });
                    }
                }
                dataReader.Close();
            }
            return actionSales;
        }
    }
}
