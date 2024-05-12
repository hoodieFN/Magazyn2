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
    public partial class FormPrzegladajHistorie : Form
    {
        private ZarzadzanieVoidami zarzadzanieVoidami;
        string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();
        public FormPrzegladajHistorie()
        {
            InitializeComponent();

            zarzadzanieVoidami = new ZarzadzanieVoidami();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dateTimePickerStart.Visible = false;
            dateTimePickerEnd.Visible = false;


            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

            OdswiezDataGridViewHistoriaAkcji();
        }

        private void FormPrzegladajHistorie_Load(object sender, EventArgs e)
        {

        }

        private void OdswiezDataGridViewHistoriaAkcji()
        {
            string query = @"
        SELECT 
            ProductID,         
            NazwaTowaru,       
            Rodzaj,         
            DataRejestracji,   
            Rejestrujacy      
        FROM 
            ProductDetails";

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



        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "okres")
            {
                dateTimePickerStart.Visible = true;
                dateTimePickerEnd.Visible = true;
            }
            else
            {
                dateTimePickerStart.Visible = false;
                dateTimePickerEnd.Visible = false;
            }
        }

        private void buttonSzukaj_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Proszę wybrać kryterium wyszukiwania.");
                return;
            }

            string searchText = textBoxSearchText.Text;
            string option = comboBox1.SelectedItem.ToString();

            if (option == "okres" && dateTimePickerEnd.Value < dateTimePickerStart.Value)
            {
                MessageBox.Show("Data końcowa nie może być wcześniejsza niż data początkowa.");
                return;
            }

            SearchData(searchText, option);
        }

        private void SearchData(string searchText, string option)
        {
            string baseQuery = @"SELECT ProductID, NazwaTowaru, Rodzaj, DataRejestracji, Rejestrujacy FROM ProductDetails";
            List<string> conditions = new List<string>();

            if (option == "okres")
            {
                conditions.Add("DataRejestracji BETWEEN @startDate AND @endDate");
            }
            else if (option == "nazwa towaru")
            {
                conditions.Add("NazwaTowaru LIKE @search");
            }
            else if (option == "rejestrujacy")
            {
                conditions.Add("Rejestrujacy LIKE @search");
            }
            else if(option == "Rodzaj")
            {
                conditions.Add("Rodzaj LIKE @search");
            }
            if (conditions.Count > 0)
            {
                baseQuery += " WHERE " + string.Join(" AND ", conditions);
            }

            using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
            {
                using (SqlCommand command = new SqlCommand(baseQuery, connection))
                {
                    if (option == "okres")
                    {
                        command.Parameters.AddWithValue("@startDate", dateTimePickerStart.Value);
                        command.Parameters.AddWithValue("@endDate", dateTimePickerEnd.Value);
                    }
                    else if (option != "okres" && !string.IsNullOrWhiteSpace(searchText))
                    {
                        command.Parameters.AddWithValue("@search", $"%{searchText}%");
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
        }
    }



}
