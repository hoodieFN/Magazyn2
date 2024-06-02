using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                // First query to fill the DataGridView
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@IDSprzedazy", idSprzedazy);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                // Second query to get additional details for the labels
                SqlCommand additionalCommand = new SqlCommand(additionalQuery, connection);
                additionalCommand.Parameters.AddWithValue("@IDSprzedazy", idSprzedazy);
                connection.Open();
                SqlDataReader reader = additionalCommand.ExecuteReader();

                if (reader.Read())
                {
                    labelNazwaKlienta.Text = reader["NazwaKlienta"].ToString();
                    labelNazwaSprzedawcy.Text = reader["NazwaSprzedawcy"].ToString();
                    labelIDSprzedazy.Text = reader["IDSprzedazy"].ToString();
                    labelDataSprzedazy.Text = Convert.ToDateTime(reader["DataSprzedazy"]).ToString("yyyy-MM-dd"); // Format the date
                }

                reader.Close();
                connection.Close();
            }
        }
    }
}
