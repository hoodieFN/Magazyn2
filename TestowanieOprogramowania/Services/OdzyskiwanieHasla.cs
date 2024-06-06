using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.ActiveDirectory;

namespace TestowanieOprogramowania.Services
{
    internal class OdzyskiwanieHasla
    {
        static string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();

        public void ResetPassword(string username, string userEmailToCheck, Func<string, bool> confirmAction)
        {
            try
            {
                string userEmail = GetUserEmail(username);
                if (string.IsNullOrEmpty(userEmail))
                {
                    MessageBox.Show($"Niepoprawny login lub mail");
                    return;
                }
                // Sprawdzenie, czy podany adres email pasuje do adresu email przypisanego do użytkownika
                if (!string.Equals(userEmail, userEmailToCheck, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Niepoprawny login lub mail");
                    return;
                }

                bool isConfirmed = confirmAction?.Invoke($"Czy na pewno chcesz zresetować hasło dla użytkownika {username}?") ?? false;
                if (!isConfirmed)
                {
                    MessageBox.Show("Resetowanie hasła zostało anulowane.");
                    return;
                }

                string newPassword = GenerateRandomPassword();
                SendEmail(userEmail, newPassword);
                UpdatePassword(userEmail, newPassword);
                SetChangePassFlag(userEmail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas resetowania hasła: " + ex.Message, "Błąd");
            }
        }

        private string GenerateRandomPassword()
        {
            const string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowerCase = "abcdefghijklmnopqrstuvwxyz";
            const string digits = "1234567890";
            const string specialChars = "-+*/%$&";

            StringBuilder res = new StringBuilder();
            Random random = new Random();

            // Dodajemy odpowiednią liczbę znaków każdego typu
            res.Append(ChooseRandomChars(upperCase, 3, random));
            res.Append(ChooseRandomChars(lowerCase, 3, random));
            res.Append(ChooseRandomChars(digits, 2, random));
            res.Append(ChooseRandomChars(specialChars, 2, random));

            // Mieszamy znaki
            return ShuffleString(res.ToString(), random);
        }

        private string ChooseRandomChars(string validChars, int count, Random random)
        {
            return new string(Enumerable.Repeat(validChars, count)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string ShuffleString(string input, Random random)
        {
            var array = input.ToCharArray();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            return new string(array);
        }


        private void SendEmail(string toEmail, string newPassword)
        {
            try
            {

                var fromMail = new MailAddress("bigcypriano335@outlook.com", "Lagerlokal Team");
                var toMail = new MailAddress(toEmail);

                string subject = "Resetowanie Hasła";
                string body = $"Twoje nowe hasło to: {newPassword}";

                string email = "bigcypriano335@outlook.com";
                string haslo = "alamakota123";
                string Host = "smtp.office365.com";
                int Port = 587;

                using (MailMessage mail = new MailMessage(fromMail.ToString(), toMail.ToString(), subject, body))
                {
                    using (SmtpClient smtp = new SmtpClient(Host, Port))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.EnableSsl = true;
                        smtp.Credentials = new NetworkCredential(email, haslo);
                        smtp.Send(mail);
                        MessageBox.Show("Hasło zostało zresetowane. \n" +
                            "Wiadomość została wysłana na adres email, w przypadku braku wiadomości sprawdź spam. \nPrzy następnej próbie logowania wymusimy na tobie zmiane hasła.", "Success");

                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas wysyłania e-maila: {ex.ToString()}");

            }
        }
        private void UpdatePassword(string userEmail, string newPassword)
        {
            using (var con = new SqlConnection(StringPolaczeniowy))
            {
                var cmd = new SqlCommand("UPDATE Uzytkownicy SET haslo = @haslo WHERE Email = @Email", con);
                cmd.Parameters.AddWithValue("@haslo", newPassword);
                cmd.Parameters.AddWithValue("@Email", userEmail);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        private void SetChangePassFlag(string userEmail)
        {
            using (var con = new SqlConnection(StringPolaczeniowy))
            {
                var cmd = new SqlCommand("UPDATE Uzytkownicy SET changePass = 1 WHERE Email = @Email", con);
                cmd.Parameters.AddWithValue("@Email", userEmail);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private string GetUserEmail(string username)
        {
            using (var con = new SqlConnection(StringPolaczeniowy))
            {
                var cmd = new SqlCommand("SELECT Email FROM Uzytkownicy WHERE Login = @Login", con);
                cmd.Parameters.AddWithValue("@Login", username);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader["Email"] as string;
                    }
                    else
                    {
                        return null;  // Zwróć null, jeśli nie znajdziesz użytkownika
                    }
                }
            }
        }
    }
}
