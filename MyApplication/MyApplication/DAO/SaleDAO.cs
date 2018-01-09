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
    public class SaleDAO : DAOInterface<Sale>
    {
        private SqlConnection con;

        public void Add(Sale entity)
        {
            throw new NotImplementedException();
        }

        //Nema implementaciju
        public void Update(Sale entity)
        {
            throw new NotImplementedException();
        }

        //Nema implementaciju
        public void Delete(Sale entity)
        {
            throw new NotImplementedException();
        }

        public Sale Get(int entityId)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Sale> GetAll(string nameFilter)
        {
            ObservableCollection<Sale> sales = new ObservableCollection<Sale>();

            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                con.Open();

                string commandText = @"SELECT * FROM Sale JOIN FurnitureSaleItem ON Sale.Id = FurnitureSaleItem.SaleId JOIN AdditionalServiceSaleItem ON Sale.Id = AdditionalServiceSaleItem.SaleId";

                SqlCommand command = con.CreateCommand();
                command.CommandText = commandText;

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["Id"];
                        DateTime dateOfSale = (DateTime)dataReader["DateOfSale"];
                        decimal fullPrice = (decimal)dataReader["FullPrice"];
                        string buyer = (string)dataReader["Buyer"];
                        int furnitureId;
                        try
                        {
                            furnitureId = (int)dataReader["FurnitureId"];
                            //Neam blage

                        }
                        catch (Exception exc)
                        {
                            furnitureId = -1;
                            Console.WriteLine(exc.Message);
                        }


                    }
                }
            }

            return sales;
        }
    }
}
