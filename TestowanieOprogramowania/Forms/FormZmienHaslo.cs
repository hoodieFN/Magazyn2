using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using TestowanieOprogramowania.Services;

namespace TestowanieOprogramowania
{
    public partial class FormZmienHaslo : Form
    {
        private readonly UserService userService;

        public FormZmienHaslo()
        {
            InitializeComponent();
            string connectionString = PolaczenieBazyDanych.StringPolaczeniowy();
            userService = new UserService(connectionString);
            LoadUserLogins();
        }

        private void LoadUserLogins()
        {
            var userLogins = userService.GetAllUserLogins();
            foreach (DataRow row in userLogins.Rows)
            {
                comboBoxUsers.Items.Add(row["login"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxUsers.SelectedItem == null ||
                string.IsNullOrWhiteSpace(textBoxOldPassword.Text) ||
                string.IsNullOrWhiteSpace(textBoxNewPassword.Text) ||
                string.IsNullOrWhiteSpace(textBoxNewPassword2.Text))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola.");
                return;
            }

            string login = comboBoxUsers.SelectedItem.ToString();
            string oldPassword = textBoxOldPassword.Text;
            string newPassword = textBoxNewPassword.Text;
            string new2Password = textBoxNewPassword2.Text;

            if (!IsValidPassword(newPassword))
            {
                MessageBox.Show("Nowe hasło nie spełnia wymagań: musi mieć od 8 do 15 znaków, zawierać wielką literę, małą literę, cyfrę i jeden ze znaków specjalnych tj. -, _, !, *, #, $, &.");
                return;
            }

            if (newPassword == new2Password)
            {
                ChangePassword(login, oldPassword, newPassword);
            }
            else
            {
                MessageBox.Show("Nowe hasła nie są identyczne. Spróbuj ponownie.");
            }
        }

        private bool IsValidPassword(string password)
        {
            if (password.Length < 8 || password.Length > 15)
                return false;

            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;
            bool hasSpecial = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                if (char.IsLower(c)) hasLower = true;
                if (char.IsDigit(c)) hasDigit = true;
                if ("-_!*$&#".Contains(c)) hasSpecial = true;
            }

            return hasUpper && hasLower && hasDigit && hasSpecial;
        }
        private void FormZmienHaslo_Load(object sender, EventArgs e)
        {

        }
        public void ChangePassword(string login, string oldPassword, string newPassword)
        {
            int userId = userService.GetUserIdByLogin(login);
            if (userId == -1)
            {
                MessageBox.Show("Nie znaleziono użytkownika.");
                return;
            }

            if (userService.CheckPassword(userId, oldPassword))
            {
                if (oldPassword == newPassword)
                {
                    MessageBox.Show("Hasło musi się różnić od 3 ostatnich haseł.");
                }
                else if (userService.CheckIfPasswordIsInHistory(userId, newPassword))
                {
                    MessageBox.Show("Hasło musi się różnić od 3 ostatnich haseł.");
                }
                else
                {
                    userService.UpdatePassword(userId, newPassword);
                    MessageBox.Show("Hasło zostało zmienione.");
                    comboBoxUsers.SelectedIndex = -1;
                    textBoxNewPassword.Text = "";
                    textBoxOldPassword.Text = "";
                    textBoxNewPassword2.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Podane stare hasło jest nieprawidłowe.");
            }
        }
    }
}
