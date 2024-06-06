using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TestowanieOprogramowania.Services;

namespace TestowanieOprogramowania
{
    public partial class FormPrzegladajHistorie : Form
    {
        private readonly ProductService _productService;

        public FormPrzegladajHistorie()
        {
            InitializeComponent();
            string connectionString = PolaczenieBazyDanych.StringPolaczeniowy();
            _productService = new ProductService(connectionString);

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            OdswiezDataGridViewHistoriaAkcji();
        }

        private void FormPrzegladajHistorie_Load(object sender, EventArgs e)
        {
            // Additional initialization if needed
        }

        private void OdswiezDataGridViewHistoriaAkcji()
        {
            dataGridView1.DataSource = _productService.GetProductHistory();
        }

        private void OdswiezDataGridViewHistoriaAkcjiPoDacie()
        {
            DateTime selectedDate = dateTimePickerStart.Value.Date;
            dataGridView1.DataSource = _productService.GetProductHistoryByDate(selectedDate);
        }


        private void buttonSzukaj_Click(object sender, EventArgs e)
        {
            OdswiezDataGridViewHistoriaAkcjiPoDacie();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxProduktID.Text, out int produktID))
            {
                DataTable wynik = _productService.GetProductById(produktID);
                if (wynik.Rows.Count > 0)
                {
                    dataGridView1.DataSource = wynik;
                }
                else
                {
                    MessageBox.Show("Nie znaleziono produktu o podanym ID.");
                }
            }
            else
            {
                MessageBox.Show("Wprowadź prawidłowy ProduktID.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxID.Text, out int produktID))
            {
                DateTime data = dateTimePicker3.Value.Date;
                DataTable wynik = _productService.GetProductByIdAndDate(produktID, data);
                if (wynik.Rows.Count > 0)
                {
                    dataGridView1.DataSource = wynik;
                }
                else
                {
                    MessageBox.Show("Nie znaleziono produktu o podanym ID i dacie.");
                }
            }
            else
            {

                MessageBox.Show("Wprowadź prawidłowy ProduktID.");
            }
        }
    }

    public class ProductDetails
    {
        public int ProductID { get; set; }
        public string NazwaTowaru { get; set; }
        public string Rodzaj { get; set; }
        public DateTime DataRejestracji { get; set; }
        public string Rejestrujacy { get; set; }
    }
}
