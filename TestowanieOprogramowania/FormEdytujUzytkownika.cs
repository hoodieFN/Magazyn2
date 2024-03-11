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
    public partial class FormEdytujUzytkownika : Form
    {
        private int userId;
        private string conString;
        private string dataSource = "TUF15";

        // Konstruktor przyjmujący userId
        public FormEdytujUzytkownika(int userId)
        {
            InitializeComponent();
            this.userId = userId; // Przypisanie przekazanego userId do zmiennej klasy

            // Przykład ustawienia connectionString - dostosuj do swojej konfiguracji
            this.conString = $"Data Source={dataSource};Initial Catalog=MagazynTestowanieOprogramowania;Integrated Security=True; TrustServerCertificate=True;";

            WczytajDaneUzytkownika();
        }

        private void WczytajDaneUzytkownika()
        {
            string query = "SELECT * FROM dbo.Uzytkownicy WHERE UzytkownikID = @userId";

            using (SqlConnection connection = new SqlConnection(this.conString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", this.userId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {

                        textBoxLogin.Text = reader["Login"].ToString();
                        textBoxImie.Text = reader["Imie"].ToString();
                        textBoxNazwisko.Text = reader["Nazwisko"].ToString();
                        textBoxMiejscowosc.Text = reader["Miejscowosc"].ToString();
                        textBoxKodPocztowy.Text = reader["KodPocztowy"].ToString();
                        textBoxUlica.Text = reader["Ulica"].ToString() ;
                        textBoxNumerPosesji.Text = reader["NumerPosesji"].ToString();
                        textBoxNumerLokalu.Text = reader["NumerLokalu"].ToString();
                        textBoxPESEL.Text = reader["PESEL"].ToString();
                        textBoxDataUrodzenia.Text = reader["DataUrodzenia"].ToString();
                        textBoxPlec.Text = reader["Plec"].ToString();
                        textBoxEmail.Text = reader["Email"].ToString();
                        textBoxNumerTelefonu.Text = reader["NumerTelefonu"].ToString();

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas ładowania danych użytkownika: " + ex.Message);
                }
            }
        }

        private void AktualizujUzytkownikaWBazie(string Login, string Imie, string Nazwisko, string Miejscowosc, string KodPocztowy, string Ulica, string NumerPosesji, string NumerLokalu, string PESEL, string Dataurodzenia, string Plec, string Email, string NumerTelefonu)
        {
            string query = "UPDATE dbo.Uzytkownicy SET Login = @Login, Imie = @Imie, Nazwisko = @Nazwisko, Miejscowosc = @Miejscowosc, KodPocztowy = @KodPocztowy, Ulica=@Ulica, NumerPosesji = @NumerPosesji, NumerLokalu = @NumerLokalu, PESEL = @PESEL, DataUrodzenia = @DataUrodzenia, Plec=@Plec, Email=@Email, NumerTelefonu = @NumerTelefonu WHERE UzytkownikID = @UzytkownikID";

            using (SqlConnection connection = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UzytkownikID", this.userId);
                    cmd.Parameters.AddWithValue("@Login", Login);
                    cmd.Parameters.AddWithValue("@Imie", Imie);
                    cmd.Parameters.AddWithValue("@Nazwisko", Nazwisko);
                    cmd.Parameters.AddWithValue("@Miejscowosc", Miejscowosc);
                    cmd.Parameters.AddWithValue("@KodPocztowy", KodPocztowy);
                    cmd.Parameters.AddWithValue("@Ulica", Ulica);
                    cmd.Parameters.AddWithValue("@NumerPosesji", NumerPosesji);
                    cmd.Parameters.AddWithValue("@NumerLokalu", NumerLokalu);
                    cmd.Parameters.AddWithValue("@PESEL", PESEL);
                    cmd.Parameters.AddWithValue("@DataUrodzenia", Dataurodzenia);
                    cmd.Parameters.AddWithValue("@Plec", Plec);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@NumerTelefonu", NumerTelefonu);



                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void buttonZapisz_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string imie = textBoxImie.Text;
            string nazwisko = textBoxNazwisko.Text;
            string numertelefonu = textBoxNumerTelefonu.Text;
            string miejscowosc = textBoxMiejscowosc.Text;
            string kodPocztowy = textBoxKodPocztowy.Text;
            string ulica = textBoxUlica.Text;
            string numerposesji = textBoxNumerPosesji.Text;
            string pesel = textBoxPESEL.Text;
            string dataurodzenia = textBoxDataUrodzenia.Text;
            string plec = textBoxPlec.Text;
            string email = textBoxEmail.Text;
            string numerlokalu = textBoxNumerLokalu.Text;


            AktualizujUzytkownikaWBazie(login,imie,nazwisko, miejscowosc, kodPocztowy,ulica,numerposesji,numerlokalu,pesel,dataurodzenia,plec,email,numertelefonu);

            MessageBox.Show("Użytkownik został edytowany.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
