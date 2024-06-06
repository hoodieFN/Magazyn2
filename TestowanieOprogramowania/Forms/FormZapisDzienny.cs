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
using TestowanieOprogramowania.Services;

namespace TestowanieOprogramowania
{
    public partial class FormZapisDzienny : Form
    {
        private ZarzadzanieVoidami zarzadzanieVoidami;
        string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();
        public FormZapisDzienny()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DateTime dataZapisu = dateTimePicker1.Value;
            DateTime dataZapisu2 = dateTimePicker1.Value.Date;
            string dataZapisuFormatted = dataZapisu2.ToString("dd.MM.yyyy");

            string query = @"
                INSERT INTO ProduktyHistoria1_Temp 
                    (ProduktID, NazwaTowaru, RodzajTowaru, JednostkaMiary, Ilosc, CenaNetto, StawkaVAT, Opis, Dostawca, DataDostawy, DataRejestracji, Rejestrujacy, DataZapisu)
                SELECT 
                    ProduktID, NazwaTowaru, RodzajTowaru, JednostkaMiary, Ilosc, CenaNetto, StawkaVAT, Opis, Dostawca, DataDostawy, DataRejestracji, Rejestrujacy, @DataZapisu
                FROM 
                    Produkty;";

            using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@DataZapisu", SqlDbType.DateTime)).Value = dataZapisu;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Stany magazynowe na dzień " + dataZapisuFormatted + " zostały zapisane.");
        }
        //label3
        public bool CzyIstniejeDzisiejszaData(string connectionString)
        {
            DateTime dzisiejszaData = DateTime.Today;

            string query = @"
                            SELECT COUNT(1)
                            FROM ProduktyHistoria1_Temp
                            WHERE CAST(DataZapisu AS DATE) = @dzisiejszaData";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@dzisiejszaData", SqlDbType.Date)).Value = dzisiejszaData;

                    connection.Open();
                    int liczbaRekordow = (int)command.ExecuteScalar();

                    return liczbaRekordow > 0;
                }
            }
        }

        private void FormZapisDzienny_Load(object sender, EventArgs e)
        {
            bool czyIstnieje = CzyIstniejeDzisiejszaData(StringPolaczeniowy);
            if (czyIstnieje)
            {
                label3.Text = "Tak";
            }
            else
            {
                label3.Text = "Nie";
            }
        }
    }
}
