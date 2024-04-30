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
    public partial class FormZmienHaslo : Form
    {
        string con = PolaczenieBazyDanych.StringPolaczeniowy();
        public FormZmienHaslo()
        {
            InitializeComponent();
        }
        public void ChangePassword(string oldPassword, string newPassword)
        {
            if (CheckPassword(currentId, oldPassword))
            {
                if (oldPassword == newPassword)
                {
                    MessageBox.Show("Hasło musi się różnić od 3 ostatnich haseł.");
                }
                else if (CheckIfPasswordIsInHistory(currentId, newPassword))
                {
                    MessageBox.Show("Hasło musi się różnić od 3 ostatnich haseł.");
                }
                else
                {
                    UpdatePassword(currentId, newPassword);
                    MessageBox.Show("Hasło zostało zmienione.");
                }
            }
            else
            {
                MessageBox.Show("Podane stare hasło jest nieprawidłowe.");
            }
        }

        int currentId = UserSession.CurrentUserId;
        private void button1_Click(object sender, EventArgs e)
        {
            string oldPassword = textBoxOldPassword.Text; 
            string newPassword = textBoxNewPassword.Text; 
            string new2Password = textBoxNewPassword2.Text;

            if (newPassword.Length < 8)
            {
                MessageBox.Show("Nowe hasło musi mieć co najmniej 8 znaków.");
                return; 
            }

            if (newPassword == new2Password)
            {
                ChangePassword(oldPassword, newPassword);
            }
            else
            {
                MessageBox.Show("Nowe hasła nie są identyczne. Spróbuj ponownie.");
            }
        }
        private bool CheckPassword(int userId, string oldPassword)
        {
            using (var connection = new SqlConnection(con))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT haslo FROM Uzytkownicy WHERE UzytkownikID = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", userId);

                    var storedPassword = command.ExecuteScalar() as string;
                    return storedPassword == oldPassword;
                }
            }
        }

        private void UpdatePassword(int userId, string newPassword)
        {
            using (var connection = new SqlConnection(con))
            {
                connection.Open();
                using (var command = new SqlCommand("UPDATE Uzytkownicy SET haslo = @newPassword WHERE UzytkownikID = @id", connection))
                {
                    command.Parameters.AddWithValue("@newPassword", newPassword);
                    command.Parameters.AddWithValue("@id", userId);
                    command.ExecuteNonQuery();
                }
            }
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
