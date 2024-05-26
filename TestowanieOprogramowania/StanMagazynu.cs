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
    public partial class StanMagazynu : Form
    {


        private ZarzadzanieVoidami zarzadzanieVoidami;
        public StanMagazynu()
        {
            InitializeComponent();

            zarzadzanieVoidami = new ZarzadzanieVoidami();
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();


            OdswiezDataGridViewProdukty();
        }
        private void StanMagazynu_Load(object sender, EventArgs e)
        {
            OdswiezDataGridViewProdukty();
            comboBoxSzukaj.SelectedIndex = 0;


        }
        private void OdswiezDataGridViewProdukty()
        {
            var listaProduktów = zarzadzanieVoidami.PobierzPodukty();
            dataGridView2.DataSource = listaProduktów;
            if (listaProduktów == null || listaProduktów.Count == 0)
            {
                MessageBox.Show("Brak danych do wyświetlenia.");
            }


        }

        private void DodajIloscProduktu(string nazwaTowaru, int ilosc, DateTime dataRejestracji, string rejestracja)
        {
            string con = PolaczenieBazyDanych.StringPolaczeniowy();
            using (SqlConnection connection = new SqlConnection(con))
            {
                // Update product quantity
                string queryUpdate = "UPDATE Produkty SET Ilosc = Ilosc + @Ilosc WHERE NazwaTowaru = @NazwaTowaru";
                using (SqlCommand command = new SqlCommand(queryUpdate, connection))
                {
                    command.Parameters.AddWithValue("@Ilosc", ilosc);
                    command.Parameters.AddWithValue("@NazwaTowaru", nazwaTowaru);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                // Retrieve product details for logging
                string querySelect = "SELECT * FROM Produkty WHERE NazwaTowaru = @NazwaTowaru";
                DataRow productData;
                using (SqlCommand command = new SqlCommand(querySelect, connection))
                {
                    command.Parameters.AddWithValue("@NazwaTowaru", nazwaTowaru);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        productData = dt.Rows[0];
                    }

                    connection.Close();
                }

                // Insert into history
                string queryInsert = "INSERT INTO ProduktyHistoriaOperacji (ProduktID, NazwaTowaru, RodzajTowaru, JednostkaMiary, Ilosc, CenaNetto, StawkaVAT, Opis, Dostawca, DataDostawy, DataRejestracji, Rejestrujacy, DataZapisu, Operacja) " +
                                     "VALUES (@ProduktID, @NazwaTowaru, @RodzajTowaru, @JednostkaMiary, @Ilosc, @CenaNetto, @StawkaVAT, @Opis, @Dostawca, @DataDostawy, @DataRejestracji, @Rejestrujacy, @DataZapisu, @Operacja)";

                using (SqlCommand command = new SqlCommand(queryInsert, connection))
                {
                    command.Parameters.AddWithValue("@ProduktID", productData["ProduktID"]);
                    command.Parameters.AddWithValue("@NazwaTowaru", productData["NazwaTowaru"]);
                    command.Parameters.AddWithValue("@RodzajTowaru", productData["RodzajTowaru"]);
                    command.Parameters.AddWithValue("@JednostkaMiary", productData["JednostkaMiary"]);
                    command.Parameters.AddWithValue("@Ilosc", productData["Ilosc"]);
                    command.Parameters.AddWithValue("@CenaNetto", productData["CenaNetto"]);
                    command.Parameters.AddWithValue("@StawkaVAT", productData["StawkaVAT"]);
                    command.Parameters.AddWithValue("@Opis", productData["Opis"]);
                    command.Parameters.AddWithValue("@Dostawca", productData["Dostawca"]);
                    command.Parameters.AddWithValue("@DataDostawy", productData["DataDostawy"]);
                    command.Parameters.AddWithValue("@DataRejestracji", productData["DataRejestracji"]);
                    command.Parameters.AddWithValue("@Rejestrujacy", rejestracja);
                    command.Parameters.AddWithValue("@DataZapisu", DateTime.Now);
                    command.Parameters.AddWithValue("@Operacja", $"Dodanie ilości ({ilosc} sztuk)");

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }






        private void SzukajProdukt_Click(object sender, EventArgs e)
        {
            // Sprawdzenie, czy został wybrany element z comboBoxSzukaj
            if (comboBoxSzukaj.SelectedItem == null)
            {
                MessageBox.Show("Proszę wybrać kryterium wyszukiwania z listy.");
                return;  // Zakończ funkcję, jeśli nic nie zostało wybrane
            }

            // Kontynuacja, jeśli element został wybrany
            string kryteriumWyszukiwania = comboBoxSzukaj.SelectedItem.ToString();
            List<Produkt> listaProduktów = zarzadzanieVoidami.WyszukajProdukt(textBoxSzukajProduktu.Text, kryteriumWyszukiwania);
            dataGridView2.DataSource = listaProduktów;
        }

        private void buttonDodajProdukt_Click(object sender, EventArgs e)
        {
            using (var formDodaj = new FormDodajProdukt())
            {
                var result = formDodaj.ShowDialog();
                if (result == DialogResult.OK)
                {
                    OdswiezDataGridViewProdukty();
                }

            }
            OdswiezDataGridViewProdukty();
        }

        private void StanMagazynu_Load_1(object sender, EventArgs e)
        {

        }
        /*
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        */
        public string PobierzImieNazwisko(int userId)
        {
            string con = PolaczenieBazyDanych.StringPolaczeniowy();
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
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczony produkt?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int produktId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ProduktID"].Value);

                    zarzadzanieVoidami.UsunProduktZBazy(produktId);

                    OdswiezDataGridViewProdukty();
                }
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć wiersz do usunięcia", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonHUSM_Click(object sender, EventArgs e)
        {
            FormHUSM formHUSM = new FormHUSM();
            formHUSM.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormZmianaVat formZmianaVat = new FormZmianaVat();
            formZmianaVat.ShowDialog();
            formZmianaVat.FormClosed += (s, args) => OdswiezDataGridViewProdukty();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormVATKategoria formVaTKategoria = new FormVATKategoria();
            formVaTKategoria.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Proszę wybrać produkt z listy.");
                    return;
                }

                string nazwaTowaru = dataGridView2.SelectedRows[0].Cells["NazwaTowaru"].Value.ToString();
                string dostawca = dataGridView2.SelectedRows[0].Cells["Dostawca"].Value.ToString();
                string opis = dataGridView2.SelectedRows[0].Cells["Opis"].Value.ToString();
                string jednostkaMiary = dataGridView2.SelectedRows[0].Cells["JednostkaMiary"].Value.ToString();

                Action<string, int, DateTime, string> dodajIloscProduktu = DodajIloscProduktu;
                FormDodajIlosc formDodajIlosc = new FormDodajIlosc(nazwaTowaru, dostawca, opis, jednostkaMiary, dodajIloscProduktu);
                formDodajIlosc.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd: " + ex.Message);
            }
            OdswiezDataGridViewProdukty();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (var formPrzegladaj = new FormPrzegladajHistorie())
            {
                var result = formPrzegladaj.ShowDialog();
                if (result == DialogResult.OK)
                {
                    OdswiezDataGridViewProdukty();
                }

            }
            OdswiezDataGridViewProdukty();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormZapisDzienny formZapisDzienny = new FormZapisDzienny();
            formZapisDzienny.Show();
        }
    }
}


