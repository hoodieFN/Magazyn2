using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TestowanieOprogramowania
{
    public partial class FormEdytujUzytkownika : Form
    {
        private int userId;
        string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();

        public FormEdytujUzytkownika(int userId)
        {
            InitializeComponent();
            this.userId = userId;


            WczytajDaneUzytkownika();
        }

        private void WczytajDaneUzytkownika()
        {
            string query = "SELECT * FROM dbo.Uzytkownicy WHERE UzytkownikID = @userId";

            using (SqlConnection connection = new SqlConnection(this.StringPolaczeniowy))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", this.userId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string data = reader["DataUrodzenia"].ToString();
                        string dataWyjsciowa = ZamienFormatDaty(data);
                        DateTime dataConverted = DateTime.Parse(dataWyjsciowa);

                        textBoxLogin.Text = reader["Login"].ToString();
                        textBoxImie.Text = reader["Imie"].ToString();
                        textBoxNazwisko.Text = reader["Nazwisko"].ToString();
                        textBoxMiejscowosc.Text = reader["Miejscowosc"].ToString();
                        textBoxKodPocztowy.Text = reader["KodPocztowy"].ToString();
                        textBoxUlica.Text = reader["Ulica"].ToString();
                        textBoxNumerPosesji.Text = reader["NumerPosesji"].ToString();
                        textBoxNumerLokalu.Text = reader["NumerLokalu"].ToString();
                        textBoxPESEL.Text = reader["PESEL"].ToString();
                        // textBoxDataUrodzenia.Text = dataWyjsciowa;
                        //textBoxPlec.Text = reader["Plec"].ToString();
                        textBoxEmail.Text = reader["Email"].ToString();
                        textBoxNumerTelefonu.Text = reader["NumerTelefonu"].ToString();
                        textBoxHaslo.Text = reader["haslo"].ToString();

                        dateTimePicker1.Value = dataConverted;

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas ładowania danych użytkownika: " + ex.Message);
                }
            }
        }

        private void AktualizujUzytkownikaWBazie(string Login, string Imie, string Nazwisko, string Miejscowosc, string KodPocztowy, string Ulica, string NumerPosesji, string NumerLokalu, string PESEL, string Dataurodzenia, string Plec, string Email, string NumerTelefonu, string haslo)
        {
            if (string.IsNullOrWhiteSpace(Imie) || string.IsNullOrWhiteSpace(Nazwisko) || string.IsNullOrWhiteSpace(Login) ||
            string.IsNullOrWhiteSpace(Miejscowosc) || string.IsNullOrWhiteSpace(KodPocztowy) || string.IsNullOrWhiteSpace(Ulica) ||
            string.IsNullOrWhiteSpace(NumerPosesji) || string.IsNullOrWhiteSpace(PESEL) || string.IsNullOrWhiteSpace(Dataurodzenia) ||
            string.IsNullOrWhiteSpace(Plec) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(NumerTelefonu) ||
            string.IsNullOrWhiteSpace(NumerLokalu))
            {
                MessageBox.Show("Istnieje co najmniej jendo niewypełnione pole.");
                return;
            }
            //b. Login –  minimum 6 znaków
            if (Login.Length < 8)
            {
                MessageBox.Show("Login musi zawierać co najmniej 8 liter.");
                return;
            }
            //c. PESEL:
            if (WalidujPesel(PESEL) == false)
            {
                return;
            }
            //d. Adres e-mail:
            if (WalidujEmail(Email) == false)
            {
                return;
            }
            //e.Numer telefonu: 9 cyfr
            if (WalidujNumerTelefonu(NumerTelefonu) == false)
            {
                return;
            }
            //data
            if (!WalidujDate(Dataurodzenia))
            {
                return;
            }
            //plec K albo M
            if (!WalidujPlec(Plec))
            {
                return;
            }
            //haslo co najmniej 5 znakow
            if (WalidujHaslo(haslo) == false)
            {
                return;
            }

            //Dodając @UzytkownikID wykluczamy obecnego uzytkownika ze sprawdzania tak abysmy mogli po prostu zostawic taki sam login jak byl itp.
            string sprawdzenieLoginuQuery = "SELECT COUNT(*) FROM dbo.Uzytkownicy WHERE Login = @Login AND UzytkownikID <> @UzytkownikID";
            string sprawdzenieEmailuQuery = "SELECT COUNT(*) FROM dbo.Uzytkownicy WHERE Email = @Email AND UzytkownikID <> @UzytkownikID";
            string sprawdzeniePeselQuery = "SELECT COUNT(*) FROM dbo.Uzytkownicy WHERE PESEL = @PESEL AND UzytkownikID <> @UzytkownikID";

            string query = "UPDATE dbo.Uzytkownicy SET Login = @Login, Imie = @Imie, Nazwisko = @Nazwisko, Miejscowosc = @Miejscowosc, KodPocztowy = @KodPocztowy, Ulica=@Ulica, NumerPosesji = @NumerPosesji, NumerLokalu = @NumerLokalu, PESEL = @PESEL, DataUrodzenia = @DataUrodzenia, Plec=@Plec, Email=@Email, NumerTelefonu = @NumerTelefonu, Haslo = @haslo WHERE UzytkownikID = @UzytkownikID";

            using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
            {
                //Sprawdź czy istnieje juz taki login w bazie
                connection.Open();
                using (SqlCommand cmdSprawdzenieLoginu = new SqlCommand(sprawdzenieLoginuQuery, connection))
                {
                    cmdSprawdzenieLoginu.Parameters.AddWithValue("@UzytkownikID", this.userId);
                    cmdSprawdzenieLoginu.Parameters.Add(new SqlParameter("@Login", SqlDbType.NVarChar)).Value = Login;

                    int liczbaLoginow = (int)cmdSprawdzenieLoginu.ExecuteScalar();

                    if (liczbaLoginow > 0)
                    {
                        MessageBox.Show("Login już istnieje w bazie danych.");
                        connection.Close();
                        return;
                    }
                }
                //Sprawdź czy istnieje juz taki login w bazie
                using (SqlCommand cmdSprawdzenieEmailu = new SqlCommand(sprawdzenieEmailuQuery, connection))
                {
                    cmdSprawdzenieEmailu.Parameters.AddWithValue("@UzytkownikID", this.userId);
                    cmdSprawdzenieEmailu.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar)).Value = Email;

                    int liczbaEmaili = (int)cmdSprawdzenieEmailu.ExecuteScalar();

                    if (liczbaEmaili > 0)
                    {
                        MessageBox.Show("Email już istnieje w bazie danych.");
                        connection.Close();
                        return;
                    }
                }
                //Sprawdź czy PESEL istnieje już w bazie
                using (SqlCommand cmdSprawdzeniePesel = new SqlCommand(sprawdzeniePeselQuery, connection))
                {
                    cmdSprawdzeniePesel.Parameters.AddWithValue("@UzytkownikID", this.userId);
                    cmdSprawdzeniePesel.Parameters.Add(new SqlParameter("@PESEL", SqlDbType.NVarChar)).Value = PESEL;

                    int liczbaPeseli = (int)cmdSprawdzeniePesel.ExecuteScalar();

                    if (liczbaPeseli > 0)
                    {
                        MessageBox.Show("PESEL już istnieje w bazie danych.");
                        connection.Close();
                        return;
                    }
                }

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
                    cmd.Parameters.AddWithValue("@Haslo", haslo);




                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Użytkownik został edytowany.");
            this.DialogResult = DialogResult.OK;
            this.Close();
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
            string dataurodzenia = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string plec = (pesel[9] - '0') % 2 == 0 ? "K" : "M"; // określenie płci na podstawie PESEL
            string email = textBoxEmail.Text;
            string numerlokalu = textBoxNumerLokalu.Text;
            string haslo = textBoxHaslo.Text;


            AktualizujUzytkownikaWBazie(login, imie, nazwisko, miejscowosc, kodPocztowy, ulica, numerposesji, numerlokalu, pesel, dataurodzenia, plec, email, numertelefonu, haslo);


        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormEdytujUzytkownika_Load(object sender, EventArgs e)
        {
            textBoxPESEL.KeyPress += textBoxPESEL_KeyPress;
            textBoxPESEL.KeyDown += textBoxPESEL_KeyDown;
            textBoxPESEL.MouseDown += textBoxPESEL_MouseDown;
            textBoxHaslo.UseSystemPasswordChar = true;
        }
        public static string ZamienFormatDaty(string dataWejsciowa)
        {
            DateTime data = DateTime.ParseExact(dataWejsciowa, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            return data.ToString("yyyy-MM-dd");
        }
        private bool WalidujPesel(string pesel)
        {
            if (pesel.Length != 11 || !pesel.All(char.IsDigit))
            {
                MessageBox.Show("PESEL musi składać się z 11 cyfr.");
                return false;
            }

            int rok = Convert.ToInt32(pesel.Substring(0, 2));
            int miesiac = Convert.ToInt32(pesel.Substring(2, 2));
            int dzien = Convert.ToInt32(pesel.Substring(4, 2));

            miesiac %= 20;

            if (miesiac < 1 || miesiac > 12 || dzien < 1 || dzien > 31)
            {
                MessageBox.Show("Data urodzenia w PESEL jest nieprawidłowa.");
                return false;
            }

            //Niezaimplementowane

            //ii.	Przedostatnia cyfra odpowiada płci: 
            // 1.Nieparzyste – kobieta
            //2.Parzyste i zero – mężczyźni

            /*
            int plecNumer = Convert.ToInt32(pesel[9].ToString());
            if ((plec == "Kobieta" && plecNumer % 2 == 0) || (plec == "Mężczyzna" && plecNumer % 2 != 0))
            {
                MessageBox.Show("Nieprawidłowy numer PESEL dla podanej płci.");
                return false;
            }
            */

            int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int sumaKontrolna = 0;

            for (int i = 0; i < wagi.Length; i++)
            {
                sumaKontrolna += wagi[i] * Convert.ToInt32(pesel[i].ToString());
            }

            int cyfraKontrolna = (10 - sumaKontrolna % 10) % 10;
            if (cyfraKontrolna != Convert.ToInt32(pesel[10].ToString()))
            {
                MessageBox.Show("Nieprawidłowa cyfra kontrolna PESEL.");
                return false;
            }


            return true;
        }
        private bool WalidujEmail(string email)
        {
            if (email.Split('@').Length - 1 != 1)
            {
                MessageBox.Show("Adres e-mail musi zawierać dokładnie jeden znak '@'.");
                return false;
            }

            if (email.Length > 255)
            {
                MessageBox.Show("Adres e-mail może zawierać maksymalnie 255 znaków.");
                return false;
            }

            //Dodac czy email juz istnieje w bazie

            return true;
        }
        private bool WalidujNumerTelefonu(string numerTelefonu)
        {
            if (numerTelefonu.Length != 9)
            {
                MessageBox.Show("Numer telefonu musi składać się z dokładnie 9 cyfr.");
                return false;
            }
            if (!long.TryParse(numerTelefonu, out _))
            {
                MessageBox.Show("Numer telefonu może zawierać tylko cyfry");
                return false;
            }

            return true;
        }
        private bool WalidujDate(string dataUrodzenia)
        {
            if (!DateTime.TryParse(dataUrodzenia, out DateTime parsedDate))
            {
                MessageBox.Show("Podana data urodzenia jest nieprawidłowa. Użyj formatu RRRR-MM-DD.");
                return false;
            }

            if (parsedDate > DateTime.Now)
            {
                MessageBox.Show("Data urodzenia nie może być w przyszłości.");
                return false;
            }

            return true;
        }

        private bool WalidujPlec(string plec)
        {
            if (plec != "K" && plec != "M")
            {
                MessageBox.Show("Płeć musi być określona jako 'K' dla kobiety lub 'M' dla mężczyzny.");
                return false;
            }

            return true;
        }

        private void textBoxNumerTelefonu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBoxPESEL_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void textBoxPESEL_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            // Jeśli długość tekstu wynosi 9, zablokuj Backspace i Delete, aby użytkownik nie mógł usunąć żadnych znaków
            if (tb.Text.Length == 9 && (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete))
            {
                e.Handled = true; // Zapobiegaj dalszemu przetwarzaniu zdarzenia
                e.SuppressKeyPress = true; // Zapobiegaj generowaniu zdarzenia KeyPress
            }
        }

        private void textBoxPESEL_MouseDown(object sender, MouseEventArgs e)
        {
            // Przesuń kursor na koniec tekstu, jeśli kliknięto myszką
            TextBox tb = (TextBox)sender;
            tb.SelectionStart = tb.Text.Length;
            tb.SelectionLength = 0;

        }
        private bool WalidujHaslo(string haslo)
        {
            if (haslo.Length >= 5)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Hasło musi zawierać co najmniej 5 znaków.");
                return false;
            }
        }
    }
}
