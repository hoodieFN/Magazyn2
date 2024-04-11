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
    public partial class FormUprawnienia : Form
    {
        private ZarzadzanieVoidami zarzadzanieVoidami;
        string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();
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

        private void buttonDodajRole_Click(object sender, EventArgs e)
        {
            using (var formDodajRole = new FormDodajRole())
            {

                var result = formDodajRole.ShowDialog();

                if (result == DialogResult.OK)
                {
                    OdswiezDataGridView();
                }
            }
        }

        private void buttonUsunRole_Click(object sender, EventArgs e)
        {
            // Sprawdzenie czy został wybrany wiersz w dataGridView1
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz rolę do usunięcia.");
                return;
            }

            // Pobranie nazwy roli z zaznaczonego wiersza dataGridView1
            string nazwaRoli = dataGridView1.SelectedRows[0].Cells["Nazwa_stanowiska"].Value.ToString();

            // Zapytanie SQL do usunięcia roli z bazy danych
            string query = "DELETE FROM dbo.Uprawnienia WHERE Nazwa_stanowiska = @Nazwa";

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Nazwa", SqlDbType.NVarChar)).Value = nazwaRoli;
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Sprawdzenie czy rola została pomyślnie usunięta
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Rola została pomyślnie usunięta.");
                        OdswiezDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Wystąpił błąd podczas usuwania roli.");
                    }
                }
            }
        }

        private void buttonEdytujRole_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Pobierz ID roli z zaznaczonego wiersza dataGridView1
                int roleId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UprawnienieID"].Value);

                // Utwórz nową instancję formularza FormEdytujRole, przekazując ID roli
                using (var formEdytuj = new FormEdytujRole(roleId))
                {
                    var result = formEdytuj.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        OdswiezDataGridView(); 
                    }
                }
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć wiersz do edycji", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
