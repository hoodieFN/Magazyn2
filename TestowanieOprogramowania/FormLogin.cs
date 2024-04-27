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
        private int loginAttempts = 0;
        private DateTime firstAttemptTime;
        private bool isLoginBlocked = false;
        private DateTime unlockTime;
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
            // Sprawdź, czy logowanie jest obecnie zablokowane
            if (isLoginBlocked)
            {
                if (DateTime.Now < unlockTime)
                {
                    var remainingTimeInSeconds = (int)Math.Round((unlockTime - DateTime.Now).TotalSeconds);
                    MessageBox.Show($"Logowanie zablokowane. Spróbuj ponownie za {remainingTimeInSeconds} sekund.");
                    return;
                }
                else
                {
                    // Resetuj stan blokady, jeśli czas blokady minął
                    isLoginBlocked = false;
                    loginAttempts = 0;
                }
            }

            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            // Sprawdź, czy nazwa użytkownika lub hasło są puste
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Wprowadź login i hasło.");
                return; // Przerwij wykonanie metody, jeśli jedno z pól jest puste
            }
            if (loginAttempts == 0 || (DateTime.Now - firstAttemptTime).TotalSeconds > 20)
            {
                // Resetuj licznik prób i czas, jeśli to pierwsza próba lub minęło 20 sekund od pierwszej próby
                firstAttemptTime = DateTime.Now;
                loginAttempts = 1;
            }
            else
            {
                loginAttempts++;

                if (loginAttempts > 5)
                {
                    // Zablokuj logowanie na minutę
                    isLoginBlocked = true;
                    unlockTime = DateTime.Now.AddSeconds(20);
                    MessageBox.Show("Logowanie zablokowane na 20 sekund.");
                    return;
                }
            }

            // Załóżmy, że VerifyLogin teraz zwraca enum zamiast bool
            LoginResult loginResult = VerifyLogin(username, password, out int userId);

            switch (loginResult)
            {
                case LoginResult.Success:
                    // Resetuj stan prób logowania po udanym logowaniu
                    loginAttempts = 0;
                    isLoginBlocked = false;
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
                    MessageBox.Show("Nieprawidłowa nazwa użytkownika lub hasło");
                    break;
                case LoginResult.InvalidPassword:
                    MessageBox.Show("Nieprawidłowa nazwa użytkownika lub hasło");
                    break;
                case LoginResult.InvalidUsernameAndPassword:
                    MessageBox.Show("Nieprawidłowa nazwa użytkownika lub hasło");
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

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        //STARA FUNKCJA RESETOWANIA HASLA
        /*
        private void button_odzyskajhaslo_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Proszę wprowadzić nazwę użytkownika.");
                return;
            }
            else
            {
                var odzyskajhaslo = new OdzyskiwanieHasla();
                odzyskajhaslo.ResetPassword(username);
            }



        }*/

        private void button3_Click(object sender, EventArgs e)
        {
            using (var formReset = new FromResetPas())
            {
                var result = formReset.ShowDialog();
                if (result == DialogResult.OK)
                {

                }
            }
        }
    }
}

