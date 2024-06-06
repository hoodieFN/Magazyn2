using System;
using System.Data;
using System.Windows.Forms;
using TestowanieOprogramowania.Services;

namespace TestowanieOprogramowania
{
    public partial class FormHUSM : Form
    {
        private readonly ProductHistoryService _productHistoryService;

        public FormHUSM(ProductHistoryService productHistoryService)
        {
            InitializeComponent();
            _productHistoryService = productHistoryService;
            DefaultHUSM();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Visible = comboBox1.SelectedItem.ToString() != "Okres";
            dateTimePickerStart1.Visible = comboBox1.SelectedItem.ToString() == "Okres";
            dateTimePickerEnd.Visible = comboBox1.SelectedItem.ToString() == "Okres";
        }

        private void UstawSzerokoscKolumny()
        {
            dataGridView1.Columns["Operacja"].Width = (int)(dataGridView1.Columns["Operacja"].Width * 2);
            dataGridView1.Columns["DataZapisu"].Width = (int)(dataGridView1.Columns["DataZapisu"].Width * 1.2);
        }

        private void HUSM()
        {
            try
            {
                string filterType = comboBox1.SelectedItem?.ToString();
                string filterValue = textBox1.Text;
                DateTime? startDate = null, endDate = null;

                if (filterType == "Okres")
                {
                    startDate = dateTimePickerStart1.Value.Date;
                    endDate = dateTimePickerEnd.Value.Date;
                }

                DataTable dataTable = _productHistoryService.PobierzHistorieProduktu(startDate, endDate, filterType, filterValue);
                dataGridView1.DataSource = dataTable;

                if (dataGridView1.Columns["DataZapisu"] != null)
                {
                    dataGridView1.Columns["DataZapisu"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas ładowania historii: " + ex.Message);
            }
        }

        private void DefaultHUSM()
        {
            try
            {
                DataTable dataTable = _productHistoryService.PobierzHistorieProduktu();
                dataGridView1.DataSource = dataTable;

                if (dataGridView1.Columns["DataZapisu"] != null)
                {
                    dataGridView1.Columns["DataZapisu"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas ładowania domyślnej historii: " + ex.Message);
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
