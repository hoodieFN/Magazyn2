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
            List<Produkt> listaProduktów = zarzadzanieVoidami.WyszukajProdukt(textBoxSzukajProduktu.Text, comboBoxSzukaj.SelectedItem.ToString());
            dataGridView2.DataSource = listaProduktów;
        }
    }
}
