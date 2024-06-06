using Microsoft.Data.SqlClient;
using System.Data;
using static TestowanieOprogramowania.FormLogin;

namespace TestowanieOprogramowania.Services
{
    public class UserService
    {
        private readonly string _connectionString;

        public UserService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string PobierzImieNazwisko(int userId)
        {
            string fullName = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas pobierania imienia i nazwiska: {ex.Message}");
            }

            return fullName;
        }


        public bool CzyLoginIstnieje(string login)
        {
            string query = "SELECT COUNT(*) FROM dbo.Uzytkownicy WHERE Login = @Login";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Login", SqlDbType.NVarChar)).Value = login;

                    conn.Open();
                    int liczbaLoginow = (int)cmd.ExecuteScalar();
                    return liczbaLoginow > 0;
                }
            }
        }

        public bool CzyEmailIstnieje(string email)
        {
            string query = "SELECT COUNT(*) FROM dbo.Uzytkownicy WHERE Email = @Email";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar)).Value = email;

                    conn.Open();
                    int liczbaEmaili = (int)cmd.ExecuteScalar();
                    return liczbaEmaili > 0;
                }
            }
        }

        public bool CzyPeselIstnieje(string pesel)
        {
            string query = "SELECT COUNT(*) FROM dbo.Uzytkownicy WHERE PESEL = @PESEL";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@PESEL", SqlDbType.NVarChar)).Value = pesel;

                    conn.Open();
                    int liczbaPeseli = (int)cmd.ExecuteScalar();
                    return liczbaPeseli > 0;
                }
            }
        }

        public void DodajUzytkownika(string login, string imie, string nazwisko, string numerTelefonu, string miejscowosc,
            string kodPocztowy, string ulica, string numerPosesji, string pesel, DateTime dataUrodzenia, string plec,
            string email, string numerLokalu, string haslo, int numerUprawnienia)
        {
            string query =
                "INSERT INTO dbo.Uzytkownicy (Login, Imie, Nazwisko, NumerTelefonu, Miejscowosc, KodPocztowy, Ulica, NumerPosesji, Pesel, DataUrodzenia, Plec, Email, NumerLokalu, Haslo, IDUprawnienia) " +
                "VALUES (@Login, @Imie, @Nazwisko, @NumerTelefonu, @Miejscowosc, @KodPocztowy, @Ulica, @NumerPosesji, @PESEL, @DataUrodzenia, @Plec, @Email, @NumerLokalu, @Haslo, @IDUprawnienia)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
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
                    cmd.Parameters.Add(new SqlParameter("@Haslo", SqlDbType.NVarChar)).Value = haslo;
                    cmd.Parameters.Add(new SqlParameter("@IDUprawnienia", SqlDbType.Int)).Value = numerUprawnienia;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public DataRow PobierzDaneUzytkownika(int userId)
        {
            string query = "SELECT * FROM dbo.Uzytkownicy WHERE UzytkownikID = @userId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);

                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        public bool CzyLoginIstnieje(string login, int userId)
        {
            string query = "SELECT COUNT(*) FROM dbo.Uzytkownicy WHERE Login = @Login AND UzytkownikID <> @userId";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@userId", userId);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public bool CzyEmailIstnieje(string email, int userId)
        {
            string query = "SELECT COUNT(*) FROM dbo.Uzytkownicy WHERE Email = @Email AND UzytkownikID <> @userId";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@userId", userId);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public bool CzyPeselIstnieje(string pesel, int userId)
        {
            string query = "SELECT COUNT(*) FROM dbo.Uzytkownicy WHERE PESEL = @PESEL AND UzytkownikID <> @userId";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PESEL", pesel);
                cmd.Parameters.AddWithValue("@userId", userId);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public void AktualizujUzytkownika(int userId, string login, string imie, string nazwisko, string miejscowosc, string kodPocztowy,
                                           string ulica, string numerPosesji, string numerLokalu, string pesel, DateTime dataUrodzenia,
                                           string plec, string email, string numerTelefonu, string haslo)
        {
            string query = "UPDATE dbo.Uzytkownicy SET Login = @Login, Imie = @Imie, Nazwisko = @Nazwisko, Miejscowosc = @Miejscowosc, KodPocztowy = @KodPocztowy, Ulica = @Ulica, NumerPosesji = @NumerPosesji, NumerLokalu = @NumerLokalu, PESEL = @PESEL, DataUrodzenia = @DataUrodzenia, Plec = @Plec, Email = @Email, NumerTelefonu = @NumerTelefonu, Haslo = @Haslo WHERE UzytkownikID = @UzytkownikID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UzytkownikID", userId);
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@Imie", imie);
                cmd.Parameters.AddWithValue("@Nazwisko", nazwisko);
                cmd.Parameters.AddWithValue("@Miejscowosc", miejscowosc);
                cmd.Parameters.AddWithValue("@KodPocztowy", kodPocztowy);
                cmd.Parameters.AddWithValue("@Ulica", ulica);
                cmd.Parameters.AddWithValue("@NumerPosesji", numerPosesji);
                cmd.Parameters.AddWithValue("@NumerLokalu", numerLokalu);
                cmd.Parameters.AddWithValue("@PESEL", pesel);
                cmd.Parameters.AddWithValue("@DataUrodzenia", dataUrodzenia);
                cmd.Parameters.AddWithValue("@Plec", plec);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@NumerTelefonu", numerTelefonu);
                cmd.Parameters.AddWithValue("@Haslo", haslo);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public bool CzyHasloJestWHistorii(int userId, string haslo)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT haslo1, haslo2, haslo3 FROM HistoriaHasel WHERE UzytkownikID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", userId);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string historyPassword1 = reader["haslo1"] as string ?? "";
                                string historyPassword2 = reader["haslo2"] as string ?? "";
                                string historyPassword3 = reader["haslo3"] as string ?? "";

                                if (haslo == historyPassword1 || haslo == historyPassword2 || haslo == historyPassword3)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Błąd podczas sprawdzania historii haseł: " + ex.Message);
            }
            return false;
        }
        public string GetUserName(int userId)
        {
            string userName = string.Empty;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT Imie FROM dbo.Uzytkownicy WHERE UzytkownikID = @UzytkownikID";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@UzytkownikID", userId);
                    connection.Open();
                    userName = (string)command.ExecuteScalar();
                }
            }

            return userName;
        }

        public string GetUserRole(int userId)
        {
            string userRole = string.Empty;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT U.Nazwa_stanowiska " +
                                  "FROM Uzytkownicy AS Uzyt " +
                                  "JOIN Uprawnienia AS U ON Uzyt.IDUprawnienia = U.UprawnienieID " +
                                  "WHERE Uzyt.UzytkownikID = @UzytkownikID;";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@UzytkownikID", userId);
                    connection.Open();
                    userRole = (string)command.ExecuteScalar();
                }
            }

            return userRole;
        }

        public string GetUserLogin(int userId)
        {
            string userLogin = string.Empty;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT Login FROM dbo.Uzytkownicy WHERE UzytkownikID = @UzytkownikID";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@UzytkownikID", userId);
                    connection.Open();
                    userLogin = (string)command.ExecuteScalar();
                }
            }

            return userLogin;
        }

        public int PobierzIDUprawnienia(string login)
        {
            int idUprawnienia = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT IDUprawnienia FROM Uzytkownicy WHERE Login = @Login";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    connection.Open();
                    idUprawnienia = (int?)command.ExecuteScalar() ?? 0;
                }
            }

            return idUprawnienia;
        }
        public bool CheckChangePassFlagByLogin(string userLogin)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT changePass FROM Uzytkownicy WHERE Login = @Login", con);
                cmd.Parameters.AddWithValue("@Login", userLogin);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read() && reader["changePass"] != DBNull.Value)
                    {
                        int changePassValue = Convert.ToInt32(reader["changePass"]);
                        return changePassValue == 1;
                    }
                }
            }
            return false;
        }

        public LoginResult VerifyLogin(string username, string password, out int userId)
        {
            userId = -1;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT UzytkownikID, haslo FROM dbo.Uzytkownicy WHERE Login = @username", connection);
                command.Parameters.AddWithValue("@username", username);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedPassword = reader["haslo"].ToString();
                        userId = reader.GetInt32(0);

                        if (storedPassword == password)
                        {
                            return LoginResult.Success;
                        }
                        else
                        {
                            return LoginResult.InvalidPassword;
                        }
                    }
                }
            }
            return LoginResult.InvalidUsername;
        }
        public DataTable GetAllUserLogins()
        {
            DataTable userLogins = new DataTable();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT login FROM Uzytkownicy WHERE archiwizacja = 1", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        userLogins.Load(reader);
                    }
                }
            }
            return userLogins;
        }

        public int GetUserIdByLogin(string login)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT UzytkownikID FROM Uzytkownicy WHERE login = @login", connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    return -1;
                }
            }
        }

        public bool CheckPassword(int userId, string oldPassword)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT haslo FROM Uzytkownicy WHERE UzytkownikID = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", userId);

                    var storedPassword = command.ExecuteScalar() as string;
                    return storedPassword == oldPassword;
                }
            }
        }

        public void UpdatePassword(int userId, string newPassword)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("UPDATE Uzytkownicy SET haslo = @newPassword WHERE UzytkownikID = @id", connection))
                {
                    command.Parameters.AddWithValue("@newPassword", newPassword);
                    command.Parameters.AddWithValue("@id", userId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool CheckIfPasswordIsInHistory(int userId, string newPassword)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT haslo1, haslo2, haslo3 FROM HistoriaHasel WHERE UzytkownikID = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string historyPassword1 = reader["haslo1"] as string;
                            string historyPassword2 = reader["haslo2"] as string;
                            string historyPassword3 = reader["haslo3"] as string;

                            return (newPassword == historyPassword1 || newPassword == historyPassword2 || newPassword == historyPassword3);
                        }
                    }
                }
            }
            return false;
        }

    }
    public enum LoginResult
    {
        Success,
        InvalidUsername,
        InvalidPassword,
        InvalidUsernameAndPassword,
        UnknownError
    }
}
