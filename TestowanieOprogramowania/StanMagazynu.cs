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

        private void button1_Click(object sender, EventArgs e)
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
    }
}
