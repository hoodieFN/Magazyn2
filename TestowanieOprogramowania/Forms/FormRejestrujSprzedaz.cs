using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using TestowanieOprogramowania.Services;

namespace TestowanieOprogramowania
{
    public partial class FormRejestrujSprzedaz : Form
    {
        private readonly KoszykService _koszykService;

        public FormRejestrujSprzedaz()
        {
            InitializeComponent();
            _koszykService = new KoszykService(PolaczenieBazyDanych.StringPolaczeniowy());
            LoadNazwaTowaru();
            OdswiezKoszyk();
            numericUpDownIloscTowaru.ValueChanged += new EventHandler(NumericUpDown_ValueChanged);
            numericUpDownCenaZaTowar.ValueChanged += new EventHandler(NumericUpDown_ValueChanged);
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            
            label14.Visible = false;
            CheckDataGridViewRows();
            textBoxNazwaKlienta.Visible = true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string nazwaTowaru = dataGridView1.Rows[e.RowIndex].Cells["NazwaTowaru"].Value.ToString();
                FormKoszykInfo formDetails = new FormKoszykInfo(_koszykService);
                formDetails.LoadProductDetails(nazwaTowaru);
                formDetails.ShowDialog();
            }
        }

        private void LoadNazwaTowaru()
        {
            DataTable productsTable = _koszykService.GetAllProducts();
            foreach (DataRow row in productsTable.Rows)
            {
                comboBoxNazwaTowaru.Items.Add(row["NazwaTowaru"].ToString());
            }
        }

        private void buttonDodajDoKoszyka_Click(object sender, EventArgs e)
        {
            decimal iloscZamawiana = numericUpDownIloscTowaru.Value;

            if (comboBoxNazwaTowaru.SelectedItem == null)
            {
                MessageBox.Show("Proszę wybrać nazwę towaru.");
                return;
            }

            string nazwaTowaru = comboBoxNazwaTowaru.SelectedItem.ToString();

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

            using (SqlConnection conn = new SqlConnection(PolaczenieBazyDanych.StringPolaczeniowy()))
            {
                conn.Open();

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

                    if (iloscZamawiana > iloscDostepna)
                    {
                        MessageBox.Show("Nie ma wystarczającej ilości produktu na stanie.");
                        return;
                    }

                    _koszykService.AddProductToCart(produkt, iloscZamawiana, numericUpDownCenaZaTowar.Value, textBoxNazwaKlienta.Text, textBoxMiejscowosc.Text, textBoxKodPocztowy.Text, textBoxUlica.Text, textBoxNrDomu.Text, dateTimePicker1.Value);
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
            using (SqlConnection conn = new SqlConnection(PolaczenieBazyDanych.StringPolaczeniowy()))
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

                _koszykService.RemoveFromCart(nazwaTowaru, iloscTowaru);

                OdswiezKoszyk();
                CheckDataGridViewRows();
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć wiersz do usunięcia.");
            }
        }

        private void buttonZarejestrujSprzedaz_Click(object sender, EventArgs e)
        {
            string imieNazwiskoRejestr = PobierzImieNazwisko(UserSession.CurrentUserId);

            _koszykService.RegisterSale(imieNazwiskoRejestr);

            OdswiezKoszyk();
            CheckDataGridViewRows();
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            decimal iloscTowaru = numericUpDownIloscTowaru.Value;
            decimal cenaZaTowar = numericUpDownCenaZaTowar.Value;

            decimal przychod = iloscTowaru * cenaZaTowar;

            label6.Text = przychod.ToString("F2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string nazwaTowaru = selectedRow.Cells["NazwaTowaru"].Value.ToString();
                decimal iloscWKoszyku = Convert.ToDecimal(selectedRow.Cells["IloscTowaru"].Value);
                decimal nowaIlosc = numericUpDown1.Value;

                using (SqlConnection conn = new SqlConnection(PolaczenieBazyDanych.StringPolaczeniowy()))
                {
                    conn.Open();

                    SqlCommand checkIloscCmd = new SqlCommand("SELECT Ilosc FROM dbo.Produkty WHERE NazwaTowaru = @NazwaTowaru", conn);
                    checkIloscCmd.Parameters.AddWithValue("@NazwaTowaru", nazwaTowaru);
                    decimal iloscDostepna = Convert.ToDecimal(checkIloscCmd.ExecuteScalar());

                    decimal nowaIloscDostepna = iloscDostepna + iloscWKoszyku - nowaIlosc;

                    if (nowaIlosc > iloscDostepna)
                    {
                        MessageBox.Show("Zamawiana ilość przekracza ilość dostępnego produktu.");
                        return;
                    }

                    _koszykService.UpdateProductQuantity((int)selectedRow.Cells["ProduktID"].Value, nowaIlosc - iloscWKoszyku);

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

        private void CheckDataGridViewRows()
        {
            int rowCount = dataGridView1.Rows.Count;
            if (dataGridView1.AllowUserToAddRows)
            {
                rowCount--;
            }

            if (rowCount > 0)
            {
                textBoxNazwaKlienta.Visible = false;
                label14.Visible = true;
            }
            else
            {
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
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FormRejestrujSprzedaz_Load(object sender, EventArgs e)
        {

        }

        public string PobierzImieNazwisko(int userId)
        {
            string fullName = "";

            using (SqlConnection connection = new SqlConnection(PolaczenieBazyDanych.StringPolaczeniowy()))
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
