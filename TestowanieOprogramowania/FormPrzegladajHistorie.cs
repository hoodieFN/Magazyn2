using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace TestowanieOprogramowania
{
    public partial class FormPrzegladajHistorie : Form
    {
        private ZarzadzanieVoidami zarzadzanieVoidami;
        string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();

        public FormPrzegladajHistorie()
        {
            InitializeComponent();

            zarzadzanieVoidami = new ZarzadzanieVoidami();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Ukrywanie DateTimePickerów i CheckBox na starcie
            //dateTimePickerStart.Visible = false;
            // dateTimePickerEnd.Visible = false;
            //  label3.Visible = false;
            // label4.Visible = false;
            // checkBoxOkres.Visible = true;

            //  comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            // checkBoxOkres.CheckedChanged += CheckBoxOkres_CheckedChanged;
            // buttonSzukaj.Click += buttonSzukaj_Click;

            OdswiezDataGridViewHistoriaAkcji();
        }

        private void FormPrzegladajHistorie_Load(object sender, EventArgs e)
        {
        }

        private void OdswiezDataGridViewHistoriaAkcji()
        {
            string query = @"
                SELECT [ProduktID]
                  ,[NazwaTowaru]
                  ,[RodzajTowaru]
                  ,[JednostkaMiary]
                  ,[Ilosc]
                  ,[CenaNetto]
                  ,[StawkaVAT]
                  ,[Opis]
                  ,[Dostawca]
                  ,[DataDostawy]
                  ,[DataRejestracji]
                  ,[Rejestrujacy]
                  ,[DataZapisu]     
                FROM 
                    ProduktyHistoria";

            using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
        }
        private void OdswiezDataGridViewHistoriaAkcjiPoDacie()
        {
            // Pobierz datę z kontrolki DateTimePicker
            DateTime selectedDate = dateTimePickerStart.Value.Date;

            // Formatuj datę na postać, która jest kompatybilna z SQL
            string formattedDate = selectedDate.ToString("yyyy-MM-dd");

            // Zapytanie SQL z filtrem na podstawie daty
            string query = @"
        SELECT [ProduktID]
              ,[NazwaTowaru]
              ,[RodzajTowaru]
              ,[JednostkaMiary]
              ,[Ilosc]
              ,[CenaNetto]
              ,[StawkaVAT]
              ,[Opis]
              ,[Dostawca]
              ,[DataDostawy]
              ,[DataRejestracji]
              ,[Rejestrujacy]
              ,[DataZapisu]
        FROM 
            ProduktyHistoria
        WHERE 
            DataZapisu = @DataZapisu";

            using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Dodaj parametr z datą do zapytania
                    command.Parameters.AddWithValue("@DataZapisu", formattedDate);

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        /*
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Okres")
            {
                dateTimePickerStart.Visible = true;
                dateTimePickerEnd.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                checkBoxOkres.Visible = false;
            }
            else
            {
                dateTimePickerStart.Visible = checkBoxOkres.Checked;
                dateTimePickerEnd.Visible = checkBoxOkres.Checked;
                label3.Visible = checkBoxOkres.Checked;
                label4.Visible = checkBoxOkres.Checked;
                checkBoxOkres.Visible = true;
            }
        }
        */
        /*
        private void CheckBoxOkres_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = checkBoxOkres.Checked;
            dateTimePickerStart.Visible = isChecked;
            dateTimePickerEnd.Visible = isChecked;
            label3.Visible = isChecked;
            label4.Visible = isChecked;
        }
        */

        /*
        private void buttonSzukaj_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Proszę wybrać kryterium wyszukiwania.");
                return;
            }

            string searchText = textBoxSearchText.Text;
            string option = comboBox1.SelectedItem.ToString();

            if (option == "Okres" || (checkBoxOkres.Checked && option != "Okres"))
            {
                if (dateTimePickerEnd.Value < dateTimePickerStart.Value)
                {
                    MessageBox.Show("Data końcowa nie może być wcześniejsza niż data początkowa.");
                    return;
                }

                SearchData(searchText, option, dateTimePickerStart.Value, dateTimePickerEnd.Value);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    MessageBox.Show("Proszę wprowadzić tekst wyszukiwania.");
                    return;
                }

                SearchData(searchText, option);
            }
        }
        */

        private void SearchData(string searchText, string option, DateTime? startDate = null, DateTime? endDate = null)
        {
            string query = @"SELECT ProductID, NazwaTowaru, Rodzaj, DataRejestracji, Rejestrujacy FROM ProductDetails WHERE ";

            List<SqlParameter> parameters = new List<SqlParameter>();
            if (option == "Okres")
            {
                query += "DataRejestracji BETWEEN @startDate AND @endDate";
                parameters.Add(new SqlParameter("@startDate", SqlDbType.DateTime) { Value = startDate.Value.Date });
                parameters.Add(new SqlParameter("@endDate", SqlDbType.DateTime) { Value = endDate.Value.Date.AddDays(1).AddTicks(-1) });
            }
            else
            {
                query += $"{option} LIKE @search";
                parameters.Add(new SqlParameter("@search", SqlDbType.NVarChar) { Value = "%" + searchText + "%" });

                if (startDate.HasValue && endDate.HasValue)
                {
                    query += " AND DataRejestracji BETWEEN @startDate AND @endDate";
                    parameters.Add(new SqlParameter("@startDate", SqlDbType.DateTime) { Value = startDate.Value.Date });
                    parameters.Add(new SqlParameter("@endDate", SqlDbType.DateTime) { Value = endDate.Value.Date.AddDays(1).AddTicks(-1) });
                }
            }

            List<ProductDetails> listaProduktow = new List<ProductDetails>();

            using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters.ToArray());

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductDetails produkt = new ProductDetails
                            {
                                ProductID = Convert.ToInt32(reader["ProductID"]),
                                NazwaTowaru = reader["NazwaTowaru"].ToString(),
                                Rodzaj = reader["Rodzaj"].ToString(),
                                DataRejestracji = Convert.ToDateTime(reader["DataRejestracji"]),
                                Rejestrujacy = reader["Rejestrujacy"].ToString()
                            };
                            listaProduktow.Add(produkt);
                        }
                    }
                }
            }
            dataGridView1.DataSource = listaProduktow;
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonSzukaj_Click(object sender, EventArgs e)
        {
            OdswiezDataGridViewHistoriaAkcjiPoDacie();
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
