using System;
using System.Windows.Forms;
using TestowanieOprogramowania.Services;

namespace TestowanieOprogramowania
{
    public partial class FormInitial : Form
    {
        private readonly UserService _userService;

        public FormInitial(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
            labelWitajUzytkowniku.Text = $"Witaj, {_userService.GetUserName(UserSession.CurrentUserId)}";
            labelRola.Text = $"Rola: {_userService.GetUserRole(UserSession.CurrentUserId)}";
            this.FormClosing += new FormClosingEventHandler(FormInitial_FormClosing);
        }

        private void FormInitial_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserSession.EndSession();
            FormLogin loginForm = new FormLogin();
            loginForm.Show();
            this.Hide();
            MessageBox.Show("Nastąpiło wylogowanie");
        }

        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }

        private void buttonZarzadzaj_Click(object sender, EventArgs e)
        {
            if (ZarzadzanieVoidami.CzyMaDostepDoListyUzytkownikow())
            {
                loadform(new FormZarzadzajUzytkownikami());
            }
            else
            {
                MessageBox.Show("Brak uprawnień w systemie");
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            var confirmationResult = MessageBox.Show("Czy na pewno chcesz się wylogować?", "Potwierdzenie wylogowania", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmationResult == DialogResult.Yes)
            {
                UserSession.EndSession();
                this.Hide();
                FormLogin loginForm = new FormLogin();
                loginForm.FormClosed += (s, args) => this.Close();
                loginForm.Show();
            }
        }

        private void buttonListaUprawnien_Click(object sender, EventArgs e)
        {
            loadform(new FormUprawnienia());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadform(new FormPrzegldajUzytkow());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!ZarzadzanieVoidami.ZmianaHaslaAdmin())
            {
                MessageBox.Show("Brak uprawnień do zmiany hasła - musisz być administratorem");
            }
            else
            {
                loadform(new FormZmienHaslo());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ZarzadzanieVoidami.PrzegladStanuMagazynowego())
            {
                loadform(new StanMagazynu());
            }
            else
            {
                MessageBox.Show("Nie masz uprawnien do tej sekcji.");
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadform(new FormSprzedaze());
        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
