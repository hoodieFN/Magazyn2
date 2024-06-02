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
    public partial class FormKoszykInfo : Form
    {
        private string con = PolaczenieBazyDanych.StringPolaczeniowy();
        public FormKoszykInfo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormKoszykInfo_Load(object sender, EventArgs e)
        {

        }
        public void LoadProductDetails(string nazwaTowaru)
        {
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Koszyk WHERE NazwaTowaru = @NazwaTowaru", conn);
                cmd.Parameters.AddWithValue("@NazwaTowaru", nazwaTowaru);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable koszykTable = new DataTable();
                adapter.Fill(koszykTable);

                if (koszykTable.Rows.Count > 0)
                {
                    DataRow produkt = koszykTable.Rows[0];

                    // Wyświetlanie informacji w polach tekstowych
                    labelNazwaTowaru.Text = produkt["NazwaTowaru"].ToString();
                    labelIloscTowaru.Text = Convert.ToDecimal(produkt["IloscTowaru"]).ToString();
                    label3.Text = Convert.ToDecimal(produkt["CenaZaTowar"]).ToString();
                    labelNazwaKlienta.Text = produkt["NazwaKlienta"].ToString();
                    labelMiejscowosc.Text = produkt["Miejscowosc"].ToString();
                    labelKodPocztowy.Text = produkt["KodPocztowy"].ToString();
                    labelUlica.Text = produkt["Ulica"].ToString();
                    labelNrDomu.Text = produkt["NrDomu"].ToString();
                    labelDataSprzedazy.Text = Convert.ToDateTime(produkt["DataSprzedazy"]).ToString();
                    // Wyświetlanie pozostałych informacji, jeśli potrzebne
                }
                else
                {
                    MessageBox.Show("Nie znaleziono produktu w koszyku.");
                }
            }
        }
    }
}
