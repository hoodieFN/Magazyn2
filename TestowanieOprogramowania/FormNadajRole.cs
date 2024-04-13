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
    public partial class FormNadajRole : Form
    {
        private int userId;
        static string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();
        public FormNadajRole(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void FormNadajRole_Load(object sender, EventArgs e)
        {
            ZaładujRoleDoComboBox();
        }
        private void ZaładujRoleDoComboBox()
        {
            // Pobierz role z bazy danych
            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                string query = "SELECT Nazwa_stanowiska FROM Uprawnienia";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxRole.Items.Add(reader["Nazwa_stanowiska"].ToString());
                        }
                    }
                }
            }
            comboBoxRole.SelectedIndex = 0; // Domyślnie wybrana jest opcja "Brak roli"
        }

        private void buttonNadajRole_Click(object sender, EventArgs e)
        {
            int wybraneIdUzytkownika = userId;
            string wybranaRola = comboBoxRole.SelectedItem.ToString();
            int idUprawnienia = PobierzIdUprawnieniaDlaRoli(wybranaRola);

            // Aktualizacja roli użytkownika w bazie danych
            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                string query = "UPDATE Uzytkownicy SET IDUprawnienia = @IdUprawnienia WHERE UzytkownikID = @IdUzytkownika";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdUprawnienia", idUprawnienia);
                    cmd.Parameters.AddWithValue("@IdUzytkownika", wybraneIdUzytkownika);
                    cmd.ExecuteNonQuery();
                }
            }
            this.Close();
        }
        private int PobierzIdUprawnieniaDlaRoli(string rola)
        {
            if (rola == "Brak roli") return -1; // Specjalna wartość oznaczająca brak roli

            // Pobierz ID uprawnienia dla danej roli
            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                string query = "SELECT UprawnienieID FROM Uprawnienia WHERE Nazwa_stanowiska = @NazwaRoli";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NazwaRoli", rola);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
