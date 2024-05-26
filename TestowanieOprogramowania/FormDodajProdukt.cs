using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace TestowanieOprogramowania
{
    public partial class FormDodajProdukt : Form
    {
        string con = PolaczenieBazyDanych.StringPolaczeniowy();

        public FormDodajProdukt()
        {
            InitializeComponent();
            textBoxOpisTowaru.Width = 300;
            textBoxOpisTowaru.Height = 100;
            textBoxOpisTowaru.Multiline = true; // pozwala na wpisywanie wielu linii tekstu
        }

        private void buttonDodajProdukt_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxNazwaTowaru.Text) ||
                    string.IsNullOrWhiteSpace(comboBoxRodzajTowaru.Text) ||
                    string.IsNullOrWhiteSpace(comboBoxJednostkaMiary.Text) ||
                    string.IsNullOrWhiteSpace(textBoxIlosc.Text) ||
                    string.IsNullOrWhiteSpace(textBoxCenaNetto.Text) ||
                    string.IsNullOrWhiteSpace(comboBoxStawkaVat.Text) ||
                    string.IsNullOrWhiteSpace(textBoxOpisTowaru.Text) ||
                    string.IsNullOrWhiteSpace(textBoxDostawca.Text))
                {
                    MessageBox.Show("Proszę wypełnić wszystkie pola.");
                    return;
                }

                string nazwaTowaru = textBoxNazwaTowaru.Text;
                string rodzajTowaru = comboBoxRodzajTowaru.Text;
                string jednostkaMiary = comboBoxJednostkaMiary.Text;
                int ilosc = Convert.ToInt32(textBoxIlosc.Text);
                decimal cenaNetto = Convert.ToDecimal(textBoxCenaNetto.Text);
                string stawkaVat = comboBoxStawkaVat.Text;
                string opisTowaru = textBoxOpisTowaru.Text;
                string dostawca = textBoxDostawca.Text;
                DateTime dataDostawy = dateTimePickerDataDostawy.Value;
                DateTime dataRejestracji = DateTime.Now;
                string imieNazwiskoRejestr = PobierzImieNazwisko(UserSession.CurrentUserId);

                // Sprawdzenie czy produkt już istnieje
                if (ProduktIstnieje(nazwaTowaru))
                {
                    // Aktualizacja ilości istniejącego produktu
                    MessageBox.Show("Produkt już istnieje");
                    return;
                }
                else
                {
                    // Dodanie nowego produktu
                    DodajProdukt(nazwaTowaru, rodzajTowaru, jednostkaMiary, ilosc, cenaNetto, stawkaVat,
                        opisTowaru, dostawca, dataDostawy, dataRejestracji, imieNazwiskoRejestr);
                }

                MessageBox.Show("Operacja zakończona pomyślnie.");
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Wprowadzono nieprawidłowy format danych. Sprawdź, czy liczby są poprawnie wpisane.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Błąd bazy danych: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd: " + ex.Message);
            }
        }

        public string PobierzImieNazwisko(int userId)
        {
            string fullName = "";

            using (SqlConnection connection = new SqlConnection(con))
            {
                string query = "SELECT CONCAT(Imie, ' ', Nazwisko) AS PelneImieNazwisko FROM Uzytkownicy WHERE UzytkownikID = @UzytkownikID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UzytkownikID", userId);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                        fullName = result.ToString();
                }
            }

            return fullName;
        }

        private bool ProduktIstnieje(string nazwaTowaru)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                string query = "SELECT COUNT(*) FROM Produkty WHERE NazwaTowaru = @NazwaTowaru";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NazwaTowaru", nazwaTowaru);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        

        public void DodajProdukt(string nazwaTowaru, string rodzajTowaru, string jednostkaMiary, int ilosc, decimal cenaNetto,
            string stawkaVAT, string opis, string dostawca, DateTime dataDostawy, DateTime dataRejestracji, string rejestracja)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                string query = "INSERT INTO Produkty (NazwaTowaru, RodzajTowaru, JednostkaMiary, Ilosc, CenaNetto, StawkaVAT, Opis, Dostawca, DataDostawy, DataRejestracji, Rejestrujacy) VALUES (@NazwaTowaru, @RodzajTowaru, @JednostkaMiary, @Ilosc, @CenaNetto, @StawkaVAT, @Opis, @Dostawca, @DataDostawy, @DataRejestracji, @Rejestrujacy)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NazwaTowaru", nazwaTowaru);
                    command.Parameters.AddWithValue("@RodzajTowaru", rodzajTowaru);
                    command.Parameters.AddWithValue("@JednostkaMiary", jednostkaMiary);
                    command.Parameters.AddWithValue("@Ilosc", ilosc);
                    command.Parameters.AddWithValue("@CenaNetto", cenaNetto);
                    command.Parameters.AddWithValue("@StawkaVAT", stawkaVAT);
                    command.Parameters.AddWithValue("@Opis", opis);
                    command.Parameters.AddWithValue("@Dostawca", dostawca);
                    command.Parameters.AddWithValue("@DataDostawy", dataDostawy);
                    command.Parameters.AddWithValue("@DataRejestracji", dataRejestracji);
                    command.Parameters.AddWithValue("@Rejestrujacy", rejestracja);

                    connection.Open();
                    command.ExecuteNonQuery();
                }


                //TO raczej zmienic na trigera
                // Dodanie rekordu rejestracji

                /*
                string insertRejestracja = "INSERT INTO Rejestracja (NazwaTowaru, Ilosc, DataRejestracji, Rejestrujacy) VALUES (@NazwaTowaru, @Ilosc, @DataRejestracji, @Rejestrujacy)";
                using (SqlCommand command = new SqlCommand(insertRejestracja, connection))
                {
                    command.Parameters.AddWithValue("@NazwaTowaru", nazwaTowaru);
                    command.Parameters.AddWithValue("@Ilosc", ilosc);
                    command.Parameters.AddWithValue("@DataRejestracji", dataRejestracji);
                    command.Parameters.AddWithValue("@Rejestrujacy", rejestracja);

                    command.ExecuteNonQuery();
                }*/
            }
        }

        private DataTable PobierzRodzajeTowarow()
        {
            DataTable dt = new DataTable();
            string query = "SELECT RodzajTowaruID, NazwaRodzaju FROM RodzajeTowarow";

            using (SqlConnection conn = new SqlConnection(con))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EdytujRodzajeTowarow formEdytuj = new EdytujRodzajeTowarow();
            formEdytuj.ShowDialog();
            LoadRodzajeToComboBox();
        }

        private void LoadRodzajeToComboBox()
        {
            DataTable rodzajeTowarow = PobierzRodzajeTowarow();
            comboBoxRodzajTowaru.DataSource = rodzajeTowarow;
            comboBoxRodzajTowaru.DisplayMember = "NazwaRodzaju";  // Kolumna, która ma być wyświetlana
            comboBoxRodzajTowaru.ValueMember = "RodzajTowaruID";  // Kolumna, która ma być wartością
        }

        private void FormDodajProdukt_Load(object sender, EventArgs e)
        {
            LoadRodzajeToComboBox();
        }
    }
}
