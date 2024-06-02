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
    public partial class FormRejestrujSprzedaz : Form
    {
        string con = PolaczenieBazyDanych.StringPolaczeniowy();
        public FormRejestrujSprzedaz()
        {
            InitializeComponent();
            LoadNazwaTowaru();
            OdswiezKoszyk();
            numericUpDownIloscTowaru.ValueChanged += new EventHandler(NumericUpDown_ValueChanged);
            numericUpDownCenaZaTowar.ValueChanged += new EventHandler(NumericUpDown_ValueChanged);
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            textBoxNazwaKlienta.Visible = true;
            label14.Visible = false;
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Pobranie nazwy towaru z zaznaczonego wiersza
                string nazwaTowaru = dataGridView1.Rows[e.RowIndex].Cells["NazwaTowaru"].Value.ToString();

                // Utworzenie nowego formularza i przekazanie nazwy towaru
                FormKoszykInfo formDetails = new FormKoszykInfo();
                formDetails.LoadProductDetails(nazwaTowaru);

                // Otwarcie nowego formularza
                formDetails.ShowDialog();
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FormRejestrujSprzedaz_Load(object sender, EventArgs e)
        {

        }
        private void LoadNazwaTowaru()
        {
            string query = "SELECT DISTINCT NazwaTowaru FROM Produkty";

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBoxNazwaTowaru.Items.Add(reader["NazwaTowaru"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd: " + ex.Message);
                }
            }
        }

        private void buttonDodajDoKoszyka_Click(object sender, EventArgs e)
        {
            string nazwaTowaru = comboBoxNazwaTowaru.SelectedItem.ToString();
            decimal iloscZamawiana = numericUpDownIloscTowaru.Value;


            //Walidacja
            if (comboBoxNazwaTowaru.SelectedItem == null)
            {
                MessageBox.Show("Proszę wybrać nazwę towaru.");
                return;
            }

            if (numericUpDownIloscTowaru.Value <= 0)
            {
                MessageBox.Show("Ilość towaru do sprzedania musi być większa niż 0.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxNazwaKlienta.Text))
            {
                MessageBox.Show("Proszę wpisać nazwę klienta.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxMiejscowosc.Text))
            {
                MessageBox.Show("Proszę wpisać miejscowość.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxKodPocztowy.Text) || !System.Text.RegularExpressions.Regex.IsMatch(textBoxKodPocztowy.Text, @"^\d{2}-\d{3}$"))
            {
                MessageBox.Show("Proszę wpisać kod pocztowy w formacie 00-000.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxUlica.Text))
            {
                MessageBox.Show("Proszę wpisać ulicę.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxNrDomu.Text))
            {
                MessageBox.Show("Proszę wpisać numer domu.");
                return;
            }












            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();

                // Sprawdzenie, czy produkt już istnieje w koszyku
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM dbo.Koszyk WHERE NazwaTowaru = @NazwaTowaru", conn);
                checkCmd.Parameters.AddWithValue("@NazwaTowaru", nazwaTowaru);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Produkt już istnieje w koszyku.");
                    return;
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Produkty WHERE NazwaTowaru = @NazwaTowaru", conn);
                cmd.Parameters.AddWithValue("@NazwaTowaru", nazwaTowaru);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable produktyTable = new DataTable();
                adapter.Fill(produktyTable);

                if (produktyTable.Rows.Count > 0)
                {
                    DataRow produkt = produktyTable.Rows[0];
                    decimal iloscDostepna = Convert.ToDecimal(produkt["Ilosc"]);

                    // Sprawdzenie, czy dostępna ilość jest wystarczająca
                    if (iloscZamawiana > iloscDostepna)
                    {
                        MessageBox.Show("Nie ma wystarczającej ilości produktu na stanie.");
                        return;
                    }

                    string insertQuery = @"
                INSERT INTO dbo.Koszyk
                (ProduktID, NazwaTowaru, RodzajTowaru, JednostkaMiary, Ilosc, CenaNetto, StawkaVAT, Opis, Dostawca, DataDostawy, DataRejestracji, Rejestrujacy, NazwaTowaruNowa, IloscTowaru, CenaZaTowar, Przychod, NazwaKlienta, Miejscowosc, KodPocztowy, Ulica, NrDomu, DataSprzedazy)
                VALUES
                (@ProduktID, @NazwaTowaru, @RodzajTowaru, @JednostkaMiary, @Ilosc, @CenaNetto, @StawkaVAT, @Opis, @Dostawca, @DataDostawy, @DataRejestracji, @Rejestrujacy, NULL, @IloscTowaru, @CenaZaTowar, @Przychod, @NazwaKlienta, @Miejscowosc, @KodPocztowy, @Ulica, @NrDomu, @DataSprzedazy)";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@ProduktID", produkt["ProduktID"]);
                    insertCmd.Parameters.AddWithValue("@NazwaTowaru", produkt["NazwaTowaru"]);
                    insertCmd.Parameters.AddWithValue("@RodzajTowaru", produkt["RodzajTowaru"]);
                    insertCmd.Parameters.AddWithValue("@JednostkaMiary", produkt["JednostkaMiary"]);
                    insertCmd.Parameters.AddWithValue("@Ilosc", produkt["Ilosc"]);
                    insertCmd.Parameters.AddWithValue("@CenaNetto", produkt["CenaNetto"]);
                    insertCmd.Parameters.AddWithValue("@StawkaVAT", produkt["StawkaVAT"]);
                    insertCmd.Parameters.AddWithValue("@Opis", produkt["Opis"]);
                    insertCmd.Parameters.AddWithValue("@Dostawca", produkt["Dostawca"]);
                    insertCmd.Parameters.AddWithValue("@DataDostawy", produkt["DataDostawy"]);
                    insertCmd.Parameters.AddWithValue("@DataRejestracji", produkt["DataRejestracji"]);
                    insertCmd.Parameters.AddWithValue("@Rejestrujacy", produkt["Rejestrujacy"]);
                    insertCmd.Parameters.AddWithValue("@IloscTowaru", iloscZamawiana);
                    insertCmd.Parameters.AddWithValue("@CenaZaTowar", numericUpDownCenaZaTowar.Value);
                    insertCmd.Parameters.AddWithValue("@Przychod", iloscZamawiana * numericUpDownCenaZaTowar.Value);
                    insertCmd.Parameters.AddWithValue("@NazwaKlienta", textBoxNazwaKlienta.Text);
                    insertCmd.Parameters.AddWithValue("@Miejscowosc", textBoxMiejscowosc.Text);
                    insertCmd.Parameters.AddWithValue("@KodPocztowy", textBoxKodPocztowy.Text);
                    insertCmd.Parameters.AddWithValue("@Ulica", textBoxUlica.Text);
                    insertCmd.Parameters.AddWithValue("@NrDomu", textBoxNrDomu.Text);
                    insertCmd.Parameters.AddWithValue("@DataSprzedazy", dateTimePicker1.Value);

                    insertCmd.ExecuteNonQuery();

                    // Aktualizacja ilości w tabeli Produkty
                    string updateQuery = "UPDATE dbo.Produkty SET Ilosc = Ilosc - @IloscTowaru WHERE ProduktID = @ProduktID";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@IloscTowaru", iloscZamawiana);
                    updateCmd.Parameters.AddWithValue("@ProduktID", produkt["ProduktID"]);

                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Nie znaleziono produktu o podanej nazwie.");
                }

                OdswiezKoszyk();
            }
            CheckDataGridViewRows();

        }

        private void OdswiezKoszyk()
        {
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT NazwaTowaru, IloscTowaru, Przychod, NazwaKlienta FROM dbo.Koszyk", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable koszykTable = new DataTable();
                adapter.Fill(koszykTable);

                dataGridView1.DataSource = koszykTable;
            }
        }

        private void buttonUsunZKoszyka_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string nazwaTowaru = selectedRow.Cells["NazwaTowaru"].Value.ToString();
                int iloscTowaru = Convert.ToInt32(selectedRow.Cells["IloscTowaru"].Value);

                using (SqlConnection conn = new SqlConnection(con))
                {
                    conn.Open();
                    // Dodaj ilość do tabeli Produkty
                    SqlCommand updateCmd = new SqlCommand("UPDATE dbo.Produkty SET Ilosc = Ilosc + @IloscTowaru WHERE NazwaTowaru = @NazwaTowaru", conn);
                    updateCmd.Parameters.AddWithValue("@IloscTowaru", iloscTowaru);
                    updateCmd.Parameters.AddWithValue("@NazwaTowaru", nazwaTowaru);
                    updateCmd.ExecuteNonQuery();

                    // Usuń wiersz z tabeli Koszyk
                    SqlCommand deleteCmd = new SqlCommand("DELETE FROM dbo.Koszyk WHERE NazwaTowaru = @NazwaTowaru", conn);
                    deleteCmd.Parameters.AddWithValue("@NazwaTowaru", nazwaTowaru);
                    deleteCmd.ExecuteNonQuery();

                    MessageBox.Show("Produkt został usunięty z koszyka");
                }

                // Odśwież zawartość DataGridView
                OdswiezKoszyk();
                CheckDataGridViewRows();
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć wiersz do usunięcia.");
            }
            CheckDataGridViewRows();
        }

        private void buttonZarejestrujSprzedaz_Click(object sender, EventArgs e)
        {
            string imieNazwiskoRejestr = PobierzImieNazwisko(UserSession.CurrentUserId);
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();

                // Pobierz wszystkie rekordy z tabeli dbo.Koszyk
                SqlCommand selectCmd = new SqlCommand("SELECT * FROM dbo.Koszyk", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(selectCmd);
                DataTable koszykTable = new DataTable();
                adapter.Fill(koszykTable);

                if (koszykTable.Rows.Count > 0)
                {
                    // Pobierz następne IDSprzedazy
                    SqlCommand getMaxSaleIDCmd = new SqlCommand("SELECT ISNULL(MAX(IDSprzedazy), 0) + 1 FROM dbo.Sprzedaz", conn);
                    int nextSaleID = (int)getMaxSaleIDCmd.ExecuteScalar();

                    foreach (DataRow row in koszykTable.Rows)
                    {
                        string insertQuery = @"
                INSERT INTO dbo.Sprzedaz
                (ProduktID, NazwaTowaru, RodzajTowaru, JednostkaMiary, Ilosc, CenaNetto, StawkaVAT, Opis, Dostawca, DataDostawy, DataRejestracji, Rejestrujacy, NazwaTowaruNowa, IloscTowaru, CenaZaTowar, Przychod, NazwaKlienta, Miejscowosc, KodPocztowy, Ulica, NrDomu, DataSprzedazy, IDSprzedazy, NazwaSprzedawcy)
                VALUES
                (@ProduktID, @NazwaTowaru, @RodzajTowaru, @JednostkaMiary, @Ilosc, @CenaNetto, @StawkaVAT, @Opis, @Dostawca, @DataDostawy, @DataRejestracji, @Rejestrujacy, @NazwaTowaruNowa, @IloscTowaru, @CenaZaTowar, @Przychod, @NazwaKlienta, @Miejscowosc, @KodPocztowy, @Ulica, @NrDomu, @DataSprzedazy, @IDSprzedazy, @NazwaSprzedawcy)";

                        SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@ProduktID", row["ProduktID"]);
                        insertCmd.Parameters.AddWithValue("@NazwaTowaru", row["NazwaTowaru"]);
                        insertCmd.Parameters.AddWithValue("@RodzajTowaru", row["RodzajTowaru"]);
                        insertCmd.Parameters.AddWithValue("@JednostkaMiary", row["JednostkaMiary"]);
                        insertCmd.Parameters.AddWithValue("@Ilosc", row["Ilosc"]);
                        insertCmd.Parameters.AddWithValue("@CenaNetto", row["CenaNetto"]);
                        insertCmd.Parameters.AddWithValue("@StawkaVAT", row["StawkaVAT"]);
                        insertCmd.Parameters.AddWithValue("@Opis", row["Opis"]);
                        insertCmd.Parameters.AddWithValue("@Dostawca", row["Dostawca"]);
                        insertCmd.Parameters.AddWithValue("@DataDostawy", row["DataDostawy"]);
                        insertCmd.Parameters.AddWithValue("@DataRejestracji", row["DataRejestracji"]);
                        insertCmd.Parameters.AddWithValue("@Rejestrujacy", row["Rejestrujacy"]);
                        insertCmd.Parameters.AddWithValue("@NazwaTowaruNowa", row["NazwaTowaruNowa"]);
                        insertCmd.Parameters.AddWithValue("@IloscTowaru", row["IloscTowaru"]);
                        insertCmd.Parameters.AddWithValue("@CenaZaTowar", row["CenaZaTowar"]);
                        insertCmd.Parameters.AddWithValue("@Przychod", row["Przychod"]);
                        insertCmd.Parameters.AddWithValue("@NazwaKlienta", row["NazwaKlienta"]);
                        insertCmd.Parameters.AddWithValue("@Miejscowosc", row["Miejscowosc"]);
                        insertCmd.Parameters.AddWithValue("@KodPocztowy", row["KodPocztowy"]);
                        insertCmd.Parameters.AddWithValue("@Ulica", row["Ulica"]);
                        insertCmd.Parameters.AddWithValue("@NrDomu", row["NrDomu"]);
                        insertCmd.Parameters.AddWithValue("@DataSprzedazy", row["DataSprzedazy"]);
                        insertCmd.Parameters.AddWithValue("@IDSprzedazy", nextSaleID);
                        insertCmd.Parameters.AddWithValue("@NazwaSprzedawcy", imieNazwiskoRejestr);

                        insertCmd.ExecuteNonQuery();
                    }

                    // Usuń wszystkie rekordy z tabeli dbo.Koszyk
                    SqlCommand deleteCmd = new SqlCommand("DELETE FROM dbo.Koszyk", conn);
                    deleteCmd.ExecuteNonQuery();

                    MessageBox.Show("Pomyślnie zarejestrowano sprzedaż");

                    // Odśwież zawartość DataGridView
                    OdswiezKoszyk();
                }
                else
                {
                    MessageBox.Show("Koszyk jest pusty.");
                }

            }
            CheckDataGridViewRows();
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Pobranie wartości z numericUpDownIloscTowaru i numericUpDownCenaZaTowar
            decimal iloscTowaru = numericUpDownIloscTowaru.Value;
            decimal cenaZaTowar = numericUpDownCenaZaTowar.Value;

            // Wyliczenie iloczynu
            decimal przychod = iloscTowaru * cenaZaTowar;

            // Wstawienie wyniku do label6
            label6.Text = przychod.ToString("F2"); // "F2" formatuje wynik do dwóch miejsc po przecinku
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Pobranie zaznaczonego wiersza
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string nazwaTowaru = selectedRow.Cells["NazwaTowaru"].Value.ToString();
                decimal iloscWKoszyku = Convert.ToDecimal(selectedRow.Cells["IloscTowaru"].Value);
                decimal nowaIlosc = numericUpDown1.Value;

                using (SqlConnection conn = new SqlConnection(con))
                {
                    conn.Open();


                    // Sprawdzenie ilości dostępnej w tabeli Produkty
                    SqlCommand checkIloscCmd = new SqlCommand("SELECT Ilosc FROM dbo.Produkty WHERE NazwaTowaru = @NazwaTowaru", conn);
                    checkIloscCmd.Parameters.AddWithValue("@NazwaTowaru", nazwaTowaru);
                    decimal iloscDostepna = Convert.ToDecimal(checkIloscCmd.ExecuteScalar());

                    // Dodanie ilości z koszyka do dostępnej ilości w tabeli Produkty
                    decimal nowaIloscDostepna = iloscDostepna + iloscWKoszyku - nowaIlosc;
                    //MessageBox.Show("nowa ilosc doostepna"+nowaIloscDostepna.ToString());
                    //MessageBox.Show("ilosc dostepna" + iloscDostepna.ToString());
                    //MessageBox.Show("ilosc w koszyku" + iloscWKoszyku.ToString());
                    //MessageBox.Show("nowa ilosc" + nowaIlosc.ToString());

                    // Sprawdzenie, czy nowa ilość nie przekracza dostępnej ilości
                    if (nowaIlosc > iloscDostepna)
                    {
                        MessageBox.Show("Zamawiana ilość przekracza ilość dostępnego produktu.");
                        return;
                    }



                    // Aktualizacja ilości w tabeli Produkty
                    UpdateIloscProdukty(nazwaTowaru, nowaIloscDostepna);
                    /*
                    // Aktualizacja ilości w tabeli Produkty
                    string updateIloscQuery = "UPDATE dbo.Produkty SET Ilosc = @NowaIloscDostepna WHERE NazwaTowaru = @NazwaTowaru";
                    SqlCommand updateIloscCmd = new SqlCommand(updateIloscQuery, conn);
                    updateIloscCmd.Parameters.AddWithValue("@NowaIloscDostepna", nowaIloscDostepna);
                    updateIloscCmd.Parameters.AddWithValue("@NazwaTowaru", nazwaTowaru);
                    */



                    // Sprawdzenie, czy produkt istnieje w koszyku
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM dbo.Koszyk WHERE NazwaTowaru = @NazwaTowaru", conn);
                    checkCmd.Parameters.AddWithValue("@NazwaTowaru", nazwaTowaru);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Nie znaleziono produktu w koszyku.");
                        return;
                    }

                    // Aktualizacja ilości produktu w koszyku
                    string updateQuery = "UPDATE dbo.Koszyk SET IloscTowaru = @NowaIlosc WHERE NazwaTowaru = @NazwaTowaru";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@NowaIlosc", nowaIlosc);
                    updateCmd.Parameters.AddWithValue("@NazwaTowaru", nazwaTowaru);

                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Zaktualizowano ilość produktu w koszyku.");

                    OdswiezKoszyk();
                }
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć wiersz w koszyku.");
            }
            CheckDataGridViewRows();
        }
        private void UpdateIloscProdukty(string nazwaTowaru, decimal nowaIloscDostepna)
        {
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();

                // Aktualizacja ilości w tabeli Produkty
                string updateIloscQuery = "UPDATE dbo.Produkty SET Ilosc = @NowaIloscDostepna WHERE NazwaTowaru = @NazwaTowaru";
                SqlCommand updateIloscCmd = new SqlCommand(updateIloscQuery, conn);
                updateIloscCmd.Parameters.AddWithValue("@NowaIloscDostepna", nowaIloscDostepna);
                updateIloscCmd.Parameters.AddWithValue("@NazwaTowaru", nazwaTowaru);

                int rowsAffected = updateIloscCmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    MessageBox.Show("Nie udało się zaktualizować ilości produktu w magazynie.");
                }
                else
                {
                    MessageBox.Show("Ilość produktu w magazynie została zaktualizowana.");
                }
            }
        }


        private void CheckDataGridViewRows()
        {
            // Sprawdzamy ilość wierszy w DataGridView, z wyłączeniem wiersza nowego wiersza (jeśli AllowUserToAddRows = true)
            int rowCount = dataGridView1.Rows.Count;

            // Jeśli AllowUserToAddRows jest włączone, musimy odjąć ten dodatkowy wiersz od liczby wierszy
            if (dataGridView1.AllowUserToAddRows)
            {
                rowCount--;
            }

            // Jeśli ilość wierszy jest większa od 0
            if (rowCount > 0)
            {
                // Ustawiamy widoczność textBoxNazwaKlienta na false
                textBoxNazwaKlienta.Visible = false;
                label14.Visible = true;
            }
            else
            {
                // W przeciwnym wypadku ustawiamy widoczność na true
                textBoxNazwaKlienta.Visible = true;
                label14.Visible = false;
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CheckDataGridViewRows();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CheckDataGridViewRows();
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

    }
}
