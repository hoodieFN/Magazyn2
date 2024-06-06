using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;
using TestowanieOprogramowania.Services;

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
            if (comboBoxRole.Items.Count > 0)
            {
                comboBoxRole.SelectedIndex = 0; // Domyślnie wybrana jest pierwsza opcja
            }
        }

        private void buttonNadajRole_Click(object sender, EventArgs e)
        {
            string wybranaRola = comboBoxRole.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(wybranaRola))
            {
                MessageBox.Show("Proszę wybrać rolę.");
                return;
            }

            int idUprawnienia = PobierzIdUprawnieniaDlaRoli(wybranaRola);

            if (!CzyRolaRoznaOd(wybranaRola))
            {
                MessageBox.Show("Wybrana rola jest taka sama jak obecna rola użytkownika.");
                return;
            }

            // Aktualizacja roli użytkownika w bazie danych
            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                string query = "UPDATE Uzytkownicy SET IDUprawnienia = @IdUprawnienia WHERE UzytkownikID = @IdUzytkownika";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdUprawnienia", idUprawnienia);
                    cmd.Parameters.AddWithValue("@IdUzytkownika", userId);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Rola została zaktualizowana pomyślnie.");
            this.Close();
        }

        private int PobierzIdUprawnieniaDlaRoli(string rola)
        {
            if (rola == "brak roli") return 0; // Specjalna wartość oznaczająca brak roli

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

        private bool CzyRolaRoznaOd(string wybranaRola)
        {
            string query = @"
                SELECT up.Nazwa_stanowiska 
                FROM dbo.Uprawnienia as up
                JOIN dbo.Uzytkownicy as u ON u.IDUprawnienia = up.UprawnienieID
                WHERE u.UzytkownikID = @UzytkownikID";

            using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UzytkownikID", userId);

                try
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null && result.ToString() != wybranaRola)
                    {
                        return true;
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show($"Błąd SQL: {e.Message}");
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Błąd: {e.Message}");
                }
            }

            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
