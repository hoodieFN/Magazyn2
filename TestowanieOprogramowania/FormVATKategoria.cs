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
    public partial class FormVATKategoria : Form
    {
        private ZarzadzanieVoidami zarzadzanieVoidami;

        public FormVATKategoria()
        {
            InitializeComponent();
            zarzadzanieVoidami = new ZarzadzanieVoidami();
            DGVStawka.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();

            OdswiezDataGridViewProdukty();
            FormVatKategoria();
        }
        private void OdswiezDataGridViewProdukty()
        {
            var listaProduktów = zarzadzanieVoidami.PobierzPodukty();
            DGVStawka.DataSource = listaProduktów;
            if (listaProduktów == null || listaProduktów.Count == 0)
            {
                MessageBox.Show("Brak danych do wyświetlenia.");
            }

        }
        private void FormVatKategoria() // Konieczne było dodanie modyfikatora dostępu private
        {
            string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();
            string query = "SELECT NazwaRodzaju FROM RodzajeTowarow";

            using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            KategoriaTowaru.Items.Add(reader["NazwaRodzaju"].ToString()); // Poprawka: nazwa kolumny w bazie danych
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Wystąpił błąd podczas ładowania kategorii: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Sprawdzenie, czy wybrano kategorię
            if (KategoriaTowaru.SelectedItem == null)
            {
                MessageBox.Show("Proszę wybrać kategorię.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Proszę wybrać stawkę VAT.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Pobranie wybranej kategorii
            string selectedCategory = KategoriaTowaru.SelectedItem.ToString();
            string newVatRate = comboBox1.SelectedItem.ToString();

            // Wyświetlenie komunikatu z potwierdzeniem
            DialogResult result = MessageBox.Show($"Czy na pewno chcesz zmienić stawkę VAT dla wszystkich produktów w kategorii \"{selectedCategory}\"?", "Potwierdzenie zmiany", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Sprawdzenie odpowiedzi użytkownika
            if (result == DialogResult.Yes)
            {
                // Aktualizacja stawki VAT w bazie danych
                string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();
                string queryProdukty = "UPDATE Produkty SET StawkaVat = @NewVatRate WHERE RodzajTowaru = @CategoryName";
                string queryRodzajeTowarow = "UPDATE RodzajeTowarow SET StawkaVAT = @NewVatRate WHERE NazwaRodzaju = @CategoryName";

                using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
                {
                    using (SqlCommand commandProdukty = new SqlCommand(queryProdukty, connection))
                    using (SqlCommand commandRodzajeTowarow = new SqlCommand(queryRodzajeTowarow, connection))
                    {
                        commandProdukty.Parameters.AddWithValue("@NewVatRate", newVatRate);
                        commandProdukty.Parameters.AddWithValue("@CategoryName", selectedCategory);

                        commandRodzajeTowarow.Parameters.AddWithValue("@NewVatRate", newVatRate);
                        commandRodzajeTowarow.Parameters.AddWithValue("@CategoryName", selectedCategory);

                        try
                        {
                            connection.Open();
                            int rowsAffectedProdukty = commandProdukty.ExecuteNonQuery();
                            int rowsAffectedRodzajeTowarow = commandRodzajeTowarow.ExecuteNonQuery();

                            if (rowsAffectedProdukty > 0 || rowsAffectedRodzajeTowarow > 0)
                            {
                                MessageBox.Show("Stawka VAT została zaktualizowana.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                OdswiezDataGridViewProdukty(); // Odśwież DataGridView
                            }
                            else
                            {
                                MessageBox.Show("Nie znaleziono produktów w wybranej kategorii lub kategorii w tabeli rodzajów.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Wystąpił błąd podczas aktualizacji: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            OdswiezDataGridViewProdukty();
        }


        private void FormVATKategoria_Load(object sender, EventArgs e)
        {

        }
    }
}
