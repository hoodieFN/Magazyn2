using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;
using TestowanieOprogramowania.Services;

namespace TestowanieOprogramowania
{
    public partial class FormDodajProdukt : Form
    {
        private readonly ProductService _productService;
        private readonly UserService _userService;

        public FormDodajProdukt(ProductService productService, UserService userService)
        {
            InitializeComponent();
            _productService = productService;
            _userService = userService;

            textBoxOpisTowaru.Width = 300;
            textBoxOpisTowaru.Height = 330;
            textBoxOpisTowaru.Multiline = true; // pozwala na wpisywanie wielu linii tekstu

            WypelnijRodzajeTowarow();
            comboBoxRodzajTowaru.SelectedIndexChanged += comboBoxRodzajTowaru_SelectedIndexChanged;
        }

        private void buttonDodajProdukt_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxNazwaTowaru.Text) ||
                    string.IsNullOrWhiteSpace(comboBoxRodzajTowaru.Text) ||
                    string.IsNullOrWhiteSpace(comboBoxJednostkaMiary.Text) ||
                    string.IsNullOrWhiteSpace(textBoxIlosc.Text) ||
                    string.IsNullOrWhiteSpace(textBoxCenaNetto.Text) ||
                    string.IsNullOrWhiteSpace(comboBoxStawkaVat.Text) ||
                    string.IsNullOrWhiteSpace(textBoxOpisTowaru.Text) ||
                    string.IsNullOrWhiteSpace(textBoxDostawca.Text))
                {
                    MessageBox.Show("Proszę wypełnić wszystkie pola.");
                    return;
                }

                string nazwaTowaru = textBoxNazwaTowaru.Text;
                string rodzajTowaru = comboBoxRodzajTowaru.Text;
                string jednostkaMiary = comboBoxJednostkaMiary.Text;
                int ilosc = Convert.ToInt32(textBoxIlosc.Text);
                decimal cenaNetto = Convert.ToDecimal(textBoxCenaNetto.Text);
                string stawkaVat = comboBoxStawkaVat.Text;
                string opisTowaru = textBoxOpisTowaru.Text;
                string dostawca = textBoxDostawca.Text;
                DateTime dataDostawy = dateTimePickerDataDostawy.Value;
                DateTime dataRejestracji = DateTime.Now;
                string imieNazwiskoRejestr = _userService.PobierzImieNazwisko(UserSession.CurrentUserId);

                if (_productService.ProduktIstnieje(nazwaTowaru))
                {
                    MessageBox.Show("Produkt już istnieje");
                    return;
                }
                else
                {
                    _productService.DodajProdukt(nazwaTowaru, rodzajTowaru, jednostkaMiary, ilosc, cenaNetto, stawkaVat,
                        opisTowaru, dostawca, dataDostawy, dataRejestracji, imieNazwiskoRejestr);
                }

                MessageBox.Show("Operacja zakończona pomyślnie.");
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Wprowadzono nieprawidłowy format danych. Sprawdź, czy liczby są poprawnie wpisane.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Błąd bazy danych: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var formEdytuj = new EdytujRodzajeTowarow())
            {
                comboBoxRodzajTowaru.Items.Clear();
                formEdytuj.FormClosed += (s, args) => WypelnijRodzajeTowarow();
                formEdytuj.ShowDialog();
            }
        }

        private void comboBoxRodzajTowaru_SelectedIndexChanged(object sender, EventArgs e)
        {
            string wybranyRodzaj = comboBoxRodzajTowaru.SelectedItem.ToString();
            string stawkaVAT = _productService.PobierzStawkeVAT(wybranyRodzaj);

            if (!string.IsNullOrEmpty(stawkaVAT))
            {
                comboBoxStawkaVat.SelectedItem = stawkaVAT;
            }
        }

        private void WypelnijRodzajeTowarow()
        {
            _productService.WypelnijRodzajeTowarow(comboBoxRodzajTowaru);
        }

        private void FormDodajProdukt_Load(object sender, EventArgs e)
        {
            // LoadRodzajeToComboBox();
        }
    }
}
