using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;
using TestowanieOprogramowania.Services;

namespace TestowanieOprogramowania
{
    public partial class FormLogin : Form
    {
        private readonly UserService _userService;
        private int loginAttempts = 0;
        private DateTime firstAttemptTime;
        private bool isLoginBlocked = false;
        private DateTime unlockTime;

        public FormLogin()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(FormLogin_FormClosed);
            string connectionString = PolaczenieBazyDanych.StringPolaczeniowy();
            _userService = new UserService(connectionString);
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isLoginBlocked)
            {
                if (DateTime.Now < unlockTime)
                {
                    var remainingTimeInSeconds = (int)Math.Round((unlockTime - DateTime.Now).TotalSeconds);
                    MessageBox.Show($"Logowanie zablokowane. Spróbuj ponownie za {remainingTimeInSeconds} sekund.");
                    return;
                }
                else
                {
                    isLoginBlocked = false;
                    loginAttempts = 0;
                }
            }

            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Wprowadź login i hasło.");
                return;
            }

            if (loginAttempts == 0 || (DateTime.Now - firstAttemptTime).TotalSeconds > 20)
            {
                firstAttemptTime = DateTime.Now;
                loginAttempts = 1;
            }
            else
            {
                loginAttempts++;
                if (loginAttempts > 5)
                {
                    isLoginBlocked = true;
                    unlockTime = DateTime.Now.AddSeconds(20);
                    MessageBox.Show("Logowanie zablokowane na 20 sekund.");
                    return;
                }
            }

            LoginResult loginResult = _userService.VerifyLogin(username, password, out int userId);

            switch (loginResult)
            {
                case LoginResult.Success:
                    loginAttempts = 0;
                    isLoginBlocked = false;

                    UserSession.StartSession(userId);
                    MessageBox.Show("Logowanie pomyślne!");

                    bool check = _userService.CheckChangePassFlagByLogin(username);
                    if (check)
                    {
                        MessageBox.Show("Wymagana jest zmiana hasła po zrestartowaniu hasła. Po kliknięciu ok zostaniesz przeniesiony do nowego okna");
                        FormZmianaPoResecie formZmianaPoResecie = new FormZmianaPoResecie();
                        formZmianaPoResecie.ShowDialog();
                        return;
                    }

                    FormInitial formInitial = new FormInitial(_userService);
                    this.Hide();
                    formInitial.ShowDialog();
                    this.Show();
                    break;
                case LoginResult.InvalidUsername:
                case LoginResult.InvalidPassword:
                    MessageBox.Show("Nieprawidłowa nazwa użytkownika lub hasło");
                    break;
                default:
                    MessageBox.Show("Nieoczekiwany błąd logowania.");
                    break;
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var formReset = new FromResetPas())
            {
                var result = formReset.ShowDialog();
            }
        }
    }
}
