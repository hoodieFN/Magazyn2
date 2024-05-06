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
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            OdswiezDataGridViewProdukty();
            comboBox1.SelectedIndex = 0;
        

        }
        private void OdswiezDataGridViewProdukty()
        {
            var listaProduktów = zarzadzanieVoidami.PobierzPodukty();
            dataGridView1.DataSource = listaProduktów;
           
        }



    }
}
