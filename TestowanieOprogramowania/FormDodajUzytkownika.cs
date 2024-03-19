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
    public partial class FormDodajUzytkownika : Form
    {
        string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();
        public FormDodajUzytkownika()
        {
            InitializeComponent();
        }

        private void FormDodajUzytkownika_Load(object sender, EventArgs e)
        {

        }

        private void DodajUzytkownikaDoBazy(string imie, string nazwisko, string login, string numerTelefonu, string miejscowosc, string kodPocztowy,
            string ulica, string numerPosesji, string pesel, string dataUrodzenia, string plec, string email, string numerLokalu, string haslo)
        {
            if (string.IsNullOrWhiteSpace(imie) || string.IsNullOrWhiteSpace(nazwisko) || string.IsNullOrWhiteSpace(login) ||
            string.IsNullOrWhiteSpace(miejscowosc) || string.IsNullOrWhiteSpace(kodPocztowy) || string.IsNullOrWhiteSpace(ulica) ||
            string.IsNullOrWhiteSpace(numerPosesji) || string.IsNullOrWhiteSpace(pesel) || string.IsNullOrWhiteSpace(dataUrodzenia) ||
            string.IsNullOrWhiteSpace(plec) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(numerTelefonu) ||
            string.IsNullOrWhiteSpace(numerLokalu) || string.IsNullOrWhiteSpace(haslo))
            {
                MessageBox.Show("Istnieje co najmniej jendo niewypełnione pole.");
                return;
            }
            //b. Login –  minimum 6 znaków
            if (login.Length < 8)
            {
                MessageBox.Show("Login musi zawierać co najmniej 8 liter.");
                return;
            }
            //c. PESEL:
            if (WalidujPesel(pesel) == false)
            {
                MessageBox.Show("Błędny PESEL");
                return;
            }
            //d. Adres e-mail:
            if (WalidujEmail(email) == false)
            {
                MessageBox.Show("Błędny e-mail");
                return;
            }
            //e.Numer telefonu: 9 cyfr
            if (WalidujNumerTelefonu(numerTelefonu) == false)
            {
                MessageBox.Show("Błędny numer telefonu");
                return;
            }
            //data
            if (!WalidujDate(dataUrodzenia))
            {
                return;
            }
            //plec K albo M
            if (!WalidujPlec(plec))
            {
                return;
            }


            string query =
                "INSERT INTO dbo.Uzytkownicy (Login, Imie, Nazwisko, NumerTelefonu, Miejscowosc, KodPocztowy, Ulica, NumerPosesji, Pesel, DataUrodzenia, Plec, Email, NumerLokalu, Haslo) "
                +
                "VALUES (@Login, @Imie, @Nazwisko, @NumerTelefonu, @Miejscowosc, @KodPocztowy, @Ulica, @NumerPosesji, @Pesel, @DataUrodzenia, @Plec, @Email, @NumerLokalu, @Haslo)";

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Login", SqlDbType.NVarChar)).Value = login;
                    cmd.Parameters.Add(new SqlParameter("@Imie", SqlDbType.NVarChar)).Value = imie;
                    cmd.Parameters.Add(new SqlParameter("@Nazwisko", SqlDbType.NVarChar)).Value = nazwisko;
                    cmd.Parameters.Add(new SqlParameter("@NumerTelefonu", SqlDbType.NVarChar)).Value = numerTelefonu;
                    cmd.Parameters.Add(new SqlParameter("@Miejscowosc", SqlDbType.NVarChar)).Value = miejscowosc;
                    cmd.Parameters.Add(new SqlParameter("@KodPocztowy", SqlDbType.NVarChar)).Value = kodPocztowy;
                    cmd.Parameters.Add(new SqlParameter("@Ulica", SqlDbType.NVarChar)).Value = ulica;
                    cmd.Parameters.Add(new SqlParameter("@NumerPosesji", SqlDbType.NVarChar)).Value = numerPosesji;
                    cmd.Parameters.Add(new SqlParameter("@PESEL", SqlDbType.NVarChar)).Value = pesel;
                    cmd.Parameters.Add(new SqlParameter("@DataUrodzenia", SqlDbType.DateTime)).Value = dataUrodzenia;
                    cmd.Parameters.Add(new SqlParameter("@Plec", SqlDbType.NVarChar)).Value = plec;
                    cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar)).Value = email;
                    cmd.Parameters.Add(new SqlParameter("@NumerLokalu", SqlDbType.NVarChar)).Value = numerLokalu;
                    cmd.Parameters.Add(new SqlParameter("@Haslo", SqlDbType.NVarChar)).Value = haslo;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            MessageBox.Show("Użytkownik został dodany.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonZapisz_Click(object sender, EventArgs e)
        {
            string imie = textBoxImie.Text;
            string nazwisko = textBoxNazwisko.Text;
            string login = textBoxLogin.Text;
            string numerTelefonu = textBoxNumerTelefonu.Text;
            string miejscowosc = textBoxMiejscowosc.Text;
            string kodPocztowy = textBoxKodPocztowy.Text;
            string ulica = textBoxUlica.Text;
            string numerPosesji = textBoxNumerPosesji.Text;
            string pesel = textBoxPesel.Text;
            string dataUrodzenia = textBoxDataUrodzenia.Text;
            string plec = textBoxPlec.Text;
            string email = textBoxEmail.Text;
            string numerLokalu = textBoxNumerLokalu.Text;
            string haslo = textBoxHaslo.Text;

            DodajUzytkownikaDoBazy(imie, nazwisko, login, numerTelefonu, miejscowosc, kodPocztowy, ulica, numerPosesji, pesel, dataUrodzenia, plec, email, numerLokalu, haslo);
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
            if ((plec == "K" && plecNumer % 2 == 0) || (plec == "M" && plecNumer % 2 != 0))
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
            if (numerTelefonu.Length != 9 || !long.TryParse(numerTelefonu, out _))
            {
                MessageBox.Show("Numer telefonu musi składać się z dokładnie 9 cyfr.");
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
    }
}
