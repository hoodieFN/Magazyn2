using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace TestowanieOprogramowania
{
    public partial class FormSprzedazDetails : Form
    {
        private string connectionString;
        private int idSprzedazy;

        public FormSprzedazDetails(int idSprzedazy, string connectionString)
        {
            InitializeComponent();
            this.idSprzedazy = idSprzedazy;
            this.connectionString = connectionString;
            LoadData();
        }

        private void FormSprzedazDetails_Load(object sender, EventArgs e)
        {
           
        }

        private void LoadData()
        {
            string query = @"
                            SELECT 
                            ProduktID,
                            NazwaTowaru,
                            RodzajTowaru,
                            JednostkaMiary,
                            IloscTowaru,
                            CenaZaTowar,
                            Przychod,
                            Miejscowosc,
                            KodPocztowy,
                            Ulica,
                            NrDomu
                            FROM [MagazynTestowanieOprogramowania].[dbo].[Sprzedaz]
                            WHERE 
                                IDSprzedazy = @IDSprzedazy;
                            ";

            string additionalQuery = @"
                            SELECT
                            NazwaKlienta,
                            NazwaSprzedawcy,
                            IDSprzedazy,
                            DataSprzedazy
                            FROM [MagazynTestowanieOprogramowania].[dbo].[Sprzedaz]
                            WHERE
                                IDSprzedazy = @IDSprzedazy;
                            ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection))
                    {
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@IDSprzedazy", idSprzedazy);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }

                    using (SqlCommand additionalCommand = new SqlCommand(additionalQuery, connection))
                    {
                        additionalCommand.Parameters.AddWithValue("@IDSprzedazy", idSprzedazy);
                        using (SqlDataReader reader = additionalCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                labelNazwaKlienta.Text = reader["NazwaKlienta"].ToString();
                                labelNazwaSprzedawcy.Text = reader["NazwaSprzedawcy"].ToString();
                                labelIDSprzedazy.Text = reader["IDSprzedazy"].ToString();
                                labelDataSprzedazy.Text = Convert.ToDateTime(reader["DataSprzedazy"]).ToString("yyyy-MM-dd"); // Format the date
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas ładowania danych: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
