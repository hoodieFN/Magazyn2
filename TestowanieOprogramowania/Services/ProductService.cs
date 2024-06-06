using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace TestowanieOprogramowania.Services
{
    public class ProductService
    {
        private readonly string _connectionString;

        public ProductService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool ProduktIstnieje(string nazwaTowaru)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM Produkty WHERE NazwaTowaru = @NazwaTowaru";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NazwaTowaru", nazwaTowaru);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public void DodajProdukt(string nazwaTowaru, string rodzajTowaru, string jednostkaMiary, int ilosc, decimal cenaNetto,
            string stawkaVAT, string opis, string dostawca, DateTime dataDostawy, DateTime dataRejestracji, string rejestracja)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Produkty (NazwaTowaru, RodzajTowaru, JednostkaMiary, Ilosc, CenaNetto, StawkaVAT, Opis, Dostawca, DataDostawy, DataRejestracji, Rejestrujacy) VALUES (@NazwaTowaru, @RodzajTowaru, @JednostkaMiary, @Ilosc, @CenaNetto, @StawkaVAT, @Opis, @Dostawca, @DataDostawy, @DataRejestracji, @Rejestrujacy)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NazwaTowaru", nazwaTowaru);
                    command.Parameters.AddWithValue("@RodzajTowaru", rodzajTowaru);
                    command.Parameters.AddWithValue("@JednostkaMiary", jednostkaMiary);
                    command.Parameters.AddWithValue("@Ilosc", ilosc);
                    command.Parameters.AddWithValue("@CenaNetto", cenaNetto);
                    command.Parameters.AddWithValue("@StawkaVAT", stawkaVAT);
                    command.Parameters.AddWithValue("@Opis", opis);
                    command.Parameters.AddWithValue("@Dostawca", dostawca);
                    command.Parameters.AddWithValue("@DataDostawy", dataDostawy);
                    command.Parameters.AddWithValue("@DataRejestracji", dataRejestracji);
                    command.Parameters.AddWithValue("@Rejestrujacy", rejestracja);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public string PobierzStawkeVAT(string nazwaRodzaju)
        {
            string stawkaVAT = string.Empty;

            string query = "SELECT StawkaVAT FROM RodzajeTowarow WHERE NazwaRodzaju = @NazwaRodzaju";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@NazwaRodzaju", SqlDbType.NVarChar)).Value = nazwaRodzaju;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        stawkaVAT = reader["StawkaVAT"].ToString();
                    }
                }
            }

            return stawkaVAT;
        }

        public void WypelnijRodzajeTowarow(ComboBox comboBoxRodzajTowaru)
        {
            string query = "SELECT NazwaRodzaju FROM RodzajeTowarow";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBoxRodzajTowaru.Items.Add(reader["NazwaRodzaju"].ToString());
                    }
                }
            }
        }
        public DataTable GetProductHistory()
        {
            string query = @"
                SELECT [ProduktID]
                      ,[NazwaTowaru]
                      ,[RodzajTowaru]
                      ,[JednostkaMiary]
                      ,[Ilosc]
                      ,[CenaNetto]
                      ,[StawkaVAT]
                      ,[Opis]
                      ,[Dostawca]
                      ,[DataDostawy]
                      ,[DataRejestracji]
                      ,[Rejestrujacy]
                      ,[DataZapisu]     
                FROM 
                    ProduktyHistoria1_Temp";

            return ExecuteQuery(query);
        }

        public DataTable GetProductHistoryByDate(DateTime date)
        {
            string query = @"
                SELECT [ProduktID]
                      ,[NazwaTowaru]
                      ,[RodzajTowaru]
                      ,[JednostkaMiary]
                      ,[Ilosc]
                      ,[CenaNetto]
                      ,[StawkaVAT]
                      ,[Opis]
                      ,[Dostawca]
                      ,[DataDostawy]
                      ,[DataRejestracji]
                      ,[Rejestrujacy]
                      ,[DataZapisu]
                FROM 
                    ProduktyHistoria1_Temp
                WHERE 
                    DataZapisu = @DataZapisu";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@DataZapisu", date)
            };

            return ExecuteQuery(query, parameters);
        }

        public DataTable GetProductById(int productId)
        {
            string query = "SELECT * FROM ProduktyHistoria1_Temp WHERE ProduktID = @ProduktID";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ProduktID", productId)
            };

            return ExecuteQuery(query, parameters);
        }

        public DataTable GetProductByIdAndDate(int productId, DateTime date)
        {
            string query = "SELECT * FROM ProduktyHistoria1_Temp WHERE ProduktID = @ProduktID AND CAST(DataZapisu AS DATE) = @DataZapisu";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ProduktID", productId),
                new SqlParameter("@DataZapisu", date.Date)
            };

            return ExecuteQuery(query, parameters);
        }

        private DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

    }
}
