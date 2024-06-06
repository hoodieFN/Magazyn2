using System;
using System.Windows.Forms;
using TestowanieOprogramowania.Services;
using System.Globalization;

namespace TestowanieOprogramowania
{
    public partial class FormEdytujUzytkownika : Form
    {
        private readonly UserService _userService;
        private readonly int _userId;
        private readonly string _connectionString = PolaczenieBazyDanych.StringPolaczeniowy();

        public FormEdytujUzytkownika(int userId, UserService userService)
        {
            InitializeComponent();
            _userId = userId;
            _userService = userService;
            WczytajDaneUzytkownika();
        }

        private void WczytajDaneUzytkownika()
        {
            try
            {
                var userData = _userService.PobierzDaneUzytkownika(_userId);
                if (userData != null)
                {
                    textBoxLogin.Text = userData["Login"].ToString();
                    textBoxImie.Text = userData["Imie"].ToString();
                    textBoxNazwisko.Text = userData["Nazwisko"].ToString();
                    textBoxMiejscowosc.Text = userData["Miejscowosc"].ToString();
                    textBoxKodPocztowy.Text = userData["KodPocztowy"].ToString();
                    textBoxUlica.Text = userData["Ulica"].ToString();
                    textBoxNumerPosesji.Text = userData["NumerPosesji"].ToString();
                    textBoxNumerLokalu.Text = userData["NumerLokalu"].ToString();
                    textBoxPESEL.Text = userData["PESEL"].ToString();
                    textBoxEmail.Text = userData["Email"].ToString();
                    textBoxNumerTelefonu.Text = userData["NumerTelefonu"].ToString();
                    textBoxHaslo.Text = userData["Haslo"].ToString();
                    dateTimePicker1.Value = DateTime.Parse(userData["DataUrodzenia"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas ładowania danych użytkownika: " + ex.Message);
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
            DateTime dataurodzenia = dateTimePicker1.Value;
            string plec = (pesel[9] - '0') % 2 == 0 ? "K" : "M"; // określenie płci na podstawie PESEL
            string email = textBoxEmail.Text;
            string numerlokalu = textBoxNumerLokalu.Text;
            string haslo = textBoxHaslo.Text;

            if (!CzyPolaSaWypelnione(login, imie, nazwisko, numertelefonu, miejscowosc, kodPocztowy, ulica, numerposesji, pesel, dataurodzenia, plec, email, numerlokalu, haslo))
            {
                MessageBox.Show("Istnieje co najmniej jedno niewypełnione pole.");
                return;
            }

            if (login.Length < 8)
            {
                MessageBox.Show("Login musi zawierać co najmniej 8 liter.");
                return;
            }

            if (_userService.CzyLoginIstnieje(login, _userId))
            {
                MessageBox.Show("Login już istnieje w bazie danych.");
                return;
            }

            if (_userService.CzyEmailIstnieje(email, _userId))
            {
                MessageBox.Show("Email już istnieje w bazie danych.");
                return;
            }

            if (_userService.CzyPeselIstnieje(pesel, _userId))
            {
                MessageBox.Show("PESEL już istnieje w bazie danych.");
                return;
            }

            if (!WalidujPesel(pesel) || !WalidujEmail(email) || !WalidujNumerTelefonu(numertelefonu) || !WalidujDate(dataurodzenia) || !WalidujPlec(plec) || !WalidujHaslo(haslo))
            {
                return;
            }

            if (_userService.CzyHasloJestWHistorii(_userId, haslo))
            {
                MessageBox.Show("Hasło musi różnić się od 3 poprzednich haseł.");
                return;
            }

            try
            {
                _userService.AktualizujUzytkownika(_userId, login, imie, nazwisko, miejscowosc, kodPocztowy, ulica, numerposesji, numerlokalu, pesel, dataurodzenia, plec, email, numertelefonu, haslo);
                MessageBox.Show("Użytkownik został edytowany.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas edytowania użytkownika: " + ex.Message);
            }
        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool CzyPolaSaWypelnione(params object[] pola)
        {
            foreach (var pole in pola)
            {
                if (pole == null || (pole is string str && string.IsNullOrWhiteSpace(str)))
                {
                    return false;
                }
            }
            return true;
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
                MessageBox.Show("Numer telefonu może zawierać tylko cyfry.");
                return false;
            }

            return true;
        }

        private bool WalidujDate(DateTime dataUrodzenia)
        {
            if (dataUrodzenia > DateTime.Now)
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

        private bool WalidujHaslo(string haslo)
        {
            if (haslo.Length < 8 || haslo.Length > 15)
            {
                MessageBox.Show("Nowe hasło nie spełnia wymagań: musi mieć od 8 do 15 znaków, zawierać wielką literę, małą literę, cyfrę i jeden ze znaków specjalnych");
                return false;
            }

            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;
            bool hasSpecial = false;

            foreach (char c in haslo)
            {
                if (char.IsUpper(c)) hasUpper = true;
                if (char.IsLower(c)) hasLower = true;
                if (char.IsDigit(c)) hasDigit = true;
                if ("-_!*$&#".Contains(c)) hasSpecial = true;
            }

            if (!hasUpper || !hasLower || !hasDigit || !hasSpecial)
            {
                MessageBox.Show("Nowe hasło nie spełnia wymagań: musi mieć od 8 do 15 znaków, zawierać wielką literę, małą literę, cyfrę i jeden ze znaków specjalnych");
                return false;
            }

            return true; // Wszystkie warunki spełnione
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
    }
}
