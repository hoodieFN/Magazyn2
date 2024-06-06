using System;
using System.Windows.Forms;
using TestowanieOprogramowania.Services;

namespace TestowanieOprogramowania
{
    public partial class FormDodajIlosc : Form
    {
        private readonly string _nazwaTowaru;
        private readonly string _dostawca;
        private readonly string _opis;
        private readonly string _jednostkaMiary;
        private readonly Action<string, int, DateTime, string> _dodajIloscProduktu;
        private readonly UserService _userService;

        public FormDodajIlosc(string nazwaTowaru, string dostawca, string opis, string jednostkaMiary, Action<string, int, DateTime, string> dodajIloscProduktu, UserService userService)
        {
            InitializeComponent();
            _nazwaTowaru = nazwaTowaru;
            _dostawca = dostawca;
            _opis = opis;
            _jednostkaMiary = jednostkaMiary;
            _dodajIloscProduktu = dodajIloscProduktu;
            _userService = userService;

            labelNazwaTowaru.Text = $"Nazwa towaru: {_nazwaTowaru}";
            labelDostawca.Text = $"Dostawca: {_dostawca}";
            labelOpis.Text = $"Opis: {_opis}";
            labelJednostkaMiary.Text = $"Jednostka miary: {_jednostkaMiary}";
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            int ilosc = (int)numericUpDownIlosc.Value;
            DateTime dataRejestracji = DateTime.Now;
            string rejestracja = _userService.PobierzImieNazwisko(UserSession.CurrentUserId);

            _dodajIloscProduktu(_nazwaTowaru, ilosc, dataRejestracji, rejestracja);
            MessageBox.Show("Ilość została zaktualizowana.");
            this.Close();
        }

        private void FormDodajIlosc_Load(object sender, EventArgs e)
        {

        }
    }
}
