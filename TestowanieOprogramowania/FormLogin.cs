using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class FormLogin : Form
    {
        string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();
        public FormLogin()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(FormLogin_FormClosed);
        }
        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            // Załóżmy, że VerifyLogin teraz zwraca enum zamiast bool
            LoginResult loginResult = VerifyLogin(username, password, out int userId);

            switch (loginResult)
            {
                case LoginResult.Success:
                    // Utworzenie sesji użytkownika (prosta demonstracja)
                    UserSession.StartSession(userId);
                    MessageBox.Show("Logowanie pomyślne!");
                    
                    using (var formDodaj = new FormInitial())
                    {
                        this.Hide();
                        var result = formDodaj.ShowDialog();
                    }
                    break;
                case LoginResult.InvalidUsername:
                    MessageBox.Show("Nieprawidłowa nazwa użytkownika.");
                    break;
                case LoginResult.InvalidPassword:
                    MessageBox.Show("Nieprawidłowe hasło.");
                    break;
                case LoginResult.InvalidUsernameAndPassword:
                    MessageBox.Show("Nieprawidłowa nazwa użytkownika i hasło.");
                    break;
                default:
                    MessageBox.Show("Nieoczekiwany błąd logowania.");
                    break;
            }
        }
        public enum LoginResult
        {
            Success,
            InvalidUsername,
            InvalidPassword,
            InvalidUsernameAndPassword,
            UnknownError
        }
        private LoginResult VerifyLogin(string username, string password, out int userId)
        {
            userId = -1; // wartość początkowa oznaczająca, że ID nie zostało znalezione

            using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
            {
                SqlCommand command = new SqlCommand("SELECT UzytkownikID, haslo FROM dbo.Uzytkownicy WHERE Login = @username", connection);
                command.Parameters.AddWithValue("@username", username);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedPassword = reader["haslo"].ToString();
                        userId = reader.GetInt32(0); // przypisz ID użytkownika

                        if (storedPassword == password)
                        {
                            return LoginResult.Success; // Zwróć Success, jeśli hasło się zgadza
                        }
                        else
                        {
                            return LoginResult.InvalidPassword; // Zwróć InvalidPassword, jeśli hasło jest nieprawidłowe
                        }
                    }
                }
            }

            // Jeśli funkcja dotarła do tego miejsca, to znaczy, że nazwa użytkownika nie została znaleziona
            return LoginResult.InvalidUsername;
        }
    }
}

