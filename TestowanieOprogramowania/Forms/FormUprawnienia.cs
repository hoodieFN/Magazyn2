using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using TestowanieOprogramowania.Services;

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
        }

        private void FormUprawnienia_Load(object sender, EventArgs e)
        {
            WczytajDaneDoDataGridView2();
            OdswiezDataGridView();

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
                        transposedTable.Columns.Add("Lista dostępnych uprawnien");

                        foreach (DataColumn col in dataTable.Columns)
                        {
                            if (dataTable.Columns.IndexOf(col) > 1)
                            {
                                DataRow newRow = transposedTable.NewRow();
                                newRow[0] = col.ColumnName;
                                transposedTable.Rows.Add(newRow);
                            }
                        }

                        //dataGridView2.DataSource = transposedTable; // Assuming there is a dataGridView2 for displaying transposed data
                    }
                }
            }
        }

        private void OdswiezDataGridView()
        {
            string query = @"
                SELECT 
                    [UprawnienieID],
                    [Nazwa_stanowiska],
                    [DostepDoListyUzytkownikow],
                    [DostepDoListyUprawnien],
                    [DodawanieUzytkownika],
                    [UsuwanieUzytkownika],
                    [EdytowanieUzytkownika],
                    [DodawanieRoli],
                    [UsuwanieRoli],
                    [EdytowanieRoli],
                    [NadajZmienRoleStanowisko],
                    [ZmienHaslo],
                    [zmianaVAT],
                    [PrzegladStanuMagazynowego],
                    [PrzegladanieHistoriiStanuMagazynowego],
                    [PrzegladHistoriiUzupelniania],
                    [RejestracjaNowegoTowaru]
                FROM [MagazynTestowanieOprogramowania].[dbo].[Uprawnienia]";

            using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }

            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns["UprawnienieID"].HeaderText = "ID Roli";
            dataGridView1.Columns["Nazwa_stanowiska"].HeaderText = "Nazwa Roli";
            dataGridView1.Columns["NadajZmienRoleStanowisko"].HeaderText = "Nadaj/Zmień Role";
            dataGridView1.Columns["DostepDoListyUzytkownikow"].HeaderText = "Dostęp Do Listy Użytkowników";
            dataGridView1.Columns["DostepDoListyUprawnien"].HeaderText = "Dostęp Do Listy Uprawnień";
            dataGridView1.Columns["DodawanieUzytkownika"].HeaderText = "Dodawanie Użytkownika";
            dataGridView1.Columns["UsuwanieUzytkownika"].HeaderText = "Usuwanie Użytkownika";
            dataGridView1.Columns["EdytowanieUzytkownika"].HeaderText = "Edytowanie Użytkownika";
            dataGridView1.Columns["DodawanieRoli"].HeaderText = "Dodawanie Roli";
            dataGridView1.Columns["UsuwanieRoli"].HeaderText = "Usuwanie Roli";
            dataGridView1.Columns["EdytowanieRoli"].HeaderText = "Edytowanie Roli";
            dataGridView1.Columns["NadajZmienRoleStanowisko"].HeaderText = "Nadaj/Zmień Role/Stanowisko";
            dataGridView1.Columns["ZmienHaslo"].HeaderText = "Zmiana Hasła";
            dataGridView1.Columns["zmianaVAT"].HeaderText = "Zmiana stawki VAT";
            dataGridView1.Columns["PrzegladStanuMagazynowego"].HeaderText = "Przegląd stanów magazynowych (1,2)";
            dataGridView1.Columns["PrzegladanieHistoriiStanuMagazynowego"].HeaderText = "Przeglądanie Historii Stanu Magazynowego na wskazaną datę (3)";
            dataGridView1.Columns["PrzegladHistoriiUzupelniania"].HeaderText = "Przeglądanie Historii Uzupełniania Stanów Magazynowych";
            dataGridView1.Columns["RejestracjaNowegoTowaru"].HeaderText = "Rejestracja Nowego Towaru/Produktu";

            dataGridView1.AutoResizeColumnHeadersHeight();
        }

        private void buttonDodajRole_Click(object sender, EventArgs e)
        {
            RoleService roleService = new RoleService(StringPolaczeniowy);
            using (var formDodajRole = new FormDodajRole(roleService))
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
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz rolę do usunięcia.");
                return;
            }

            string nazwaRoli = dataGridView1.SelectedRows[0].Cells["Nazwa_stanowiska"].Value.ToString();

            var result = MessageBox.Show("Czy na pewno chcesz usunąć rolę: " + nazwaRoli + "?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM dbo.Uprawnienia WHERE Nazwa_stanowiska = @Nazwa";

                using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Nazwa", SqlDbType.NVarChar)).Value = nazwaRoli;
                        int rowsAffected = cmd.ExecuteNonQuery();

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
            else
            {
                MessageBox.Show("Usuwanie roli zostało anulowane.");
            }
        }

        private void buttonEdytujRole_Click(object sender, EventArgs e)
        {
            RoleService roleService = new RoleService(StringPolaczeniowy);
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int roleId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UprawnienieID"].Value);

                using (var formEdytuj = new FormEdytujRole(roleId, roleService))
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //test
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //test
        }
    }
}
