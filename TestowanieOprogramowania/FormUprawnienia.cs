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
    public partial class FormUprawnienia : Form
    {
        private ZarzadzanieVoidami zarzadzanieVoidami;
        public FormUprawnienia()
        {
            InitializeComponent();
            zarzadzanieVoidami = new ZarzadzanieVoidami();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();
        }

        private void FormUprawnienia_Load(object sender, EventArgs e)
        {
            OdswiezDataGridView();
            comboBox1.SelectedIndex = 0;

        }

        private void OdswiezDataGridView()
        {
            var listaUprawnien = zarzadzanieVoidami.PobierzUprawnienia();

            if (listaUprawnien.Count == 0)
            {
                MessageBox.Show("Lista uprawnień jest pusta.");
            }
            else
            {
                dataGridView1.DataSource = listaUprawnien;
            }
        }



    }
}
