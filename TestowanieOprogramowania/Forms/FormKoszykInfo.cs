using System;
using System.Data;
using System.Windows.Forms;
using TestowanieOprogramowania.Services;

namespace TestowanieOprogramowania
{
    public partial class FormKoszykInfo : Form
    {
        private readonly KoszykService _koszykService;

        public FormKoszykInfo(KoszykService koszykService)
        {
            InitializeComponent();
            _koszykService = koszykService;
        }



        public void LoadProductDetails(string nazwaTowaru)
        {
            try
            {
                DataTable koszykTable = _koszykService.GetProductDetails(nazwaTowaru);

                if (koszykTable.Rows.Count > 0)
                {
                    DataRow produkt = koszykTable.Rows[0];

                    // Wyświetlanie informacji w polach tekstowych
                    labelNazwaTowaru.Text = produkt["NazwaTowaru"].ToString();
                    labelIloscTowaru.Text = Convert.ToDecimal(produkt["IloscTowaru"]).ToString();
                    label3.Text = Convert.ToDecimal(produkt["CenaZaTowar"]).ToString();
                    labelNazwaKlienta.Text = produkt["NazwaKlienta"].ToString();
                    labelMiejscowosc.Text = produkt["Miejscowosc"].ToString();
                    labelKodPocztowy.Text = produkt["KodPocztowy"].ToString();
                    labelUlica.Text = produkt["Ulica"].ToString();
                    labelNrDomu.Text = produkt["NrDomu"].ToString();
                    labelDataSprzedazy.Text = Convert.ToDateTime(produkt["DataSprzedazy"]).ToString();
                }
                else
                {
                    MessageBox.Show("Nie znaleziono produktu w koszyku.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas ładowania szczegółów produktu: " + ex.Message);
            }
        }

        private void FormKoszykInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
