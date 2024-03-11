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
    public partial class FormDodajUzytkownika : Form
    {//test ttuaj test
        public string conString;
        
        private string dataSource = "TUF15";
        public FormDodajUzytkownika()
        {
            InitializeComponent();
        }

        private void FormDodajUzytkownika_Load(object sender, EventArgs e)
        {

        }

        private void DodajUzytkownikaDoBazy(string imie, string nazwisko, string login, string numerTelefonu, string miejscowosc, string kodPocztowy,
            string ulica, string numerPosesji, string pesel, string dataUrodzenia, string plec, string email, string numerLokalu)
        {
            string connectionString = $"Data Source={dataSource};Initial Catalog=MagazynTestowanieOprogramowania;Integrated Security=True; TrustServerCertificate=True;";
            string query =
                "INSERT INTO dbo.Uzytkownicy (Login, Imie, Nazwisko, NumerTelefonu, Miejscowosc, KodPocztowy, Ulica, NumerPosesji, Pesel, DataUrodzenia, Plec, Email, NumerLokalu) "
                +
                "VALUES (@Login, @Imie, @Nazwisko, @NumerTelefonu, @Miejscowosc, @KodPocztowy, @Ulica, @NumerPosesji, @Pesel, @DataUrodzenia, @Plec, @Email, @NumerLokalu)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Login", SqlDbType.NVarChar)).Value = login;
                    cmd.Parameters.Add(new SqlParameter("@Imie", SqlDbType.NVarChar)).Value = imie;
                    cmd.Parameters.Add(new SqlParameter("@Nazwisko", SqlDbType.NVarChar)).Value = nazwisko;
                    cmd.Parameters.Add(new SqlParameter("@NumerTelefonu", SqlDbType.NVarChar)).Value = numerTelefonu;
                    cmd.Parameters.Add(new SqlParameter("@Miejscowosc", SqlDbType.NVarChar)).Value = miejscowosc;
                    cmd.Parameters.Add(new SqlParameter("@KodPocztowy", SqlDbType.NVarChar)).Value = kodPocztowy;
                    cmd.Parameters.Add(new SqlParameter("@Ulica", SqlDbType.NVarChar)).Value = ulica;
                    cmd.Parameters.Add(new SqlParameter("@NumerPosesji", SqlDbType.NVarChar)).Value = numerPosesji;
                    cmd.Parameters.Add(new SqlParameter("@PESEL", SqlDbType.NVarChar)).Value = pesel;
                    cmd.Parameters.Add(new SqlParameter("@DataUrodzenia", SqlDbType.DateTime)).Value = dataUrodzenia;
                    cmd.Parameters.Add(new SqlParameter("@Plec", SqlDbType.NVarChar)).Value = plec;
                    cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar)).Value = email;
                    cmd.Parameters.Add(new SqlParameter("@NumerLokalu", SqlDbType.NVarChar)).Value = numerLokalu;


                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            MessageBox.Show("Użytkownik został dodany.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonZapisz_Click(object sender, EventArgs e)
        {
            string imie = textBoxImie.Text;
            string nazwisko = textBoxNazwisko.Text;
            string login = textBoxLogin.Text;
            string numerTelefonu = textBoxNumerTelefonu.Text;
            string miejscowosc = textBoxMiejscowosc.Text;
            string kodPocztowy = textBoxKodPocztowy.Text;
            string ulica = textBoxUlica.Text;
            string numerPosesji = textBoxNumerPosesji.Text;
            string pesel = textBoxPesel.Text;
            string dataUrodzenia = textBoxDataUrodzenia.Text;
            string plec = textBoxPlec.Text;
            string email = textBoxEmail.Text;
            string numerLokalu = textBoxNumerLokalu.Text;

            DodajUzytkownikaDoBazy(imie, nazwisko, login, numerTelefonu, miejscowosc, kodPocztowy, ulica, numerPosesji, pesel, dataUrodzenia, plec, email, numerLokalu);
        }
    }
}
