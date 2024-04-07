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
    public partial class FormInitial : Form
    {
        public FormInitial()
        {

            InitializeComponent();
            labelWitajUzytkowniku.Text = $"Witaj, {GetUserName(UserSession.CurrentUserId)}";
            this.FormClosing += new FormClosingEventHandler(FormInitial_FormClosing);
        }
        private void FormInitial_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Wywołaj metodę odpowiedzialną za wylogowanie użytkownika
            UserSession.EndSession();

            // Możesz także zdecydować się na wyświetlenie formularza logowania po wylogowaniu,
            // ale to zależy od logiki Twojej aplikacji - czy ma się ona zakończyć, czy wrócić do logowania.
            FormLogin loginForm = new FormLogin();
            loginForm.Show();
            // Zamiast zamykać formularz, możesz ukryć FormInitial, jeśli planujesz powrócić do tego formularza
            // Po ponownym zalogowaniu. Jeśli aplikacja ma być zamknięta, to poniższą linię można usunąć.
            this.Hide();

            MessageBox.Show("Nastąpiło wylogowanie");
        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }
        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();

        }

        private void buttonZarzadzaj_Click(object sender, EventArgs e)
        {
            loadform(new Form1());
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            //loadform(new FormDodajUzytkownika());
        }



        private void panelslide_Paint(object sender, PaintEventArgs e)
        {

        }
        public string GetUserName(int userId)
        {
            string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();
            string userName = "";

            using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
            {
                string sqlQuery = "SELECT Imie FROM dbo.Uzytkownicy WHERE UzytkownikID = @UzytkownikID";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Ustaw parametry zapytania
                    command.Parameters.AddWithValue("@UzytkownikID", userId);

                    try
                    {
                        connection.Open();
                        // Wykonaj zapytanie i odbierz wynik
                        userName = (string)command.ExecuteScalar();
                    }
                    catch (SqlException e)
                    {
                        // W przypadku wystąpienia błędu SQL, obsłuż go tutaj
                        Console.WriteLine("Błąd SQL: " + e.Message);
                    }
                    // Zamknięcie połączenia jest obsługiwane przez blok using
                }
            }

            return userName;
        }
        public string GetUserLogin(int userId)
        {
            string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();
            string userlogin = "";

            using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
            {
                string sqlQuery = "SELECT Login FROM dbo.Uzytkownicy WHERE UzytkownikID = @UzytkownikID";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Ustaw parametry zapytania
                    command.Parameters.AddWithValue("@UzytkownikID", userId);

                    try
                    {
                        connection.Open();
                        // Wykonaj zapytanie i odbierz wynik
                        userlogin = (string)command.ExecuteScalar();
                    }
                    catch (SqlException e)
                    {
                        // W przypadku wystąpienia błędu SQL, obsłuż go tutaj
                        Console.WriteLine("Błąd SQL: " + e.Message);
                    }
                    // Zamknięcie połączenia jest obsługiwane przez blok using
                }
            }

            return userlogin;
        }


        private void buttonLogout_Click(object sender, EventArgs e)
        {
            // Wyświetl pytanie z potwierdzeniem
            var confirmationResult = MessageBox.Show("Czy na pewno chcesz się wylogować?", "Potwierdzenie wylogowania", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmationResult == DialogResult.Yes)
            {
                // Użytkownik potwierdził chęć wylogowania
                UserSession.EndSession();
                this.Hide();

                // Pokaż formularz logowania
                FormLogin loginForm = new FormLogin();
                loginForm.FormClosed += (s, args) => this.Close(); // Zamknij aplikację, gdy formularz logowania zostanie zamknięty
                loginForm.Show();
            }
            // Jeśli użytkownik wybierze 'Nie', to nic nie rób
        }

        private void buttonListaUprawnien_Click(object sender, EventArgs e)
        {
            
           string login = GetUserLogin(UserSession.CurrentUserId);
                int idUprawnieniaUzytkownika = PobierzIDUprawnienia(login);

                if (idUprawnieniaUzytkownika == 1)
                {
                    // Użytkownik ma uprawnienie ID = 1 - nic się nie dzieje
                    loadform(new FormUprawnienia());
                }
                else 
                {
                    // Użytkownik nie ma wymaganego uprawnienia - wyświetl komunikat
                    MessageBox.Show("Brak wymaganych uprawnień do wyświetlenia listy uprawnień.", "Brak uprawnień", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        public int PobierzIDUprawnienia(string login)
        {
            int idUprawnienia = 0; // Domyślna wartość
            string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();


            using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
            {
                string query = "SELECT IDUprawnienia FROM Uzytkownicy WHERE Login = @Login";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Login", login);

                try
                {
                    connection.Open();
                    idUprawnienia = (int?)command.ExecuteScalar() ?? 0;
                }
                catch (Exception ex)
                {
                    // Obsługa błędów, np. logowanie błędu
                    Console.WriteLine("Błąd podczas pobierania ID uprawnienia użytkownika: " + ex.Message);
                }
            }

            return idUprawnienia;
        }
    }

   



}


