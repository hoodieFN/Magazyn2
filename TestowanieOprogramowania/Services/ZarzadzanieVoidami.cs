using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestowanieOprogramowania.Models;

namespace TestowanieOprogramowania.Services
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
                                DodawanieRoli = reader["DodawanieRoli"].ToString(),
                                UsuwanieRoli = reader["UsuwanieRoli"].ToString(),
                                EdytowanieRoli = reader["EdytowanieRoli"].ToString(),
                                NadawanieRoli = reader["NadajZmienRoleStanowisko"].ToString(),
                                ZmienHaslo = reader["ZmienHaslo"].ToString(),
                                zmianaVAT = reader["zmianaVAT"].ToString(),
                                PrzegladStanuMagazynowego = reader["PrzegladStanuMagazynowego"].ToString(),
                                PrzegladanieHistoriiStanuMagazynowego = reader["PrzegladanieHistoriiStanuMagazynowego"].ToString(),
                                PrzegladHistoriiUzupelniania = reader["PrzegladHistoriiUzupelniania"].ToString()
                            };
                            listaUprawnien.Add(uprawnienia);
                        }
                    }
                }
            }

            return listaUprawnien;
        }

        //public static int CurrentUserId = UserSession.CurrentUserId;

        public static bool CzyMaDostepDoListyUzytkownikow()
        {
            int CurrentUserId = UserSession.CurrentUserId;
            if (CurrentUserId == -1)
            {
                return false; // Brak zalogowanego użytkownika
            }

            //MessageBox.Show("Inaczej pobrane curentid: " + CurrentID);
            ///////===============Debug==================/////////////MessageBox.Show("Current id: "+ CurrentUserId);
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
                    ///////===============Debug==================///////////// MessageBox.Show($"{dostep}");
                    return dostep.Equals("Tak", StringComparison.OrdinalIgnoreCase);

                }
            }
        }
        public static bool CzyMaDostepDoListyUprawnien()
        {
            int CurrentUserId = UserSession.CurrentUserId;
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
            int CurrentUserId = UserSession.CurrentUserId;
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
            int CurrentUserId = UserSession.CurrentUserId;
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
            int CurrentUserId = UserSession.CurrentUserId;
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
            int CurrentUserId = UserSession.CurrentUserId;
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
            int CurrentUserId = UserSession.CurrentUserId;
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
            int CurrentUserId = UserSession.CurrentUserId;
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
        public static bool NadawanieZmianaRoli()
        {
            int CurrentUserId = UserSession.CurrentUserId;
            if (CurrentUserId == -1)
            {
                return false; // Brak zalogowanego użytkownika
            }

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                string query = @"
                SELECT NadajZmienRoleStanowisko
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

        public static bool zmianaVATA()
        {
            int CurrentUserId = UserSession.CurrentUserId;
            if (CurrentUserId == -1)
            {
                return false; // Brak zalogowanego użytkownika
            }

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                string query = @"
                SELECT zmianaVAT
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





        public static bool ZmianaHaslaAdmin()
        {
            int CurrentUserId = UserSession.CurrentUserId;
            if (CurrentUserId == -1)
            {
                return false; // Brak zalogowanego użytkownika
            }

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                string query = @"
                SELECT ZmienHaslo
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




        public static bool RejestracjaNowegoTowaru()
        {
            int CurrentUserId = UserSession.CurrentUserId;
            if (CurrentUserId == -1)
            {
                return false; // Brak zalogowanego użytkownika
            }

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                string query = @"
                SELECT RejestracjaNowegoTowaru
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








        //1. Pracownik magazynu oraz Kierownik magazynu mają możliwość wyszukiwania towarów po nazwie, rodzaju, oraz imieniu i
        //nazwisku osoby rejestrującej towar w magazynie
        //2. Pracownik magazynu oraz Kierownik magazynu mają dostęp do bieżących stanów magazynowych wyszukanego towaru


        //PrzegladStanuMagazynowego

        public static bool PrzegladStanuMagazynowego()
        {
            int CurrentUserId = UserSession.CurrentUserId;
            if (CurrentUserId == -1)
            {
                return false; // Brak zalogowanego użytkownika
            }

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                string query = @"
                SELECT PrzegladStanuMagazynowego
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





        //3. Kierownik magazynu ma możliwość przeglądania historycznych stanów magazynowych na wskazaną datę

        public static bool PrzegladanieHistoriiStanuMagazynowego()
        {
            int CurrentUserId = UserSession.CurrentUserId;
            if (CurrentUserId == -1)
            {
                return false; // Brak zalogowanego użytkownika
            }

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                string query = @"
                SELECT PrzegladanieHistoriiStanuMagazynowego
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


        public static bool PrzegladHistoriiUzupelniania()
        {
            int CurrentUserId = UserSession.CurrentUserId;
            if (CurrentUserId == -1)
            {
                return false; // Brak zalogowanego użytkownika
            }

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                string query = @"
                SELECT PrzegladHistoriiUzupelniania
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

        public static bool zmianaVAT()
        {
            int CurrentUserId = UserSession.CurrentUserId;
            if (CurrentUserId == -1)
            {
                return false; // Brak zalogowanego użytkownika
            }

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                conn.Open();
                string query = @"
                SELECT zmianaVAT
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


































        public List<Produkt> PobierzPodukty()
        {
            List<Produkt> listaProduktów = new List<Produkt>();

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                string query = @"SELECT 
                                ProduktID,         
                                NazwaTowaru,       
                                RodzajTowaru,     
                                JednostkaMiary,   
                                Ilosc,             
                                CenaNetto,       
                                StawkaVAT,         
                                Opis,             
                                Dostawca,          
                                DataDostawy,      
                                DataRejestracji,   
                                Rejestrujacy      
                                FROM 
                                Produkty;          
                                                                        ";


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produkt produkt = new Produkt
                            {
                                ProduktID = Convert.ToInt32(reader["ProduktID"]),
                                NazwaTowaru = reader["NazwaTowaru"].ToString(),
                                RodzajTowaru = reader["RodzajTowaru"].ToString(),
                                JednostkaMiary = reader["JednostkaMiary"].ToString(),
                                Ilosc = Convert.ToDouble(reader["Ilosc"]),
                                CenaNetto = Convert.ToDouble(reader["CenaNetto"].ToString()),
                                StawkaVAT = reader["StawkaVat"].ToString(),
                                Opis = reader["Opis"].ToString(),
                                Dostawca = reader["Dostawca"].ToString(),
                                DataDostawy = Convert.ToDateTime(reader["DataDostawy"].ToString()),
                                DataRejestracji = Convert.ToDateTime(reader["DataRejestracji"].ToString()),
                                Rejestrujacy = reader["Rejestrujacy"].ToString()


                            };
                            listaProduktów.Add(produkt);
                        }
                    }
                }
            }

            return listaProduktów;
        }
        public List<Produkt> WyszukajProdukt(string szukanyTekst, string kategoria)
        {
            string query = $@"
                                 SELECT 
                                ProduktID,         
                                NazwaTowaru,       
                                RodzajTowaru,     
                                JednostkaMiary,   
                                Ilosc,             
                                CenaNetto,       
                                StawkaVAT,         
                                Opis,             
                                Dostawca,          
                                DataDostawy,      
                                DataRejestracji,   
                                Rejestrujacy      
                                FROM 
                                 Produkty
                                WHERE {kategoria} LIKE @szukanyTekst";


            List<Produkt> listaProduktów = new List<Produkt>();

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
                            Produkt produkt = new Produkt
                            {
                                ProduktID = Convert.ToInt32(reader["ProduktID"]),
                                NazwaTowaru = reader["NazwaTowaru"].ToString(),
                                RodzajTowaru = reader["RodzajTowaru"].ToString(),
                                JednostkaMiary = reader["JednostkaMiary"].ToString(),
                                Ilosc = Convert.ToDouble(reader["Ilosc"]),
                                CenaNetto = Convert.ToDouble(reader["CenaNetto"].ToString()),
                                StawkaVAT = reader["StawkaVAT"].ToString(),
                                Opis = reader["Opis"].ToString(),
                                Dostawca = reader["Dostawca"].ToString(),
                                DataDostawy = Convert.ToDateTime(reader["DataDostawy"].ToString()),
                                DataRejestracji = Convert.ToDateTime(reader["DataRejestracji"].ToString()),
                                Rejestrujacy = reader["Rejestrujacy"].ToString()


                            };
                            listaProduktów.Add(produkt);
                        }
                    }

                }
            }
            return listaProduktów;
        }
        public void UsunProduktZBazy(int produktId)
        {
            //UsunPowiazaneUprawnienia(userId);
            string query = "Delete From dbo.Produkty WHERE ProduktID = @produktId";

            using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // SQL Injection
                    cmd.Parameters.AddWithValue("@produktId", produktId);

                    connection.Open();
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Produkt został usunięty.");
                    }
                    else
                    {
                        MessageBox.Show("Nie znaleziono użytkownika o podanym ID.");
                    }
                    connection.Close();
                }
            }
        }
        public void EdytowanieStawkiVat(string nowaStawka, string selectedItem)
        {
            string query = "UPDATE Produkty SET StawkaVat = @NewVatRate WHERE NazwaTowaru = @ProductName";

            using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewVatRate", nowaStawka);
                    command.Parameters.AddWithValue("@ProductName", selectedItem);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Stawka VAT została zaktualizowana.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Nie znaleziono produktu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Wystąpił błąd podczas aktualizacji: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }



        }
        public void EdytowanieStawkiVatKategoria(decimal nowaStawka, string Kategoria)
        {
            string query = "UPDATE Produkty SET StawkaVat = @NewVatRate WHERE RodzajTowaru = @Category";

            using (SqlConnection connection = new SqlConnection(StringPolaczeniowy))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewVatRate", nowaStawka);
                    command.Parameters.AddWithValue("@Category", Kategoria);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Stawka VAT została zaktualizowana.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Nie znaleziono produktu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Wystąpił błąd podczas aktualizacji: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }




        }
    }
}








