using System;
using System.Data;
using System.Windows.Forms;
using TestowanieOprogramowania.Services;

namespace TestowanieOprogramowania
{
    public partial class FormEdytujRole : Form
    {
        private readonly RoleService _roleService;
        private readonly int _roleId;
        private string _currentName;

        public FormEdytujRole(int roleId, RoleService roleService)
        {
            InitializeComponent();
            _roleId = roleId;
            _roleService = roleService;
            WczytajDaneRoli();
        }

        private void WczytajDaneRoli()
        {
            DataTable dt = _roleService.PobierzDaneRoli(_roleId);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                textBoxNazwa.Text = row["Nazwa_stanowiska"].ToString();
                _currentName = row["Nazwa_stanowiska"].ToString();
                comboBoxListUz.SelectedItem = row["DostepDoListyUzytkownikow"].ToString();
                comboBoxListUp.SelectedItem = row["DostepDoListyUprawnien"].ToString();
                comboBoxDodUz.SelectedItem = row["DodawanieUzytkownika"].ToString();
                comboBoxUsuUz.SelectedItem = row["UsuwanieUzytkownika"].ToString();
                comboBoxEdUz.SelectedItem = row["EdytowanieUzytkownika"].ToString();
                comboBoxDodRol.SelectedItem = row["DodawanieRoli"].ToString();
                comboBoxUsRol.SelectedItem = row["UsuwanieRoli"].ToString();
                comboBoxEdRol.SelectedItem = row["EdytowanieRoli"].ToString();
                comboBoxNadUp.SelectedItem = row["NadajZmienRoleStanowisko"].ToString();
                comboRejNowTow.SelectedItem = row["RejestracjaNowegoTowaru"].ToString();
                comboBoxZmHa.SelectedItem = row["ZmienHaslo"].ToString();
                comboBoxPrzStMag.SelectedItem = row["PrzegladStanuMagazynowego"].ToString();
                comboBoxPHSM.SelectedItem = row["PrzegladanieHistoriiStanuMagazynowego"].ToString();
                comboBoxPHU.SelectedItem = row["PrzegladHistoriiUzupelniania"].ToString();
                comboBoxZSV.SelectedItem = row["zmianaVAT"].ToString();
            }
            else
            {
                MessageBox.Show("Nie udało się załadować danych roli.");
            }
        }

        private void buttonZapisz_Click(object sender, EventArgs e)
        {
            if (textBoxNazwa.Text.Length > 20)
            {
                MessageBox.Show("Zbyt długa nazwa roli.");
                return;
            }

            string nazwaRoli = textBoxNazwa.Text;

            if (nazwaRoli != _currentName && _roleService.CzyNazwaRoliIstnieje(nazwaRoli))
            {
                MessageBox.Show("Nazwa stanowiska już istnieje w bazie danych.");
                return;
            }

            string dostepDoListyUzytkownikow = comboBoxListUz.SelectedItem?.ToString();
            string dostepDoListyUprawnien = comboBoxListUp.SelectedItem?.ToString();
            string dodawanieUzytkownika = comboBoxDodUz.SelectedItem?.ToString();
            string usuwanieUzytkownika = comboBoxUsuUz.SelectedItem?.ToString();
            string edytowanieUzytkownika = comboBoxEdUz.SelectedItem?.ToString();
            string dodawanieRoli = comboBoxDodRol.SelectedItem?.ToString();
            string usuwanieRoli = comboBoxUsRol.SelectedItem?.ToString();
            string edytowanieRoli = comboBoxEdRol.SelectedItem?.ToString();
            string nadawanieRoli = comboBoxNadUp.SelectedItem?.ToString();
            string rejesrowanieTowaru = comboRejNowTow.SelectedItem?.ToString();
            string zmianaHasla = comboBoxZmHa.SelectedItem?.ToString();
            string przegladStanuMagazynowego = comboBoxPrzStMag.SelectedItem?.ToString();
            string przegladanieHistoriiStanuMagazynowego = comboBoxPHSM.SelectedItem?.ToString();
            string przegladHistoriiUzupelniania = comboBoxPHU.SelectedItem?.ToString();
            string zmianaVAT = comboBoxZSV.SelectedItem?.ToString();

            try
            {
                bool updated = _roleService.AktualizujRole(_roleId, nazwaRoli, dostepDoListyUzytkownikow, dostepDoListyUprawnien,
                                                          dodawanieUzytkownika, usuwanieUzytkownika, edytowanieUzytkownika,
                                                          dodawanieRoli, usuwanieRoli, edytowanieRoli, nadawanieRoli,
                                                          rejesrowanieTowaru, zmianaHasla, przegladStanuMagazynowego,
                                                          przegladanieHistoriiStanuMagazynowego, przegladHistoriiUzupelniania,
                                                          zmianaVAT);

                if (updated)
                {
                    MessageBox.Show("Dane roli zostały zaktualizowane.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nie udało się zaktualizować danych roli.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas aktualizacji danych roli: " + ex.Message);
            }
        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
