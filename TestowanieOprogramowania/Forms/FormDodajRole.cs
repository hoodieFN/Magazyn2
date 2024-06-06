using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;
using TestowanieOprogramowania.Services;

namespace TestowanieOprogramowania
{
    public partial class FormDodajRole : Form
    {
        private readonly RoleService _roleService;

        public FormDodajRole(RoleService roleService)
        {
            InitializeComponent();
            _roleService = roleService;
        }

        private void buttonZapisz_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxNazwa.Text))
                {
                    MessageBox.Show("Podaj nazwę roli.");
                    return;
                }
                if (textBoxNazwa.Text.Length > 20)
                {
                    MessageBox.Show("Zbyt długa nazwa roli.");
                    return;
                }

                string nazwa = textBoxNazwa.Text;
                if (_roleService.CzyRolaIstnieje(nazwa))
                {
                    MessageBox.Show("Nazwa stanowiska już istnieje w bazie danych.");
                    return;
                }

                if (comboBoxListUz.SelectedIndex == -1 || comboBoxListUp.SelectedIndex == -1 ||
                    comboBoxDodUz.SelectedIndex == -1 || comboBoxUsUz.SelectedIndex == -1 ||
                    comboBoxEdUs.SelectedIndex == -1 || comboBoxDodRol.SelectedIndex == -1 ||
                    comboBoxUsRol.SelectedIndex == -1 || comboBoxEdRol.SelectedIndex == -1 ||
                    comboRejNowTow.SelectedIndex == -1 || comboBoxZmHa.SelectedIndex == -1 ||
                    comboBoxPrzStMag.SelectedIndex == -1 || comboBoxPHSM.SelectedIndex == -1 ||
                    comboBoxPHU.SelectedIndex == -1 || comboBoxZSV.SelectedIndex == -1)
                {
                    MessageBox.Show("Proszę wypełnić wszystkie pola.");
                    return;
                }

                _roleService.DodajRole(nazwa, comboBoxListUz.SelectedItem.ToString(), comboBoxListUp.SelectedItem.ToString(),
                    comboBoxDodUz.SelectedItem.ToString(), comboBoxUsUz.SelectedItem.ToString(),
                    comboBoxEdUs.SelectedItem.ToString(), comboBoxDodRol.SelectedItem.ToString(),
                    comboBoxUsRol.SelectedItem.ToString(), comboBoxEdRol.SelectedItem.ToString(),
                    comboBoxNadUp.SelectedItem.ToString(), comboRejNowTow.SelectedItem.ToString(),
                    comboBoxZmHa.SelectedItem.ToString(), comboBoxPrzStMag.SelectedItem.ToString(),
                    comboBoxPHSM.SelectedItem.ToString(), comboBoxPHU.SelectedItem.ToString(),
                    comboBoxZSV.SelectedItem.ToString());

                MessageBox.Show("Rola została pomyślnie dodana.");

                this.DialogResult = DialogResult.OK;
                this.Close();
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

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormDodajRole_Load(object sender, EventArgs e)
        {
            // Możesz dodać kod inicjalizacyjny tutaj, jeśli potrzebujesz
        }
    }
}
