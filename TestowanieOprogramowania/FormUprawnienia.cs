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
            dataGridView2.Visible = false;
            dataGridView2.MaximumSize = new Size(420, dataGridView2.Height);
            WczytajDaneDoDataGridView2();
            OdswiezDataGridView();
            //comboBox1.SelectedIndex = 0;
            if (!ZarzadzanieVoidami.DodawanieRoli())
            {
                buttonDodajRole.Visible = false;
            }
            if (!ZarzadzanieVoidami.UsuwanieRoli())
            {
                buttonUsunRole.Visible = false;
            }
            if (!ZarzadzanieVoidami.EdytowanieRoli())
            {
                buttonEdytujRole.Visible = false;
            }

        }
        private void WczytajDaneDoDataGridView2()
        {
            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                string query = "SELECT * FROM dbo.Uprawnienia";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        DataTable transposedTable = new DataTable();

                        // Tworzenie jednej kolumny dla transponowanej tabeli
                        transposedTable.Columns.Add("Lista dostępnych uprawnien");

                        // Transpozycja - pomijamy dwie pierwsze kolumny
                        foreach (DataColumn col in dataTable.Columns)
                        {
                            if (dataTable.Columns.IndexOf(col) > 1) // Pomijamy dwie pierwsze kolumny
                            {
                                DataRow newRow = transposedTable.NewRow();
                                newRow[0] = col.ColumnName; // Ustawiamy nazwę kolumny jako wartość wiersza
                                transposedTable.Rows.Add(newRow);
                            }
                        }

                        dataGridView2.DataSource = transposedTable;
                    }
                }
            }
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

            // Wyświetlenie pytania z potwierdzeniem
            var result = MessageBox.Show("Czy na pewno chcesz usunąć rolę: " + nazwaRoli + "?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
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
                            // Odświeżenie dataGridView1
                            OdswiezDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Wystąpił błąd podczas usuwania roli.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Usuwanie roli zostało anulowane.");
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ZarzadzanieVoidami.CzyMaDostepDoListyUprawnien())
            {
                MessageBox.Show("Brak uprawnień w systemie.");
            }
            else
            {
                dataGridView2.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
        }
    }
}
