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
    public partial class FormSprzedaze : Form
    {
        string con = PolaczenieBazyDanych.StringPolaczeniowy();
        private DataTable dataTable;
        public FormSprzedaze()
        {
            InitializeComponent();
            LoadData();

            // Add event handler for comboBoxColumns.SelectedIndexChanged
            comboBoxColumns.SelectedIndexChanged += comboBoxColumns_SelectedIndexChanged;
            // Add event handler for row double-click
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormRejestrujSprzedaz formRejestrujSprzedaz = new FormRejestrujSprzedaz();
            formRejestrujSprzedaz.FormClosed += new FormClosedEventHandler(FormRejestrujSprzedaz_FormClosed);
            formRejestrujSprzedaz.Show();
        }
        private void FormRejestrujSprzedaz_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData();
        }

        private void FormSprzedaze_Load(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            string query = @"
                            SELECT
                                s.IDSprzedazy as 'IDSprzedazy',
                                s.NazwaKlienta as Nabywca,
                                s.NazwaSprzedawcy as Sprzedawca,
                                s.DataSprzedazy as 'DataSprzedazy',
                                STUFF((SELECT ', ' + NazwaTowaru
                                       FROM [MagazynTestowanieOprogramowania].[dbo].[Sprzedaz] AS sub
                                       WHERE sub.IDSprzedazy = s.IDSprzedazy
                                       FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS 'Towary'
                            FROM 
                                [MagazynTestowanieOprogramowania].[dbo].[Sprzedaz] s
                            GROUP BY 
                                s.NazwaKlienta,
                                s.NazwaSprzedawcy,
                                s.DataSprzedazy,
                                s.IDSprzedazy
                            ORDER BY 
                                s.IDSprzedazy;
                            ";

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }



        private void FilterData(string filter, string column, DateTime? startDate, DateTime? endDate)
        {
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                string filterExpression = "";

                // Check if the selected column is a date column
                if (column == "DataSprzedazy")
                {
                    if (startDate.HasValue && endDate.HasValue)
                    {
                        filterExpression = $"[{column}] >= #{startDate.Value:yyyy-MM-dd}# AND [{column}] <= #{endDate.Value:yyyy-MM-dd}#";
                    }
                    else if (startDate.HasValue)
                    {
                        filterExpression = $"[{column}] >= #{startDate.Value:yyyy-MM-dd}#";
                    }
                    else if (endDate.HasValue)
                    {
                        filterExpression = $"[{column}] <= #{endDate.Value:yyyy-MM-dd}#";
                    }
                }
                else
                {
                    filterExpression = $"{column} LIKE '%{filter}%'";
                }

                dataView.RowFilter = filterExpression;
                dataGridView1.DataSource = dataView;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxColumns.SelectedItem == null)
            {
                MessageBox.Show("Zaznacz po jakiej kolumnie chcesz szuakć");
                return;
            }

            string filterText = textBoxFilter.Text;
            string selectedColumn = comboBoxColumns.SelectedItem.ToString();
            DateTime? startDate = dateTimePickerStart.Checked ? dateTimePickerStart.Value.Date : (DateTime?)null;
            DateTime? endDate = dateTimePickerEnd.Checked ? dateTimePickerEnd.Value.Date : (DateTime?)null;
            FilterData(filterText, selectedColumn, startDate, endDate);
        }



        private void comboBoxColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxColumns.SelectedItem != null)
            {
                string selectedColumn = comboBoxColumns.SelectedItem.ToString();

                if (selectedColumn == "DataSprzedazy")
                {
                    // Show date pickers and hide text box
                    dateTimePickerStart.Visible = true;
                    dateTimePickerEnd.Visible = true;
                    textBoxFilter.Visible = false;
                    labelOd.Visible = true;
                    labelDo.Visible = true;
                    label3.Visible = false;
                }
                else
                {
                    // Show text box and hide date pickers
                    textBoxFilter.Visible = true;
                    dateTimePickerStart.Visible = false;
                    dateTimePickerEnd.Visible = false;
                    labelOd.Visible = false;
                    labelDo.Visible = false;
                    label3.Visible = true;
                }
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                int idSprzedazy = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["IDSprzedazy"].Value);
                FormSprzedazDetails formDetails = new FormSprzedazDetails(idSprzedazy, con);
                formDetails.ShowDialog();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        /*
        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {

        }
        */
    }
}
