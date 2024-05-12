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
    public partial class EdytujRodzajeTowarow : Form
    {
        string con = PolaczenieBazyDanych.StringPolaczeniowy();
        public EdytujRodzajeTowarow()
        {
            InitializeComponent();

        }

        private void EdytujRodzajeTowarow_Load(object sender, EventArgs e)
        {
            WczytajRodzajeTowarow();
        }
        public void WczytajRodzajeTowarow()
        {
            string query = "SELECT RodzajTowaruID, NazwaRodzaju FROM RodzajeTowarow";

            using (SqlConnection conn = new SqlConnection(con))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Przypisanie DataTable do DataGridView
                dataGridView1.DataSource = dt;
            }
        }
        public void DodajNazweRodzaju(string nazwaRodzaju)
        {
            string query = "INSERT INTO RodzajeTowarow (NazwaRodzaju) VALUES (@NazwaRodzaju)";

            using (SqlConnection conn = new SqlConnection(con))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NazwaRodzaju", nazwaRodzaju);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UsunZaznaczonyWiersz(int rodZajTowaruId)
        {
            string query = "DELETE FROM RodzajeTowarow WHERE RodzajTowaruID = @RodzajTowaruID";

            using (SqlConnection conn = new SqlConnection(con))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RodzajTowaruID", rodZajTowaruId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nazwaRodzaju = textBoxNazwaTowaru.Text;
            DodajNazweRodzaju(nazwaRodzaju);
            WczytajRodzajeTowarow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rodZajTowaruId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["RodzajTowaruID"].Value);
                UsunZaznaczonyWiersz(rodZajTowaruId);
                WczytajRodzajeTowarow(); // Odświeżanie DataGridView, aby usunąć zaznaczony wiersz
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć wiersz do usunięcia.");
            }
        }
    }
}
