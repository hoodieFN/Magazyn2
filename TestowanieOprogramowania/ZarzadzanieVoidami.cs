using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestowanieOprogramowania
{
    internal class ZarzadzanieVoidami
    {

        static string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();



        public List<Uzytkownik> PobierzUzytkownikow()
        {
            List<Uzytkownik> listaUzytkownikow = new List<Uzytkownik>();

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                string query = @"SELECT 
                                u.UzytkownikID, u.Login, u.Imie, u.Nazwisko, u.Miejscowosc, 
                                u.KodPocztowy, u.Ulica, u.NumerPosesji, u.NumerLokalu, u.PESEL, 
                                u.DataUrodzenia, u.Plec, u.Email, u.NumerTelefonu, 
                                ISNULL(up.Nazwa_stanowiska, 'Brak roli') AS Nazwa_stanowiska 
                                FROM dbo.Uzytkownicy u 
                                LEFT JOIN dbo.Uprawnienia up ON u.IDUprawnienia = up.UprawnienieID 
                                WHERE u.archiwizacja = '1'";


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Uzytkownik uzytkownik = new Uzytkownik
                            {
                                UzytkownikID = Convert.ToInt32(reader["UzytkownikID"]),
                                Login = reader["Login"].ToString(),
                                Imie = reader["Imie"].ToString(),
                                Nazwisko = reader["Nazwisko"].ToString(),
                                Miejscowosc = reader["Miejscowosc"].ToString(),
                                KodPocztowy = reader["KodPocztowy"].ToString(),
                                Ulica = reader["Ulica"].ToString(),
                                NumerPosesji = reader["NumerPosesji"].ToString(),
                                NumerLokalu = reader["NumerLokalu"].ToString(),
                                PESEL = reader["PESEL"].ToString(),
                                DataUrodzenia = reader["DataUrodzenia"].ToString(),
                                Plec = reader["Plec"].ToString(),
                                Email = reader["Email"].ToString(),
                                NumerTelefonu = reader["NumerTelefonu"].ToString(),
                                Nazwa_stanowiska = reader["Nazwa_stanowiska"].ToString()

                            };
                            listaUzytkownikow.Add(uzytkownik);
                        }
                    }
                }
            }

            return listaUzytkownikow;
        }



        public void UsunUzytkownikaZBazy(int userId)
        {
            //UsunPowiazaneUprawnienia(userId);
            string query = "UPDATE dbo.Uzytkownicy SET archiwizacja = 0 WHERE UzytkownikID = @userId";

            using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // SQL Injection
                    cmd.Parameters.AddWithValue("@userId", userId);

                    connection.Open();
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Użytkownik został zarchiwizowany.");
                    }
                    else
                    {
                        MessageBox.Show("Nie znaleziono użytkownika o podanym ID.");
                    }
                    connection.Close();
                }
            }
        }


        public void UsunPowiazaneUprawnienia(int userId)
        {
            string query = "DELETE FROM dbo.Uprawnienia WHERE UzytkownikID = @userId";

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int)).Value = userId;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        //s
        public List<Uzytkownik> WyszukajUzytkownikow(string szukanyTekst, string kategoria)
        {
            string query = $@"
            SELECT 
                u.UzytkownikID, u.Login, u.Imie, u.Nazwisko, u.Miejscowosc, 
                u.KodPocztowy, u.Ulica, u.NumerPosesji, u.NumerLokalu, u.PESEL, 
                u.DataUrodzenia, u.Plec, u.Email, u.NumerTelefonu, 
                ISNULL(up.Nazwa_stanowiska, 'Brak roli') AS Nazwa_stanowiska 
            FROM dbo.Uzytkownicy u 
            LEFT JOIN dbo.Uprawnienia up ON u.IDUprawnienia = up.UprawnienieID 
            WHERE {kategoria} LIKE @szukanyTekst AND u.archiwizacja = '1'";


            List<Uzytkownik> listaUzytkownikow = new List<Uzytkownik>();

            using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@szukanyTekst", SqlDbType.NVarChar)).Value = "%" + szukanyTekst + "%";

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Uzytkownik uzytkownik = new Uzytkownik
                            {
                                UzytkownikID = Convert.ToInt32(reader["UzytkownikID"]),
                                Login = reader["Login"].ToString(),
                                Imie = reader["Imie"].ToString(),
                                Nazwisko = reader["Nazwisko"].ToString(),
                                Miejscowosc = reader["Miejscowosc"].ToString(),
                                KodPocztowy = reader["KodPocztowy"].ToString(),
                                Ulica = reader["Ulica"].ToString(),
                                NumerPosesji = reader["NumerPosesji"].ToString(),
                                NumerLokalu = reader["NumerLokalu"].ToString(),
                                PESEL = reader["PESEL"].ToString(),
                                DataUrodzenia = reader["DataUrodzenia"].ToString(),
                                Plec = reader["Plec"].ToString(),
                                Email = reader["Email"].ToString(),
                                NumerTelefonu = reader["NumerTelefonu"].ToString(),
                                //archiwizacja = reader["archiwizacja"].ToString(),
                                Nazwa_stanowiska = reader["Nazwa_stanowiska"].ToString()
                            };
                            listaUzytkownikow.Add(uzytkownik);
                        }
                    }
                }
            }
            return listaUzytkownikow;
        }


        public List<Uprawnienia> PobierzUprawnienia()
        {
            List<Uprawnienia> listaUprawnien = new List<Uprawnienia>();

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                string query = "SELECT * from dbo.Uprawnienia WHERE UprawnienieID <> 0";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Uprawnienia uprawnienia = new Uprawnienia
                            {
                                UprawnienieID = Convert.ToInt32(reader["UprawnienieID"]),
                                Nazwa_stanowiska = reader["Nazwa_Stanowiska"].ToString(),
                                DostepDoListyUzytkownikow = reader["DostepDoListyUzytkownikow"].ToString(),
                                DostepDoListyUprawnien = reader["DostepDoListyUprawnien"].ToString(),
                                DodawanieUzytkownika = reader["DodawanieUzytkownika"].ToString(),
                                UsuwanieUzytkownika = reader["UsuwanieUzytkownika"].ToString(),
                                EdytowanieUzytkownika = reader["EdytowanieUzytkownika"].ToString(),
                                DodawanieRoli  = reader["DodawanieRoli"].ToString(),
                                UsuwanieRoli = reader["UsuwanieRoli"].ToString(),
                                EdytowanieRoli = reader["EdytowanieRoli"].ToString()
                            };
                            listaUprawnien.Add(uprawnienia);
                        }
                    }
                }
            }

            return listaUprawnien;
        }

        public static int CurrentUserId = UserSession.CurrentUserId;

        public static bool CzyMaDostepDoListyUzytkownikow()
        {
            if (CurrentUserId == -1)
            {
                return false; // Brak zalogowanego użytkownika
            }

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                string query = @"
                SELECT DostepDoListyUzytkownikow 
                FROM Uprawnienia 
                JOIN Uzytkownicy ON Uprawnienia.UprawnienieID = Uzytkownicy.IDUprawnienia 
                WHERE Uzytkownicy.UzytkownikID = @CurrentUserId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CurrentUserId", CurrentUserId);

                    // Zakładamy, że wartość w kolumnie to 'Tak' lub 'Nie'
                    string dostep = cmd.ExecuteScalar()?.ToString() ?? "Nie";
                    return dostep.Equals("Tak", StringComparison.OrdinalIgnoreCase);
                }
            }
        }
        public static bool CzyMaDostepDoListyUprawnien()
        {
            if (CurrentUserId == -1)
            {
                return false; // Brak zalogowanego użytkownika
            }

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                string query = @"
                SELECT DostepDoListyUprawnien
                FROM Uprawnienia 
                JOIN Uzytkownicy ON Uprawnienia.UprawnienieID = Uzytkownicy.IDUprawnienia 
                WHERE Uzytkownicy.UzytkownikID = @CurrentUserId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CurrentUserId", CurrentUserId);

                    // Zakładamy, że wartość w kolumnie to 'Tak' lub 'Nie'
                    string dostep = cmd.ExecuteScalar()?.ToString() ?? "Nie";
                    return dostep.Equals("Tak", StringComparison.OrdinalIgnoreCase);
                }
            }
        }
        public static bool DodawanieUzytkownika()
        {
            if (CurrentUserId == -1)
            {
                return false; // Brak zalogowanego użytkownika
            }

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                string query = @"
                SELECT DodawanieUzytkownika
                FROM Uprawnienia 
                JOIN Uzytkownicy ON Uprawnienia.UprawnienieID = Uzytkownicy.IDUprawnienia 
                WHERE Uzytkownicy.UzytkownikID = @CurrentUserId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CurrentUserId", CurrentUserId);

                    // Zakładamy, że wartość w kolumnie to 'Tak' lub 'Nie'
                    string dostep = cmd.ExecuteScalar()?.ToString() ?? "Nie";
                    return dostep.Equals("Tak", StringComparison.OrdinalIgnoreCase);
                }
            }
        }
        public static bool UsuwanieUzytkownika()
        {
            if (CurrentUserId == -1)
            {
                return false; // Brak zalogowanego użytkownika
            }

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                string query = @"
                SELECT UsuwanieUzytkownika
                FROM Uprawnienia 
                JOIN Uzytkownicy ON Uprawnienia.UprawnienieID = Uzytkownicy.IDUprawnienia 
                WHERE Uzytkownicy.UzytkownikID = @CurrentUserId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CurrentUserId", CurrentUserId);

                    // Zakładamy, że wartość w kolumnie to 'Tak' lub 'Nie'
                    string dostep = cmd.ExecuteScalar()?.ToString() ?? "Nie";
                    return dostep.Equals("Tak", StringComparison.OrdinalIgnoreCase);
                }
            }
        }
        public static bool EdytowanieUzytkownika()
        {
            if (CurrentUserId == -1)
            {
                return false; // Brak zalogowanego użytkownika
            }

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                string query = @"
                SELECT EdytowanieUzytkownika
                FROM Uprawnienia 
                JOIN Uzytkownicy ON Uprawnienia.UprawnienieID = Uzytkownicy.IDUprawnienia 
                WHERE Uzytkownicy.UzytkownikID = @CurrentUserId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CurrentUserId", CurrentUserId);

                    // Zakładamy, że wartość w kolumnie to 'Tak' lub 'Nie'
                    string dostep = cmd.ExecuteScalar()?.ToString() ?? "Nie";
                    return dostep.Equals("Tak", StringComparison.OrdinalIgnoreCase);
                }
            }
        }
        public static bool DodawanieRoli()
        {
            if (CurrentUserId == -1)
            {
                return false; // Brak zalogowanego użytkownika
            }

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                string query = @"
                SELECT DodawanieRoli
                FROM Uprawnienia 
                JOIN Uzytkownicy ON Uprawnienia.UprawnienieID = Uzytkownicy.IDUprawnienia 
                WHERE Uzytkownicy.UzytkownikID = @CurrentUserId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CurrentUserId", CurrentUserId);

                    // Zakładamy, że wartość w kolumnie to 'Tak' lub 'Nie'
                    string dostep = cmd.ExecuteScalar()?.ToString() ?? "Nie";
                    return dostep.Equals("Tak", StringComparison.OrdinalIgnoreCase);
                }
            }
        }
        public static bool UsuwanieRoli()
        {
            if (CurrentUserId == -1)
            {
                return false; // Brak zalogowanego użytkownika
            }

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                string query = @"
                SELECT UsuwanieRoli
                FROM Uprawnienia 
                JOIN Uzytkownicy ON Uprawnienia.UprawnienieID = Uzytkownicy.IDUprawnienia 
                WHERE Uzytkownicy.UzytkownikID = @CurrentUserId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CurrentUserId", CurrentUserId);

                    // Zakładamy, że wartość w kolumnie to 'Tak' lub 'Nie'
                    string dostep = cmd.ExecuteScalar()?.ToString() ?? "Nie";
                    return dostep.Equals("Tak", StringComparison.OrdinalIgnoreCase);
                }
            }
        }
        public static bool EdytowanieRoli()
        {
            if (CurrentUserId == -1)
            {
                return false; // Brak zalogowanego użytkownika
            }

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                string query = @"
                SELECT EdytowanieRoli
                FROM Uprawnienia 
                JOIN Uzytkownicy ON Uprawnienia.UprawnienieID = Uzytkownicy.IDUprawnienia 
                WHERE Uzytkownicy.UzytkownikID = @CurrentUserId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CurrentUserId", CurrentUserId);

                    // Zakładamy, że wartość w kolumnie to 'Tak' lub 'Nie'
                    string dostep = cmd.ExecuteScalar()?.ToString() ?? "Nie";
                    return dostep.Equals("Tak", StringComparison.OrdinalIgnoreCase);
                }
            }
        }

    }

}

        

    


