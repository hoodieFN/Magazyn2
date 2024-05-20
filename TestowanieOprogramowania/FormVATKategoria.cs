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
            {
                // Sprawdzenie, czy wybrano kategorię
                if (KategoriaTowaru.SelectedItem == null)
                {
                    MessageBox.Show("Proszę wybrać kategorię.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Pobranie wybranej kategorii
                string selectedCategory = KategoriaTowaru.SelectedItem.ToString();

                // Sprawdzenie poprawności wprowadzonej stawki VAT
                if (!decimal.TryParse(NowaStawka.Text, out decimal newVatRate))
                {
                    MessageBox.Show("Proszę wprowadzić poprawną stawkę VAT.", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Wyświetlenie komunikatu z potwierdzeniem
                DialogResult result = MessageBox.Show($"Czy na pewno chcesz zmienić stawkę VAT dla wszystkich produktów w kategorii \"{selectedCategory}\"?", "Potwierdzenie zmiany", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Sprawdzenie odpowiedzi użytkownika
                if (result == DialogResult.Yes)
                {
                    // Aktualizacja stawki VAT w bazie danych
                    string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();
                    string query = "UPDATE Produkty SET StawkaVat = @NewVatRate WHERE RodzajTowaru = @CategoryName";

                    using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@NewVatRate", newVatRate);
                            command.Parameters.AddWithValue("@CategoryName", selectedCategory);

                            try
                            {
                                connection.Open();
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Stawka VAT została zaktualizowana.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    OdswiezDataGridViewProdukty(); // Odśwież DataGridView
                                }
                                else
                                {
                                    MessageBox.Show("Nie znaleziono produktów w wybranej kategorii.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Wystąpił błąd podczas aktualizacji: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            OdswiezDataGridViewProdukty();

        }
    }
}
