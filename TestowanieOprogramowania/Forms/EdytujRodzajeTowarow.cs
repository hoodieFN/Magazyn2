using System;
using System.Data;
using System.Windows.Forms;
using TestowanieOprogramowania.Services;

namespace TestowanieOprogramowania
{
    public partial class EdytujRodzajeTowarow : Form
    {
        private readonly RodzajeTowarowService _rodzajeTowarowService;

        public EdytujRodzajeTowarow()
        {
            InitializeComponent();
            string con = PolaczenieBazyDanych.StringPolaczeniowy();
            _rodzajeTowarowService = new RodzajeTowarowService(con);
        }

        private void EdytujRodzajeTowarow_Load(object sender, EventArgs e)
        {
            WczytajRodzajeTowarow();
        }

        private void WczytajRodzajeTowarow()
        {
            dataGridView1.DataSource = _rodzajeTowarowService.PobierzRodzajeTowarow();
        }

        private void DodajNazweRodzaju(string nazwaRodzaju, string stawkaVAT)
        {
            _rodzajeTowarowService.DodajRodzajTowaru(nazwaRodzaju, stawkaVAT);
        }

        private void UsunZaznaczonyWiersz(int rodzajTowaruId)
        {
            _rodzajeTowarowService.UsunRodzajTowaru(rodzajTowaruId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nazwaRodzaju = textBoxNazwaTowaru.Text;
            string selectedStawkaVAT = listBoxStawkaVAT.Text;

            if (!CzyDaneSaPoprawne(nazwaRodzaju, selectedStawkaVAT))
                return;

            DodajNazweRodzaju(nazwaRodzaju, selectedStawkaVAT);
            WczytajRodzajeTowarow();
        }

        private bool CzyDaneSaPoprawne(string nazwaRodzaju, string stawkaVAT)
        {
            if (string.IsNullOrWhiteSpace(nazwaRodzaju))
            {
                MessageBox.Show("Proszę wpisać nazwę rodzaju.", "Brak nazwy rodzaju", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(stawkaVAT))
            {
                MessageBox.Show("Proszę wybrać stawkę VAT.", "Brak stawki VAT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rodzajTowaruId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["RodzajTowaruID"].Value);
                UsunZaznaczonyWiersz(rodzajTowaruId);
                WczytajRodzajeTowarow();
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć wiersz do usunięcia.");
            }
        }
    }
}
