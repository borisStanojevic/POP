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
    public class FurnitureDAO : DAOInterface<Furniture>
    {

        private static SqlConnection con;

        public void Add(Furniture furniture)
        {
            string commandText = @"INSERT INTO Furniture (Name,Quantity,Price,FurnitureTypeId,ActionSaleId) VALUES (@Name,@Quantity,@Price,@FurnitureTypeId,@ActionSaleId)";

            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = commandText;

                command.Parameters.Add(new SqlParameter("@Name", furniture.Name));
                command.Parameters.Add(new SqlParameter("@Quantity", furniture.Quantity));
                command.Parameters.Add(new SqlParameter("@Price", furniture.Price));
                command.Parameters.Add(new SqlParameter("@FurnitureTypeId", furniture.FurnitureType.Id));
                int actionSaleId = furniture.ActionSale == null ? -1 : furniture.ActionSale.Id;
                if (actionSaleId == -1)
                {
                    command.Parameters.Add(new SqlParameter("@ActionSaleId", null));
                }
                else
                {
                    command.Parameters.Add(new SqlParameter("@ActionSaleId", actionSaleId));
                }
                command.Parameters.Add(new SqlParameter("@Id", furniture.Id));

                command.ExecuteNonQuery();
            }
        }

        public void Update(Furniture furniture)
        {
            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                if (furniture.Id != 0)
                {
                    con.Open();
                    string commandText = @"UPDATE Furniture SET Name = @Name, Quantity = @Quantity, Price = @Price, FurnitureTypeId = @FurnitureTypeId, ActionSaleId = @ActionSaleId WHERE Id = @Id";

                    SqlCommand command = con.CreateCommand();
                    command.CommandText = commandText;

                    command.Parameters.Add(new SqlParameter("@Name", furniture.Name));
                    command.Parameters.Add(new SqlParameter("@Quantity", furniture.Quantity));
                    command.Parameters.Add(new SqlParameter("@Price", furniture.Price));
                    command.Parameters.Add(new SqlParameter("@FurnitureTypeId", furniture.FurnitureType.Id));
                    int actionSaleId = furniture.ActionSale == null ? -1 : furniture.ActionSale.Id;
                    if (actionSaleId == -1)
                    {
                        command.Parameters.Add(new SqlParameter("@ActionSaleId", null));
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("@ActionSaleId", actionSaleId));
                    }
                    command.Parameters.Add(new SqlParameter("@Id", furniture.Id));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Furniture furniture)
        {
            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                if (furniture.Id != 0)
                {
                    con.Open();
                    string commandText = @"UPDATE Furniture SET Deleted = 1 WHERE Id = @Id";
                    SqlCommand command = con.CreateCommand();
                    command.CommandText = commandText;
                    command.Parameters.Add(new SqlParameter("@Id", furniture.Id));

                    command.ExecuteNonQuery();
                }
            }
        }

        public Furniture Get(int furnitureId)
        {
            string commandText = @"SELECT * FROM Furniture WHERE Id = @Id";

            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                con.Open();
                SqlCommand command = con.CreateCommand();
                command.CommandText = commandText;
                command.Parameters.Add(new SqlParameter("@Id", furnitureId));

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        int id = (int)dataReader["Id"];
                        string name = (string)dataReader["Name"];
                        int quantity = (int)dataReader["Quantity"];
                        decimal price = (decimal)dataReader["Price"];
                        int furnitureTypeId = (int)dataReader["FurnitureTypeId"];
                        FurnitureType furnitureType = new FurnitureTypeDAO().Get(furnitureTypeId);
                        int actionSaleId;
                        try
                        {
                            actionSaleId = (int)dataReader["ActionSaleId"];
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                            actionSaleId = -1;
                        }
                        ActionSale actionSale = actionSaleId == -1 ? null : new ActionSaleDAO().Get(actionSaleId);
                        bool deleted = (bool)dataReader["Deleted"];

                        return new Furniture()
                        {
                            Id = id,
                            Name = name,
                            Quantity = quantity,
                            Price = price,
                            FurnitureType = furnitureType,
                            ActionSale = actionSale,
                            Deleted = deleted
                        };
                    }
                }
                return null;
            }
        }

        public ObservableCollection<Furniture> GetAll(string nameFilter = "")
        {
            ObservableCollection<Furniture> furniture = new ObservableCollection<Furniture>();

            string commandText = $"SELECT * FROM Furniture WHERE Name LIKE '%{nameFilter}%' AND Deleted = 0;";
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
                        int quantity = (int)dataReader["Quantity"];
                        decimal price = (decimal)dataReader["Price"];
                        int furnitureTypeId = (int)dataReader["FurnitureTypeId"];
                        FurnitureType furnitureType = new FurnitureTypeDAO().Get(furnitureTypeId);
                        int actionSaleId;
                        try
                        {
                            actionSaleId = (int)dataReader["ActionSaleId"];
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                            actionSaleId = -1;
                        }
                        ActionSale actionSale = actionSaleId == -1 ? null : new ActionSaleDAO().Get(actionSaleId);
                        bool deleted = (bool)dataReader["Deleted"];

                        furniture.Add(new Furniture()
                        {
                            Id = id,
                            Name = name,
                            Quantity = quantity,
                            Price = price,
                            FurnitureType = furnitureType,
                            ActionSale = actionSale,
                            Deleted = deleted
                        });
                    }
                }
                dataReader.Close();
            }
            return furniture;
        }
    }
}