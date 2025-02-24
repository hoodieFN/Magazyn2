using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.VisualBasic.ApplicationServices;
using TestowanieOprogramowania.Services;

namespace TestowanieOprogramowania
{
    public partial class FormZarzadzajUzytkownikami : Form
    {
        string StringPolaczeniowy1 = PolaczenieBazyDanych.StringPolaczeniowy();


        private ZarzadzanieVoidami zarzadzanieVoidami;

        public FormZarzadzajUzytkownikami()
        {
            InitializeComponent();

            zarzadzanieVoidami = new ZarzadzanieVoidami();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            OdswiezDataGridView();
            comboBox1.SelectedIndex = 0;
            if (!ZarzadzanieVoidami.NadawanieZmianaRoli())
            {
                buttonNadajRole.Visible = false;
            }
            if (!ZarzadzanieVoidami.DodawanieUzytkownika())
            {
                buttonDodajUzytkownika.Visible = false;
            }
            if (!ZarzadzanieVoidami.UsuwanieUzytkownika())
            {
                buttonUsunUzytkownika.Visible = false;
            }
            if (!ZarzadzanieVoidami.EdytowanieUzytkownika())
            {
                buttonEdytujUzytkownika.Visible = false;
            }

        }

        private void OdswiezDataGridView()
        {
            var listaUzytkownikow = zarzadzanieVoidami.PobierzUzytkownikow();
            dataGridView1.DataSource = listaUzytkownikow;
            dataGridView1.Columns["haslo"].Visible = false;
            dataGridView1.Columns["archiwizacja"].Visible = false;
            dataGridView1.Columns["Nazwa_stanowiska"].HeaderText = "Nazwa Roli";
        }

        private void buttonUsunUzytkownika_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Czy na pewno chcesz usun�� zaznaczonego u�ytkownika?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int userId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UzytkownikID"].Value);

                    zarzadzanieVoidami.UsunUzytkownikaZBazy(userId);

                    OdswiezDataGridView();
                }
            }
            else
            {
                MessageBox.Show("Prosz� zaznaczy� wiersz do usuni�cia", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void buttonSzukaj_Click(object sender, EventArgs e)
        {

            List<Uzytkownik> listaUzytkownikow = zarzadzanieVoidami.WyszukajUzytkownikow(textBoxSzukaj.Text, comboBox1.SelectedItem.ToString());
            dataGridView1.DataSource = listaUzytkownikow;
        }




        private void buttonDodajUzytkownika_Click_1(object sender, EventArgs e)
        {
            UserService userService = new UserService(StringPolaczeniowy1);
            using (var formDodaj = new FormDodajUzytkownika(userService))
            {
                var result = formDodaj.ShowDialog();
                if (result == DialogResult.OK)
                {
                    OdswiezDataGridView();
                }
            }
        }



        private void buttonEdytujUzytkownika_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UzytkownikID"].Value);
                UserService userService = new UserService(StringPolaczeniowy1);
                using (var formEdytuj = new FormEdytujUzytkownika(userId, userService))
                {
                    var result = formEdytuj.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        OdswiezDataGridView(); // Zak�adaj�c, �e ta metoda istnieje w formularzu
                    }
                }
            }
            else
            {
                MessageBox.Show("Prosz� zaznaczy� wiersz do edycji", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void buttonNadajRole_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UzytkownikID"].Value);
                if (userId == UserSession.CurrentUserId)
                {
                    MessageBox.Show("Nie mo�esz zmienia� sobie roli/stanowiska");
                    return;
                }
                using (var formRola = new FormNadajRole(userId))
                {
                    var result = formRola.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        OdswiezDataGridView(); // Zak�adaj�c, �e ta metoda istnieje w formularzu
                    }
                }
            }
            else
            {
                MessageBox.Show("Prosz� zaznaczy� wiersz do edycji", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            OdswiezDataGridView();
        }


    }

}