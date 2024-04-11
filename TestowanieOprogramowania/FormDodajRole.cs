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
            if (comboBoxDostep.SelectedIndex == -1)
            {
                MessageBox.Show("Pole 'Dostęp do raportów' nie może być puste.");
                return;
            }
            if (comboBoxObsluga.SelectedIndex == -1)
            {
                MessageBox.Show("Pole 'Obsługa wózków widłowych' nie może być puste.");
                return;
            }
            if (comboBoxZarzadzanie.SelectedIndex == -1)
            {
                MessageBox.Show("Pole 'Zarządzanie magazynem' nie może być puste.");
                return;
            }
            if (comboBoxNaprawa.SelectedIndex == -1)
            {
                MessageBox.Show("Pole 'Naprawa urządzeń' nie może być puste.");
                return;
            }
            if (comboBoxPakowanie.SelectedIndex == -1)
            {
                MessageBox.Show("Pole 'Pakowanie paczek' nie może być puste.");
                return;
            }

            // Wstawienie danych do tabeli Uprawnienia w bazie danych
            string query =
                "INSERT INTO dbo.Uprawnienia (Nazwa_stanowiska, DostepDoRaportow, ObslugaWozkowWidlowych, ZarzadzanieMagazynem, NaprawaUrzadzen, PakowaniePaczek) " +
                "VALUES (@Nazwa, @DostepDoRaportow, @ObslugaWozkowWidlowych, @ZarzadzanieMagazynem, @NaprawaUrzadzen, @PakowaniePaczek)";

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Nazwa", SqlDbType.NVarChar)).Value = nazwa;
                    cmd.Parameters.Add(new SqlParameter("@DostepDoRaportow", SqlDbType.NVarChar)).Value = comboBoxDostep.SelectedItem.ToString();
                    cmd.Parameters.Add(new SqlParameter("@ObslugaWozkowWidlowych", SqlDbType.NVarChar)).Value = comboBoxObsluga.SelectedItem.ToString();
                    cmd.Parameters.Add(new SqlParameter("@ZarzadzanieMagazynem", SqlDbType.NVarChar)).Value = comboBoxZarzadzanie.SelectedItem.ToString();
                    cmd.Parameters.Add(new SqlParameter("@NaprawaUrzadzen", SqlDbType.NVarChar)).Value = comboBoxNaprawa.SelectedItem.ToString();
                    cmd.Parameters.Add(new SqlParameter("@PakowaniePaczek", SqlDbType.NVarChar)).Value = comboBoxPakowanie.SelectedItem.ToString();

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
