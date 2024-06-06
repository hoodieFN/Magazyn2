using System;
using System.Linq;
using System.Windows.Forms;
using TestowanieOprogramowania.Services;

namespace TestowanieOprogramowania
{
    public partial class FormDodajUzytkownika : Form
    {
        private readonly UserService _userService;

        public FormDodajUzytkownika(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void FormDodajUzytkownika_Load(object sender, EventArgs e)
        {
            textBoxHaslo.UseSystemPasswordChar = true;
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
            DateTime dataUrodzenia = dateTimePicker1.Value;
            string plec = (pesel[pesel.Length - 1] - '0') % 2 == 0 ? "K" : "M"; // określenie płci na podstawie PESEL
            string email = textBoxEmail.Text;
            string numerLokalu = textBoxNumerLokalu.Text;
            string haslo = textBoxHaslo.Text;
            int numerUprawnienia = 0; // domyślne uprawnienie

            if (!CzyPolaSaWypelnione(imie, nazwisko, login, numerTelefonu, miejscowosc, kodPocztowy, ulica, numerPosesji, pesel, dataUrodzenia.ToString(), plec, email, numerLokalu, haslo))
            {
                MessageBox.Show("Istnieje co najmniej jedno niewypełnione pole.");
                return;
            }

            if (login.Length < 8)
            {
                MessageBox.Show("Login musi zawierać co najmniej 8 liter.");
                return;
            }

            if (!WalidujEmail(email) || !WalidujNumerTelefonu(numerTelefonu) || !WalidujDate(dataUrodzenia.ToString()) || !WalidujPlec(plec) || !WalidujHaslo(haslo) || !WalidujPesel(pesel))
            {
                return;
            }

            if (!IsBirthDateMatchingPesel(pesel, dataUrodzenia))
            {
                MessageBox.Show("Data urodzenia z numeru PESEL nie zgadza się z podaną datą urodzenia.");
                return;
            }

            try
            {
                if (_userService.CzyLoginIstnieje(login))
                {
                    MessageBox.Show("Login już istnieje w bazie danych.");
                    return;
                }

                if (_userService.CzyEmailIstnieje(email))
                {
                    MessageBox.Show("Email już istnieje w bazie danych.");
                    return;
                }

                if (_userService.CzyPeselIstnieje(pesel))
                {
                    MessageBox.Show("PESEL już istnieje w bazie danych.");
                    return;
                }

                _userService.DodajUzytkownika(login, imie, nazwisko, numerTelefonu, miejscowosc, kodPocztowy, ulica, numerPosesji, pesel, dataUrodzenia, plec, email, numerLokalu, haslo, numerUprawnienia);

                MessageBox.Show("Użytkownik został dodany.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd: " + ex.Message);
            }
        }

        private bool CzyPolaSaWypelnione(params string[] pola)
        {
            return pola.All(p => !string.IsNullOrWhiteSpace(p));
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

        private bool IsValidPesel(string pesel)
        {
            return pesel.Length == 11 && pesel.All(char.IsDigit);
        }

        private DateTime? ExtractBirthDateFromPesel(string pesel)
        {
            if (!IsValidPesel(pesel))
            {
                return null;
            }

            int year = int.Parse(pesel.Substring(0, 2));
            int month = int.Parse(pesel.Substring(2, 2));
            int day = int.Parse(pesel.Substring(4, 2));

            if (month > 80 && month < 93)
            {
                year += 1800;
                month -= 80;
            }
            else if (month > 0 && month < 13)
            {
                year += 1900;
            }
            else if (month > 20 && month < 33)
            {
                year += 2000;
                month -= 20;
            }
            else if (month > 40 && month < 53)
            {
                year += 2100;
                month -= 40;
            }
            else if (month > 60 && month < 73)
            {
                year += 2200;
                month -= 60;
            }

            if (DateTime.TryParse($"{year}-{month:D2}-{day:D2}", out DateTime birthDate))
            {
                return birthDate;
            }
            return null;
        }

        private bool IsBirthDateMatchingPesel(string pesel, DateTime dateOfBirth)
        {
            DateTime? peselBirthDate = ExtractBirthDateFromPesel(pesel);
            return peselBirthDate.HasValue && peselBirthDate == dateOfBirth.Date;
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

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
