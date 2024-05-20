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
    public partial class FormZmianaVat : Form

    {
        private ZarzadzanieVoidami zarzadzanieVoidami;

        public FormZmianaVat()
        {
            InitializeComponent();
            zarzadzanieVoidami = new ZarzadzanieVoidami();
            DGVStawka.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();

            OdswiezDataGridViewProdukty();



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

        private void SzukajProdukt_Click(object sender, EventArgs e)
        {
            // Sprawdzenie, czy został wybrany element z comboBoxSzukaj
            if (comboBoxSzukaj1.SelectedItem == null)
            {
                MessageBox.Show("Proszę wybrać kryterium wyszukiwania z listy.");
                return;  // Zakończ funkcję, jeśli nic nie zostało wybrane
            }

            // Kontynuacja, jeśli element został wybrany
            string kryteriumWyszukiwania = comboBoxSzukaj1.SelectedItem.ToString();
            List<Produkt> listaProduktów = zarzadzanieVoidami.WyszukajProdukt(textBoxSzukajProduktu.Text, kryteriumWyszukiwania);
            DGVStawka.DataSource = listaProduktów;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Sprawdzenie, czy wybrano produkt
            if (DGVStawka.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać produkt.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Pobranie wybranego produktu
            string selectedProduct = DGVStawka.SelectedRows[0].Cells[1].Value.ToString();

            // Sprawdzenie poprawności wprowadzonej stawki VAT
            if (!decimal.TryParse(NowaStawka.Text, out decimal newVatRate))
            {
                MessageBox.Show("Proszę wprowadzić poprawną stawkę VAT.", "Błąd danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Wyświetlenie komunikatu z potwierdzeniem
            DialogResult result = MessageBox.Show($"Czy na pewno chcesz zmienić stawkę VAT dla produktu \"{selectedProduct}\"?", "Potwierdzenie zmiany", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Sprawdzenie odpowiedzi użytkownika
            if (result == DialogResult.Yes)
            {
                // Aktualizacja stawki VAT w bazie danych
                zarzadzanieVoidami.EdytowanieStawkiVat(newVatRate, selectedProduct);

                // Odświeżenie DataGridView
                OdswiezDataGridViewProdukty();


            }
            else
            {
                MessageBox.Show("zmiana stawki VAT została anulowana");
            }
        }
    } }
    
