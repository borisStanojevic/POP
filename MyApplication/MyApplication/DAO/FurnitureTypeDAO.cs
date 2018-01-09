using MyApplication.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.DAO
{
    public class FurnitureTypeDAO : DAOInterface<FurnitureType>
    {
        private static SqlConnection con;

        public void Add(FurnitureType furnitureType)
        {
            string commandText = @"INSERT INTO FurnitureType (Name) VALUES (@Name)";

            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = commandText;

                command.Parameters.Add(new SqlParameter("@Name", furnitureType.Name));

                command.ExecuteNonQuery();
            }
        }

        public void Update(FurnitureType furnitureType)
        {
            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                if (furnitureType.Id != 0)
                {
                    con.Open();
                    string commandText = @"UPDATE FurnitureType SET Name = @Name WHERE Id = @Id";

                    SqlCommand command = con.CreateCommand();
                    command.CommandText = commandText;

                    command.Parameters.Add(new SqlParameter("@Name", furnitureType.Name));
                    command.Parameters.Add(new SqlParameter("@Id", furnitureType.Id));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(FurnitureType furnitureType)
        {
            /*
             Kad izaberem da izbrisem tip namjestaja prvo treba da izbrisem sve namjestaje koji pripadaju tom tipu,
             odnosno, da prodjem kroz tabelu Furniture i da izbrisem one koji imaju FurnitureTypeId isti kao furnitureType.Id iz parametra.
             Tek nakon toga mogu da obrisem sam tip namjestaja iz tabele FurnitureType, buduci da vise nece biti referenci na njega.
             Posto su dva upita u pitanju, trebali bi biti u okviru transakcije.
             */
            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                if (furnitureType.Id != 0)
                {
                    string commandText = @"UPDATE Furniture SET FurnitureTypeId = NULL WHERE FurnitureTypeId = @FurnitureTypeId";
                    string commandText2 = @"UPDATE FurnitureType SET Deleted = 1 WHERE Id = @FurnitureTypeId";

                    con.Open();
                    SqlTransaction transaction = con.BeginTransaction();
                    SqlCommand command = con.CreateCommand();
                    command.Transaction = transaction;

                    try
                    {
                        command.CommandText = commandText;
                        SqlParameter parameter = new SqlParameter("@FurnitureTypeId", furnitureType.Id);
                        command.Parameters.Add(parameter);
                        command.ExecuteNonQuery();

                        command.CommandText = commandText2;
                        command.Parameters.Add(parameter);
                        command.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception exc)
                    {
                        try
                        {
                            Console.WriteLine(exc.Message);
                            transaction.Rollback();
                        }
                        catch (Exception rollbackExc)
                        {
                            Console.WriteLine(rollbackExc.Message);
                        }
                    }

                }
            }
        }

        public FurnitureType Get(int furnitureTypeId)
        {
            string commandText = @"SELECT * FROM FurnitureType WHERE Id = @Id";
            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                con.Open();
                SqlCommand command = con.CreateCommand();
                command.CommandText = commandText;
                command.Parameters.Add(new SqlParameter("@Id", furnitureTypeId));

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        int id = (int)dataReader["Id"];
                        string name = (string)dataReader["Name"];
                        bool deleted = (bool)dataReader["Deleted"];

                        return new FurnitureType()
                        {
                            Id = id,
                            Name = name,
                            Deleted = deleted
                        };
                    }
                }
            }
            return null;
        }

        public ObservableCollection<FurnitureType> GetAll(string nameFilter = "")
        {
            ObservableCollection<FurnitureType> furnitureTypes = new ObservableCollection<FurnitureType>();

            string commandText = $"SELECT * FROM FurnitureType WHERE Name LIKE '%{nameFilter}%' AND Deleted = 0;";
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
                        bool deleted = (bool)dataReader["Deleted"];

                        furnitureTypes.Add(new FurnitureType()
                        {
                            Id = id,
                            Name = name,
                            Deleted = deleted
                        });
                    }
                }
                dataReader.Close();
            }
            return furnitureTypes;
        }
    }
}
