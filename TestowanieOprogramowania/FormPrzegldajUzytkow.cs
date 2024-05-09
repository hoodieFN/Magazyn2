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
    public partial class FormPrzegldajUzytkow : Form
    {
        string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();
        public FormPrzegldajUzytkow()
        {
            InitializeComponent();
        }

        private void FormPrzegldajUzytkow_Load(object sender, EventArgs e)
        {
            ZaładujUprawnieniaDoComboBox();
        }
        private void ZaładujUprawnieniaDoComboBox()
        {
            using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Uprawnienia WHERE 1 = 0", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.KeyInfo))
                        {
                            DataTable schemaTable = reader.GetSchemaTable();
                            foreach (DataRow row in schemaTable.Rows)
                            {
                                if (row["ColumnName"].ToString() != "UprawnienieID" && row["ColumnName"].ToString() != "Nazwa_stanowiska")
                                {
                                    comboBoxUprawnienia.Items.Add(row["ColumnName"].ToString());
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd podczas ładowania uprawnień: " + ex.Message);
                }
            }
        }
        private void comboBoxUprawnienia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void WczytajUzytkownikowZUprawnieniem(string uprawnienie)
        {
            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                string query = $@"
            SELECT u.UzytkownikID, u.Login, u.Imie, u.Nazwisko
            FROM dbo.Uzytkownicy AS u JOIN dbo.Uprawnienia AS up ON u.IDUprawnienia = up.UprawnienieID
            WHERE {uprawnienie} = 'Tak' AND u.archiwizacja = 1";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewUzytkownicy.DataSource = dataTable;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string wybraneUprawnienie = comboBoxUprawnienia.SelectedItem?.ToString() ?? "Domyślna wartość";
                WczytajUzytkownikowZUprawnieniem(wybraneUprawnienie);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Zaznacz uprawnienie");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bląd. Upewnij się czy wybrałeś uprawnienie");
            }

        }

        private void comboBoxUprawnienia_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
