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
    public partial class FormDodajRole : Form
    {
        string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();
        public FormDodajRole()
        {
            InitializeComponent();
        }

        private void buttonZapisz_Click(object sender, EventArgs e)
        {
            // Sprawdzenie czy textBoxNazwa nie jest pusty
            if (string.IsNullOrWhiteSpace(textBoxNazwa.Text))
            {
                MessageBox.Show("Podaj nazwę roli.");
                return;
            }

            // Sprawdzenie czy wartość z textBoxNazwa nie pokrywa się z żadną nazwą w tabeli Uprawnienia w rzędzie Nazwa_stanowiska
            string nazwa = textBoxNazwa.Text;
            string sprawdzenieNazwyQuery = "SELECT COUNT(*) FROM dbo.Uprawnienia WHERE Nazwa_stanowiska = @Nazwa";
            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                using (SqlCommand cmdSprawdzenieNazwy = new SqlCommand(sprawdzenieNazwyQuery, conn))
                {
                    cmdSprawdzenieNazwy.Parameters.Add(new SqlParameter("@Nazwa", SqlDbType.NVarChar)).Value = nazwa;

                    int liczbaNazw = (int)cmdSprawdzenieNazwy.ExecuteScalar();

                    if (liczbaNazw > 0)
                    {
                        MessageBox.Show("Nazwa stanowiska już istnieje w bazie danych.");
                        return;
                    }
                }
            }

            // Sprawdzenie czy comboBoxDostep, comboBoxObsluga, comboBoxZarzadzanie, comboBoxNaprawa, comboBoxPakowanie nie są puste
            if (comboBoxListUz.SelectedIndex == -1)
            {
                MessageBox.Show("Pole 'Dostęp do raportów' nie może być puste.");
                return;
            }
            if (comboBoxListUp.SelectedIndex == -1)
            {
                MessageBox.Show("Pole 'Obsługa wózków widłowych' nie może być puste.");
                return;
            }
            if (comboBoxDodUz.SelectedIndex == -1)
            {
                MessageBox.Show("Pole 'Zarządzanie magazynem' nie może być puste.");
                return;
            }
            if (comboBoxUsUz.SelectedIndex == -1)
            {
                MessageBox.Show("Pole 'Naprawa urządzeń' nie może być puste.");
                return;
            }
            if (comboBoxEdUs.SelectedIndex == -1)
            {
                MessageBox.Show("Pole 'Edytowanie Uzytkownikow' nie może być puste.");
                return;
            }
            if (comboBoxDodRol.SelectedIndex == -1)
            {
                MessageBox.Show("Pole 'Dodawanie Roli' nie może być puste.");
                return;
            }
            if (comboBoxUsRol.SelectedIndex == -1)
            {
                MessageBox.Show("Pole 'Usuwanie Roli' nie może być puste.");
                return;
            }
            if (comboBoxEdRol.SelectedIndex == -1)
            {
                MessageBox.Show("Pole 'Edytowanie Roli' nie może być puste.");
                return;
            }
            /*if (comboBoxNadUp.SelectedIndex == -1)
            {
                MessageBox.Show("Pole 'Pakowanie paczek' nie może być puste.");
                return;
            }*/

            // Wstawienie danych do tabeli Uprawnienia w bazie danych
            string query =
                "INSERT INTO dbo.Uprawnienia (Nazwa_stanowiska, DostepDoListyUzytkownikow, DostepDoListyUprawnien, DodawanieUzytkownika, UsuwanieUzytkownika, EdytowanieUzytkownika,DodawanieRoli,UsuwanieRoli,EdytowanieRoli) " +
                "VALUES (@Nazwa, @DostepDoListyUzytkownikow, @DostepDoListyUprawnien, @DodawanieUzytkownika, @UsuwanieUzytkownika, @EdytowanieUzytkownika, @DodawanieRoli, @UsuwanieRoli, @EdytowanieRoli)";

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Nazwa", SqlDbType.NVarChar)).Value = nazwa;
                    cmd.Parameters.Add(new SqlParameter("@DostepDoListyUzytkownikow", SqlDbType.NVarChar)).Value = comboBoxListUz.SelectedItem.ToString();
                    cmd.Parameters.Add(new SqlParameter("@DostepDoListyUprawnien", SqlDbType.NVarChar)).Value = comboBoxListUp.SelectedItem.ToString();
                    cmd.Parameters.Add(new SqlParameter("@DodawanieUzytkownika", SqlDbType.NVarChar)).Value = comboBoxDodUz.SelectedItem.ToString();
                    cmd.Parameters.Add(new SqlParameter("@UsuwanieUzytkownika", SqlDbType.NVarChar)).Value = comboBoxUsUz.SelectedItem.ToString();
                    cmd.Parameters.Add(new SqlParameter("@EdytowanieUzytkownika", SqlDbType.NVarChar)).Value = comboBoxEdUs.SelectedItem.ToString();
                    cmd.Parameters.Add(new SqlParameter("@DodawanieRoli", SqlDbType.NVarChar)).Value = comboBoxDodRol.SelectedItem.ToString();
                    cmd.Parameters.Add(new SqlParameter("@UsuwanieRoli", SqlDbType.NVarChar)).Value = comboBoxUsRol.SelectedItem.ToString();
                    cmd.Parameters.Add(new SqlParameter("@EdytowanieRoli", SqlDbType.NVarChar)).Value = comboBoxEdRol.SelectedItem.ToString();
                    //cmd.Parameters.Add(new SqlParameter("@PakowaniePaczek", SqlDbType.NVarChar)).Value = comboBoxNadUp.SelectedItem.ToString();

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Rola zostały pomyślnie dodana.");

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
