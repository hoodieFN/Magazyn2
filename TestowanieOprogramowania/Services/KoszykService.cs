using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace TestowanieOprogramowania.Services
{
    public class KoszykService
    {
        private readonly string _connectionString;

        public KoszykService(string connectionString)
        {
            _connectionString = connectionString; // Initialize the field here
        }

        public DataTable GetProductDetails(string nazwaTowaru)
        {
            DataTable koszykTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM dbo.Koszyk WHERE NazwaTowaru = @NazwaTowaru";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NazwaTowaru", nazwaTowaru);

                    try
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(koszykTable);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Wystąpił błąd podczas ładowania szczegółów produktu: " + ex.Message);
                    }
                }
            }

            return koszykTable;
        }

        public DataTable GetAllProducts()
        {
            DataTable productsTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT DISTINCT NazwaTowaru FROM Produkty";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(productsTable);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Wystąpił błąd podczas ładowania nazw towarów: " + ex.Message);
                    }
                }
            }

            return productsTable;
        }

        public void AddProductToCart(DataRow produkt, decimal iloscZamawiana, decimal cenaZaTowar, string nazwaKlienta, string miejscowosc, string kodPocztowy, string ulica, string nrDomu, DateTime dataSprzedazy)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string insertQuery = @"
                    INSERT INTO dbo.Koszyk
                    (ProduktID, NazwaTowaru, RodzajTowaru, JednostkaMiary, Ilosc, CenaNetto, StawkaVAT, Opis, Dostawca, DataDostawy, DataRejestracji, Rejestrujacy, IloscTowaru, CenaZaTowar, Przychod, NazwaKlienta, Miejscowosc, KodPocztowy, Ulica, NrDomu, DataSprzedazy)
                    VALUES
                    (@ProduktID, @NazwaTowaru, @RodzajTowaru, @JednostkaMiary, @Ilosc, @CenaNetto, @StawkaVAT, @Opis, @Dostawca, @DataDostawy, @DataRejestracji, @Rejestrujacy, @IloscTowaru, @CenaZaTowar, @Przychod, @NazwaKlienta, @Miejscowosc, @KodPocztowy, @Ulica, @NrDomu, @DataSprzedazy)";

                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@ProduktID", produkt["ProduktID"]);
                insertCmd.Parameters.AddWithValue("@NazwaTowaru", produkt["NazwaTowaru"]);
                insertCmd.Parameters.AddWithValue("@RodzajTowaru", produkt["RodzajTowaru"]);
                insertCmd.Parameters.AddWithValue("@JednostkaMiary", produkt["JednostkaMiary"]);
                insertCmd.Parameters.AddWithValue("@Ilosc", produkt["Ilosc"]);
                insertCmd.Parameters.AddWithValue("@CenaNetto", produkt["CenaNetto"]);
                insertCmd.Parameters.AddWithValue("@StawkaVAT", produkt["StawkaVAT"]);
                insertCmd.Parameters.AddWithValue("@Opis", produkt["Opis"]);
                insertCmd.Parameters.AddWithValue("@Dostawca", produkt["Dostawca"]);
                insertCmd.Parameters.AddWithValue("@DataDostawy", produkt["DataDostawy"]);
                insertCmd.Parameters.AddWithValue("@DataRejestracji", produkt["DataRejestracji"]);
                insertCmd.Parameters.AddWithValue("@Rejestrujacy", produkt["Rejestrujacy"]);
                insertCmd.Parameters.AddWithValue("@IloscTowaru", iloscZamawiana);
                insertCmd.Parameters.AddWithValue("@CenaZaTowar", cenaZaTowar);
                insertCmd.Parameters.AddWithValue("@Przychod", iloscZamawiana * cenaZaTowar);
                insertCmd.Parameters.AddWithValue("@NazwaKlienta", nazwaKlienta);
                insertCmd.Parameters.AddWithValue("@Miejscowosc", miejscowosc);
                insertCmd.Parameters.AddWithValue("@KodPocztowy", kodPocztowy);
                insertCmd.Parameters.AddWithValue("@Ulica", ulica);
                insertCmd.Parameters.AddWithValue("@NrDomu", nrDomu);
                insertCmd.Parameters.AddWithValue("@DataSprzedazy", dataSprzedazy);

                insertCmd.ExecuteNonQuery();

                UpdateProductQuantity(Convert.ToInt32(produkt["ProduktID"]), -iloscZamawiana);
            }
        }

        public void UpdateProductQuantity(int produktId, decimal quantityChange)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string updateQuery = "UPDATE dbo.Produkty SET Ilosc = Ilosc + @QuantityChange WHERE ProduktID = @ProduktID";
                SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@QuantityChange", quantityChange);
                updateCmd.Parameters.AddWithValue("@ProduktID", produktId);

                updateCmd.ExecuteNonQuery();
            }
        }

        public void RemoveFromCart(string nazwaTowaru, int iloscTowaru)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand updateCmd = new SqlCommand("UPDATE dbo.Produkty SET Ilosc = Ilosc + @IloscTowaru WHERE NazwaTowaru = @NazwaTowaru", conn);
                updateCmd.Parameters.AddWithValue("@IloscTowaru", iloscTowaru);
                updateCmd.Parameters.AddWithValue("@NazwaTowaru", nazwaTowaru);
                updateCmd.ExecuteNonQuery();

                SqlCommand deleteCmd = new SqlCommand("DELETE FROM dbo.Koszyk WHERE NazwaTowaru = @NazwaTowaru", conn);
                deleteCmd.Parameters.AddWithValue("@NazwaTowaru", nazwaTowaru);
                deleteCmd.ExecuteNonQuery();
            }
        }

        public void RegisterSale(string imieNazwiskoRejestr)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand selectCmd = new SqlCommand("SELECT * FROM dbo.Koszyk", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(selectCmd);
                DataTable koszykTable = new DataTable();
                adapter.Fill(koszykTable);

                if (koszykTable.Rows.Count > 0)
                {
                    SqlCommand getMaxSaleIDCmd = new SqlCommand("SELECT ISNULL(MAX(IDSprzedazy), 0) + 1 FROM dbo.Sprzedaz", conn);
                    int nextSaleID = (int)getMaxSaleIDCmd.ExecuteScalar();

                    foreach (DataRow row in koszykTable.Rows)
                    {
                        string insertQuery = @"
                            INSERT INTO dbo.Sprzedaz
                            (ProduktID, NazwaTowaru, RodzajTowaru, JednostkaMiary, Ilosc, CenaNetto, StawkaVAT, Opis, Dostawca, DataDostawy, DataRejestracji, Rejestrujacy, NazwaTowaruNowa, IloscTowaru, CenaZaTowar, Przychod, NazwaKlienta, Miejscowosc, KodPocztowy, Ulica, NrDomu, DataSprzedazy, IDSprzedazy, NazwaSprzedawcy)
                            VALUES
                            (@ProduktID, @NazwaTowaru, @RodzajTowaru, @JednostkaMiary, @Ilosc, @CenaNetto, @StawkaVAT, @Opis, @Dostawca, @DataDostawy, @DataRejestracji, @Rejestrujacy, @NazwaTowaruNowa, @IloscTowaru, @CenaZaTowar, @Przychod, @NazwaKlienta, @Miejscowosc, @KodPocztowy, @Ulica, @NrDomu, @DataSprzedazy, @IDSprzedazy, @NazwaSprzedawcy)";

                        SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@ProduktID", row["ProduktID"]);
                        insertCmd.Parameters.AddWithValue("@NazwaTowaru", row["NazwaTowaru"]);
                        insertCmd.Parameters.AddWithValue("@RodzajTowaru", row["RodzajTowaru"]);
                        insertCmd.Parameters.AddWithValue("@JednostkaMiary", row["JednostkaMiary"]);
                        insertCmd.Parameters.AddWithValue("@Ilosc", row["Ilosc"]);
                        insertCmd.Parameters.AddWithValue("@CenaNetto", row["CenaNetto"]);
                        insertCmd.Parameters.AddWithValue("@StawkaVAT", row["StawkaVAT"]);
                        insertCmd.Parameters.AddWithValue("@Opis", row["Opis"]);
                        insertCmd.Parameters.AddWithValue("@Dostawca", row["Dostawca"]);
                        insertCmd.Parameters.AddWithValue("@DataDostawy", row["DataDostawy"]);
                        insertCmd.Parameters.AddWithValue("@DataRejestracji", row["DataRejestracji"]);
                        insertCmd.Parameters.AddWithValue("@Rejestrujacy", row["Rejestrujacy"]);
                        insertCmd.Parameters.AddWithValue("@NazwaTowaruNowa", row["NazwaTowaruNowa"]);
                        insertCmd.Parameters.AddWithValue("@IloscTowaru", row["IloscTowaru"]);
                        insertCmd.Parameters.AddWithValue("@CenaZaTowar", row["CenaZaTowar"]);
                        insertCmd.Parameters.AddWithValue("@Przychod", row["Przychod"]);
                        insertCmd.Parameters.AddWithValue("@NazwaKlienta", row["NazwaKlienta"]);
                        insertCmd.Parameters.AddWithValue("@Miejscowosc", row["Miejscowosc"]);
                        insertCmd.Parameters.AddWithValue("@KodPocztowy", row["KodPocztowy"]);
                        insertCmd.Parameters.AddWithValue("@Ulica", row["Ulica"]);
                        insertCmd.Parameters.AddWithValue("@NrDomu", row["NrDomu"]);
                        insertCmd.Parameters.AddWithValue("@DataSprzedazy", row["DataSprzedazy"]);
                        insertCmd.Parameters.AddWithValue("@IDSprzedazy", nextSaleID);
                        insertCmd.Parameters.AddWithValue("@NazwaSprzedawcy", imieNazwiskoRejestr);

                        insertCmd.ExecuteNonQuery();
                    }

                    SqlCommand deleteCmd = new SqlCommand("DELETE FROM dbo.Koszyk", conn);
                    deleteCmd.ExecuteNonQuery();
                }
            }
        }
    }
}
