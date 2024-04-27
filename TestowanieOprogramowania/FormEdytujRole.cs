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
        private string currentName;
        public FormEdytujRole(int roleId)
        {
            InitializeComponent();
            this.roleId = roleId;
            WczytajDaneRoli();
        }

        private void WczytajDaneRoli()
        {
            string query = "SELECT [Nazwa_stanowiska], [DostepDoListyUzytkownikow], [DostepDoListyUprawnien], [DodawanieUzytkownika], [UsuwanieUzytkownika], [EdytowanieUzytkownika], [DodawanieRoli], [UsuwanieRoli], [EdytowanieRoli], [NadajZmienRoleStanowisko] FROM dbo.Uprawnienia WHERE UprawnienieID = @roleId";

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
                        currentName = reader["Nazwa_stanowiska"].ToString(); ;
                        comboBoxListUz.SelectedItem = reader["DostepDoListyUzytkownikow"].ToString();
                        comboBoxListUp.SelectedItem = reader["DostepDoListyUprawnien"].ToString();
                        comboBoxDodUz.SelectedItem = reader["DodawanieUzytkownika"].ToString();
                        comboBoxUsuUz.SelectedItem = reader["UsuwanieUzytkownika"].ToString();
                        comboBoxEdUz.SelectedItem = reader["EdytowanieUzytkownika"].ToString();
                        comboBoxDodRol.SelectedItem = reader["DodawanieRoli"].ToString();
                        comboBoxUsRol.SelectedItem = reader["UsuwanieRoli"].ToString();
                        comboBoxEdRol.SelectedItem = reader["EdytowanieRoli"].ToString();
                        comboBoxNadUp.SelectedItem = reader["NadajZmienRoleStanowisko"].ToString();
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
            if (textBoxNazwa.Text.Length > 20)
            {
                MessageBox.Show("Zbyd dluga nazwa roli");
                return;
            }
            // Pobierz dane z formularza
            string nazwaRoli = textBoxNazwa.Text;
            string dostepDoListyUzytkownikow = comboBoxListUz.SelectedItem.ToString();
            string dostepDoListyUprawnien = comboBoxListUp.SelectedItem.ToString();
            string dodawanieUzytkownika = comboBoxDodUz.SelectedItem.ToString();
            string usuwanieUzytkownika = comboBoxUsuUz.SelectedItem.ToString();
            string edytowanieUzytkownika = comboBoxEdUz.SelectedItem.ToString();
            string dodawanieRoli = comboBoxDodRol.SelectedItem.ToString();
            string usuwanieRoli = comboBoxUsRol.SelectedItem.ToString();
            string edytowanieRoli = comboBoxEdRol.SelectedItem.ToString();
            string nadawanieRoli = comboBoxNadUp.SelectedItem.ToString();

            // Zapytanie SQL do aktualizacji danych roli w bazie danych
            string query = @"UPDATE dbo.Uprawnienia 
                             SET Nazwa_stanowiska = @NazwaRoli, 
                                 DostepDoListyUzytkownikow = @DostepDoListyUzytkownikow, 
                                 DostepDoListyUprawnien = @DostepDoListyUprawnien, 
                                 DodawanieUzytkownika = @DodawanieUzytkownika, 
                                 UsuwanieUzytkownika = @UsuwanieUzytkownika, 
                                 EdytowanieUzytkownika = @EdytowanieUzytkownika, 
                                 DodawanieRoli = @DodawanieRoli, 
                                 UsuwanieRoli = @UsuwanieRoli, 
                                 EdytowanieRoli = @EdytowanieRoli,
                            NadajZmienRoleStanowisko=@NadajZmienRoleStanowisko
                                 
                             WHERE UprawnienieID = @ID";

            // Sprawdzenie czy wartość z textBoxNazwa nie pokrywa się z żadną nazwą w tabeli Uprawnienia w rzędzie Nazwa_stanowiska
            string nazwa = textBoxNazwa.Text;
            string sprawdzenieNazwyQuery = "SELECT COUNT(*) FROM dbo.Uprawnienia WHERE Nazwa_stanowiska = @Nazwa";
            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                if (nazwa == currentName)
                {

                }
                else
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

            }

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NazwaRoli", nazwaRoli);
                    cmd.Parameters.AddWithValue("@DostepDoListyUzytkownikow", dostepDoListyUzytkownikow);
                    cmd.Parameters.AddWithValue("@DostepDoListyUprawnien", dostepDoListyUprawnien);
                    cmd.Parameters.AddWithValue("@DodawanieUzytkownika", dodawanieUzytkownika);
                    cmd.Parameters.AddWithValue("@UsuwanieUzytkownika", usuwanieUzytkownika);
                    cmd.Parameters.AddWithValue("@EdytowanieUzytkownika", edytowanieUzytkownika);
                    cmd.Parameters.AddWithValue("@DodawanieRoli", dodawanieRoli);
                    cmd.Parameters.AddWithValue("@UsuwanieRoli", usuwanieRoli);
                    cmd.Parameters.AddWithValue("@EdytowanieRoli", edytowanieRoli);
                    cmd.Parameters.AddWithValue("@NadajZmienRoleStanowisko", nadawanieRoli);

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

        private void FormEdytujRole_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxDodRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
