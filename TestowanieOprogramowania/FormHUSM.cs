using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace TestowanieOprogramowania
{
    public partial class FormHUSM : Form
    {
        private ZarzadzanieVoidami zarzadzanieVoidami;
        string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();

        public FormHUSM()
        {
            InitializeComponent();
           // HUSM();
            DefaultHUSM();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check the selected item in comboBox1
            if (comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedItem.ToString() == "Okres")
                {
                    textBox1.Visible = false; // Hide textBox1
                    dateTimePickerStart1.Visible = true;
                    dateTimePickerEnd.Visible = true;
                }
                else if (comboBox1.SelectedItem.ToString() == "Rodzaje towarów")
                {
                    textBox1.Visible = true; // Show textBox1
                    dateTimePickerStart1.Visible = false;
                    dateTimePickerEnd.Visible = false;
                }
                else if (comboBox1.SelectedItem.ToString() == "Nazwy towarów")
                {
                    textBox1.Visible = true; // Show textBox1
                    dateTimePickerStart1.Visible = false;
                    dateTimePickerEnd.Visible = false;
                }
                else if (comboBox1.SelectedItem.ToString() == "Rejestrujacy")
                {
                    textBox1.Visible = true; // Show textBox1
                    dateTimePickerStart1.Visible = false;
                    dateTimePickerEnd.Visible = false;
                }
            }
        }

        private void UstawSzerokoscKolumny()
        {
            // Pobierz bieżącą szerokość kolumny "Operacja"
            int currentWidth = dataGridView1.Columns["Operacja"].Width;

            // Oblicz nową szerokość jako 2 razy bieżącą szerokość
            int newWidth = (int)(currentWidth * 2);

            // Ustaw nową szerokość kolumny "Operacja"
            dataGridView1.Columns["Operacja"].Width = newWidth;

            // Pobierz bieżącą szerokość kolumny "DataZapisu"
            int currentWidth2 = dataGridView1.Columns["DataZapisu"].Width;

            // Oblicz nową szerokość jako 1.2 razy bieżącą szerokość
            int newWidth2 = (int)(currentWidth2 * 1.2);

            // Ustaw nową szerokość kolumny "DataZapisu"
            dataGridView1.Columns["DataZapisu"].Width = newWidth2;
        }



        private void HUSM()
        {
            // Check if any value is selected in comboBox1
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Zaznacz kryterium w combobox", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Handle selection for "Okres"
            if (comboBox1.SelectedItem.ToString() == "Okres")
            {
                DateTime startDate = dateTimePickerStart1.Value.Date;
                DateTime endDate = dateTimePickerEnd.Value.Date;

                string query = @"SELECT TOP (1000) [ProduktID]
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
                          ,[Operacja]
                      FROM [MagazynTestowanieOprogramowania].[dbo].[ProduktyHistoriaOperacji]
                      WHERE DataZapisu BETWEEN @StartDate AND @EndDate";

                using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);

                        DataTable dataTable = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                        // Formatowanie kolumny DataZapisu aby wyświetlała datę i czas
                        if (dataGridView1.Columns["DataZapisu"] != null)
                        {
                            dataGridView1.Columns["DataZapisu"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        }
                    }
                }
            }
            //  "Rodzaje towarów"
            else if (comboBox1.SelectedItem.ToString() == "Rodzaje towarów")
            {
                string rodzajTowaru = textBox1.Text;

                string query = @"SELECT TOP (1000) [ProduktID]
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
                          ,[Operacja]
                      FROM [MagazynTestowanieOprogramowania].[dbo].[ProduktyHistoriaOperacji]
                      WHERE @RodzajTowaru = '' OR RodzajTowaru LIKE @RodzajTowaru";

                using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // If the text box is empty, set the parameter to an empty string, else set it to the wildcard search term
                        command.Parameters.AddWithValue("@RodzajTowaru", string.IsNullOrEmpty(rodzajTowaru) ? "" : "%" + rodzajTowaru + "%");

                        DataTable dataTable = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                        // Formatowanie kolumny DataZapisu aby wyświetlała datę i czas
                        if (dataGridView1.Columns["DataZapisu"] != null)
                        {
                            dataGridView1.Columns["DataZapisu"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        }
                    }
                }

            }
            else if (comboBox1.SelectedItem.ToString() == "Nazwy towarów")
            {
                string nazwaTowaru = textBox1.Text;

                string query = @"SELECT TOP (1000) [ProduktID]
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
                          ,[Operacja]
                      FROM [MagazynTestowanieOprogramowania].[dbo].[ProduktyHistoriaOperacji]
                      WHERE @NazwaTowaru = '' OR NazwaTowaru LIKE @NazwaTowaru";

                using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NazwaTowaru", string.IsNullOrEmpty(nazwaTowaru) ? "" : "%" + nazwaTowaru + "%");

                        DataTable dataTable = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                        // Formatowanie kolumny DataZapisu aby wyświetlała datę i czas
                        if (dataGridView1.Columns["DataZapisu"] != null)
                        {
                            dataGridView1.Columns["DataZapisu"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        }
                    }
                }

            }
            else if (comboBox1.SelectedItem.ToString() == "Rejestrujacy")
            {
                string rejestrujący = textBox1.Text;

                string query = @"SELECT TOP (1000) [ProduktID]
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
                          ,[Operacja]
                      FROM [MagazynTestowanieOprogramowania].[dbo].[ProduktyHistoriaOperacji]
                      WHERE @Rejestrujacy = '' OR Rejestrujacy LIKE @Rejestrujacy";

                using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Rejestrujacy", string.IsNullOrEmpty(rejestrujący) ? "" : "%" + rejestrujący + "%");

                        DataTable dataTable = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                        // Formatowanie kolumny DataZapisu aby wyświetlała datę i czas
                        if (dataGridView1.Columns["DataZapisu"] != null)
                        {
                            dataGridView1.Columns["DataZapisu"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        }
                    }
                }

            }
        }

        private void DefaultHUSM()
        {
            string query = @"SELECT TOP (1000) [ProduktID]
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
                  ,[Operacja]
              FROM [MagazynTestowanieOprogramowania].[dbo].[ProduktyHistoriaOperacji]";

            using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;

                    // Formatowanie kolumny DataZapisu aby wyświetlała datę i czas
                    if (dataGridView1.Columns["DataZapisu"] != null)
                    {
                        dataGridView1.Columns["DataZapisu"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    }
                }
            }
        }

        private void SzukajProdukt_Click(object sender, EventArgs e)
        {
            HUSM();
        }

        private void FormHUSM_Load(object sender, EventArgs e)
        {
            UstawSzerokoscKolumny();
        }
    }
}
