using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace TestowanieOprogramowania.Services
{
    public class ProductHistoryService
    {
        private readonly string _connectionString;

        public ProductHistoryService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable PobierzHistorieProduktu(DateTime? startDate = null, DateTime? endDate = null, string filterType = null, string filterValue = null)
        {
            string query = @"SELECT TOP (1000) [ProduktID]
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
                  ,[Operacja]
              FROM [MagazynTestowanieOprogramowania].[dbo].[ProduktyHistoriaOperacji]";

            if (filterType == "Okres" && startDate.HasValue && endDate.HasValue)
            {
                query += " WHERE DataZapisu BETWEEN @StartDate AND @EndDate";
            }
            else if (!string.IsNullOrEmpty(filterType) && !string.IsNullOrEmpty(filterValue))
            {
                switch (filterType)
                {
                    case "Rodzaje towarów":
                        query += " WHERE @RodzajTowaru = '' OR RodzajTowaru LIKE @RodzajTowaru";
                        break;
                    case "Nazwy towarów":
                        query += " WHERE @NazwaTowaru = '' OR NazwaTowaru LIKE @NazwaTowaru";
                        break;
                    case "Rejestrujacy":
                        query += " WHERE @Rejestrujacy = '' OR Rejestrujacy LIKE @Rejestrujacy";
                        break;
                    case "ProduktID":
                        query += " WHERE @ProduktID = '' OR ProduktID = @ProduktID";
                        break;
                }
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (filterType == "Okres" && startDate.HasValue && endDate.HasValue)
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);
                    }
                    else if (!string.IsNullOrEmpty(filterType) && !string.IsNullOrEmpty(filterValue))
                    {
                        switch (filterType)
                        {
                            case "Rodzaje towarów":
                                command.Parameters.AddWithValue("@RodzajTowaru", string.IsNullOrEmpty(filterValue) ? "" : "%" + filterValue + "%");
                                break;
                            case "Nazwy towarów":
                                command.Parameters.AddWithValue("@NazwaTowaru", string.IsNullOrEmpty(filterValue) ? "" : "%" + filterValue + "%");
                                break;
                            case "Rejestrujacy":
                                command.Parameters.AddWithValue("@Rejestrujacy", string.IsNullOrEmpty(filterValue) ? "" : "%" + filterValue + "%");
                                break;
                            case "ProduktID":
                                int produktid;
                                bool isNumeric = int.TryParse(filterValue, out produktid);
                                command.Parameters.AddWithValue("@ProduktID", isNumeric ? produktid : 0);
                                break;
                        }
                    }

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
    }
}
