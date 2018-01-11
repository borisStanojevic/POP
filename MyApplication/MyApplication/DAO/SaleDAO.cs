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

        public void Add(Sale sale)
        {
            string commandText = @"INSERT INTO Sale (Id,DateOfSale,FullPrice,Buyer) VALUES (@Id,@DateOfSale, @FullPrice, @Buyer);";
            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                SqlCommand command = con.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    command.CommandText = commandText;
                    command.Parameters.Add(new SqlParameter("@Id", sale.Id));
                    command.Parameters.Add(new SqlParameter("@DateOfSale", sale.DateOfSale));
                    command.Parameters.Add(new SqlParameter("@FullPrice", sale.FullPrice));
                    command.Parameters.Add(new SqlParameter("@Buyer", sale.Buyer));

                    command.ExecuteNonQuery();

                    commandText = @"INSERT INTO FurnitureSaleItem (FurnitureId, Pieces, SaleId) VALUES (@FurnitureId, @Pieces, @SaleId);";
                    command.CommandText = commandText;
                    foreach (SaleItem<Furniture> item in sale.FurnitureForSale)
                    {
                        command.Parameters.Clear();
                        command.Parameters.Add(new SqlParameter("@FurnitureId", item.ProductForSale.Id));
                        command.Parameters.Add(new SqlParameter("@Pieces", item.Pieces));
                        command.Parameters.Add(new SqlParameter("@SaleId", sale.Id));
                        command.ExecuteNonQuery();
                    }

                    commandText = @"INSERT INTO AdditionalServiceSaleItem (AdditionalServiceId, Pieces, SaleId) VALUES (@AdditionalServiceId, @Pieces, @SaleId);";
                    command.CommandText = commandText;
                    foreach (SaleItem<AdditionalService> item in sale.ServicesForSale)
                    {
                        command.Parameters.Clear();
                        command.Parameters.Add(new SqlParameter("@AdditionalServiceId", item.ProductForSale.Id));
                        command.Parameters.Add(new SqlParameter("@Pieces", item.Pieces));
                        command.Parameters.Add(new SqlParameter("@SaleId", sale.Id));
                        command.ExecuteNonQuery();
                    }

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

        //Nema implementaciju
        public Sale Get(int entityId)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Sale> GetAll()
        {
            Dictionary<int, Sale> sales = new Dictionary<int, Sale>();

            using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["FurnitureStore"].ConnectionString))
            {
                con.Open();

                //Prvo dobavim sve prodaje iz baze i smjesim ih u dictionary
                string commandText = @"SELECT * FROM Sale";

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

                        Sale sale = new Sale()
                        {
                            Id = id,
                            DateOfSale = dateOfSale,
                            FullPrice = fullPrice,
                            Buyer = buyer
                        };

                        sales.Add(sale.Id, sale);
                    }
                }

                //Dobavljam sve stavke namjestaja i kacim ih svaki u odgovarajucu prodaju
                commandText = @"SELECT * FROM FurnitureSaleItem";
                command.CommandText = commandText;
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int furnitureId = (int)dataReader["FurnitureId"];
                        int pieces = (int)(byte)dataReader["Pieces"];
                        int saleId = (int)dataReader["SaleId"];

                        Furniture furniture = new FurnitureDAO().Get(furnitureId);

                        SaleItem<Furniture> furnitureSaleItem = new SaleItem<Furniture>();
                        furnitureSaleItem.ProductForSale = furniture;
                        furnitureSaleItem.Pieces = pieces;

                        sales[saleId].FurnitureForSale.Add(furnitureSaleItem);
                    }
                }

                //Dobavljam sve stavke dodatnih usluga i kacim ih svaku u odgovarajucu prodaju
                commandText = @"SELECT * FROM AdditionalServiceSaleItem";
                command.CommandText = commandText;
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int additionalServiceId = (int)dataReader["AdditionalServiceId"];
                        int pieces = (int)(byte)dataReader["Pieces"];
                        int saleId = (int)dataReader["SaleId"];

                        AdditionalService additionalService = new AdditionalServiceDAO().Get(additionalServiceId);

                        SaleItem<AdditionalService> additionalServiceSaleItem = new SaleItem<AdditionalService>();
                        additionalServiceSaleItem.ProductForSale = additionalService;
                        additionalServiceSaleItem.Pieces = pieces;

                        sales[saleId].ServicesForSale.Add(additionalServiceSaleItem);
                    }
                }
            }
            return new ObservableCollection<Sale>(sales.Values);
        }
    }
}
