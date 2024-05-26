using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace TestowanieOprogramowania
{
    public partial class FormDodajIlosc : Form
    {
        private string _nazwaTowaru;
        private string _dostawca;
        private string _opis;
        private string _jednostkaMiary;
        private Action<string, int, DateTime, string> _dodajIloscProduktu;

        public FormDodajIlosc(string nazwaTowaru, string dostawca, string opis, string jednostkaMiary, Action<string, int, DateTime, string> dodajIloscProduktu)
        {
            InitializeComponent();
            _nazwaTowaru = nazwaTowaru;
            _dostawca = dostawca;
            _opis = opis;
            _jednostkaMiary = jednostkaMiary;
            _dodajIloscProduktu = dodajIloscProduktu;

            labelNazwaTowaru.Text = $"Nazwa towaru: {_nazwaTowaru}";
            labelDostawca.Text = $"Dostawca: {_dostawca}";
            labelOpis.Text = $"Opis: {_opis}";
            labelJednostkaMiary.Text = $"Jednostka miary: {_jednostkaMiary}";
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            int ilosc = (int)numericUpDownIlosc.Value;
            DateTime dataRejestracji = DateTime.Now;
            string rejestracja = PobierzImieNazwisko(UserSession.CurrentUserId);

            _dodajIloscProduktu(_nazwaTowaru, ilosc, dataRejestracji, rejestracja);
            MessageBox.Show("Ilość została zaktualizowana.");
            this.Close();
        }

        public string PobierzImieNazwisko(int userId)
        {
            string con = PolaczenieBazyDanych.StringPolaczeniowy();
            string fullName = "";

            using (SqlConnection connection = new SqlConnection(con))
            {
                string query = "SELECT CONCAT(Imie, ' ', Nazwisko) AS PelneImieNazwisko FROM Uzytkownicy WHERE UzytkownikID = @UzytkownikID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UzytkownikID", userId);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                        fullName = result.ToString();
                }
            }

            return fullName;
        }

        private void FormDodajIlosc_Load(object sender, EventArgs e)
        {

        }
    }
}
