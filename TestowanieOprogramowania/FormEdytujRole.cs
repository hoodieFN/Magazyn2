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
    public partial class FormEdytujRole : Form
    {

        private string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();
        private int roleId;

        public FormEdytujRole(int roleId)
        {
            InitializeComponent();
            this.roleId = roleId;
            WczytajDaneRoli();
        }

        private void WczytajDaneRoli()
        {
            string query = "SELECT [Nazwa_stanowiska], [DostepDoRaportow], [ObslugaWozkowWidlowych], [ZarzadzanieMagazynem], [NaprawaUrzadzen], [PakowaniePaczek] FROM dbo.Uprawnienia WHERE UprawnienieID = @roleId";

            using (SqlConnection connection = new SqlConnection(this.StringPolaczeniowy))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@roleId", this.roleId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        textBoxNazwa.Text = reader["Nazwa_stanowiska"].ToString();
                        comboBoxDostep.SelectedItem = reader["DostepDoRaportow"].ToString();
                        comboBoxObsluga.SelectedItem = reader["ObslugaWozkowWidlowych"].ToString();
                        comboBoxZarzadzanie.SelectedItem = reader["ZarzadzanieMagazynem"].ToString();
                        comboBoxNaprawa.SelectedItem = reader["NaprawaUrzadzen"].ToString();
                        comboBoxPakowanie.SelectedItem = reader["PakowaniePaczek"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas ładowania danych roli: " + ex.Message);
                }
            }
        }

        private void buttonZapisz_Click(object sender, EventArgs e)
        {
            // Pobierz dane z formularza
            string nazwaRoli = textBoxNazwa.Text;
            string dostepDoRaportow = comboBoxDostep.SelectedItem.ToString();
            string obslugaWozkowWidlowych = comboBoxObsluga.SelectedItem.ToString();
            string zarzadzanieMagazynem = comboBoxZarzadzanie.SelectedItem.ToString();
            string naprawaUrzadzen = comboBoxNaprawa.SelectedItem.ToString();
            string pakowaniePaczek = comboBoxPakowanie.SelectedItem.ToString();

            // Zapytanie SQL do aktualizacji danych roli w bazie danych
            string query = @"UPDATE dbo.Uprawnienia 
                             SET Nazwa_stanowiska = @NazwaRoli, 
                                 DostepDoRaportow = @Dostep, 
                                 ObslugaWozkowWidlowych = @Obsluga, 
                                 ZarzadzanieMagazynem = @Zarzadzanie, 
                                 NaprawaUrzadzen = @Naprawa, 
                                 PakowaniePaczek = @Pakowanie 
                             WHERE UprawnienieID = @ID";

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NazwaRoli", nazwaRoli);
                    cmd.Parameters.AddWithValue("@Dostep", dostepDoRaportow);
                    cmd.Parameters.AddWithValue("@Obsluga", obslugaWozkowWidlowych);
                    cmd.Parameters.AddWithValue("@Zarzadzanie", zarzadzanieMagazynem);
                    cmd.Parameters.AddWithValue("@Naprawa", naprawaUrzadzen);
                    cmd.Parameters.AddWithValue("@Pakowanie", pakowaniePaczek);
                    cmd.Parameters.AddWithValue("@ID", roleId);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Dane roli zostały zaktualizowane.");
                            this.DialogResult = DialogResult.OK; // Ustaw wynik dialogu na OK
                            this.Close(); // Zamknij formularz po zakończeniu edycji
                        }
                        else
                        {
                            MessageBox.Show("Nie udało się zaktualizować danych roli.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Wystąpił błąd podczas aktualizacji danych roli: " + ex.Message);
                    }
                }
            }
        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; 
            this.Close();
        }
    }
}
