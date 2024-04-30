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
    public partial class FormZmianaPoResecie : Form
    {
        string con = PolaczenieBazyDanych.StringPolaczeniowy();
        static string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();
        public FormZmianaPoResecie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string hasloZMaila = textBoxHasloZMaila.Text; // Obecne hasło użytkownika
            string noweHaslo = textBoxNewPassword.Text;
            string nowe2Haslo = textBoxNewPassword2.Text;

            int userID = UserSession.CurrentUserId;
            if(CheckIfPasswordIsInHistory(userID, noweHaslo))
            {
                MessageBox.Show("Hasło musi się różnić od 3 ostatnich haseł.");
                return;
            }
            // Sprawdzenie czy jakiekolwiek pole jest puste
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(hasloZMaila) ||
                string.IsNullOrEmpty(noweHaslo) || string.IsNullOrEmpty(nowe2Haslo))
            {
                MessageBox.Show("Nie udało się zmienić hasła. Sprawdź poprawność danych (wszystkie pola muszą być wypełnione)");
                return;
            }

            if (noweHaslo.Length < 8)
            {
                MessageBox.Show("Nowe hasło musi zawierać przynajmniej 8 znaków.");
                return;
            }

            if (noweHaslo != nowe2Haslo)
            {
                MessageBox.Show("Podane hasła nie są identyczne.");
                return;
            }

            try
            {
                if (ZmienHaslo(login, hasloZMaila, noweHaslo))
                {
                    MessageBox.Show("Hasło zostało zmienione.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nie udało się zmienić hasła. Sprawdź poprawność danych.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message);
            }
        }
        private bool ZmienHaslo(string userLogin, string currentPassword, string newPassword)
        {
            using (var con = new SqlConnection(StringPolaczeniowy))
            {
                // Najpierw sprawdzamy, czy obecne hasło użytkownika jest poprawne
                var cmd = new SqlCommand("SELECT haslo FROM Uzytkownicy WHERE Login = @Login", con);
                cmd.Parameters.AddWithValue("@Login", userLogin);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string existingPassword = reader["haslo"].ToString();
                        if (existingPassword != currentPassword)
                        {
                            return false; // Obecne hasło nie zgadza się z hasłem w bazie
                        }
                    }
                    else
                    {
                        return false; // Nie znaleziono użytkownika
                    }
                }

                // Jeśli obecne hasło jest poprawne, aktualizujemy hasło na nowe
                var updateCmd = new SqlCommand("UPDATE Uzytkownicy SET haslo = @newPassword, changePass = 0 WHERE Login = @Login", con);
                updateCmd.Parameters.AddWithValue("@newPassword", newPassword);
                updateCmd.Parameters.AddWithValue("@Login", userLogin);
                int rowsAffected = updateCmd.ExecuteNonQuery();
                return rowsAffected > 0; // Jeśli zaktualizowano przynajmniej jeden rekord, zwraca true
            }
        }

        private void FormZmianaPoResecie_Load(object sender, EventArgs e)
        {

        }
        private bool CheckIfPasswordIsInHistory(int userId, string newPassword)
        {
            using (var connection = new SqlConnection(con))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT haslo1, haslo2, haslo3 FROM HistoriaHasel WHERE UzytkownikID = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string historyPassword1 = reader["haslo1"] as string;
                            string historyPassword2 = reader["haslo2"] as string;
                            string historyPassword3 = reader["haslo3"] as string;

                            return (newPassword == historyPassword1 || newPassword == historyPassword2 || newPassword == historyPassword3);
                        }
                    }
                }
            }
            return false;
        }
    }
}
