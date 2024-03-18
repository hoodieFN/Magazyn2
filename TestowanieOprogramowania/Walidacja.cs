using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestowanieOprogramowania
{
    public class Walidacja
    {
        string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();





        //Dla WalidujPlec z FormDodajUzytkownika.cs
        public bool WalidujPlec(string plec)
        {
            if (plec != "K" && plec != "M")
            {
                //MessageBox.Show("Płeć musi być określona jako 'K' dla kobiety lub 'M' dla mężczyzny.");
                return false;
            }

            return true;
        }

        //Dla WalidujDate z FormDodajUzytkownika.cs
        public bool WalidujDate(string dataUrodzenia)
        {
            if (!DateTime.TryParse(dataUrodzenia, out DateTime parsedDate))
            {
                //MessageBox.Show("Podana data urodzenia jest nieprawidłowa. Użyj formatu RRRR-MM-DD.");
                return false;
            }

            if (parsedDate > DateTime.Now)
            {
                //MessageBox.Show("Data urodzenia nie może być w przyszłości.");
                return false;
            }

            return true;
        }

        //Dla WalidujNumerTelefonu z FormDodajUzytkownika.cs
        public bool WalidujNumerTelefonu(string numerTelefonu)
        {
            if (numerTelefonu.Length != 9 || !long.TryParse(numerTelefonu, out _))
            {
                //MessageBox.Show("Numer telefonu musi składać się z dokładnie 9 cyfr.");
                return false;
            }

            return true;
        }

        //Dla WalidujNumerEmail z FormDodajUzytkownika.cs
        public bool WalidujEmail(string email)
        {
            if (email.Split('@').Length - 1 != 1)
            {
                //MessageBox.Show("Adres e-mail musi zawierać dokładnie jeden znak '@'.");
                return false;
            }

            if (email.Length > 255)
            {
                //MessageBox.Show("Adres e-mail może zawierać maksymalnie 255 znaków.");
                return false;
            }

            //Dodac czy email juz istnieje w bazie

            return true;
        }

        //
        public bool WalidujPesel(string pesel)
        {
            if (pesel.Length != 11 || !pesel.All(char.IsDigit))
            {
                //MessageBox.Show("PESEL musi składać się z 11 cyfr.");
                return false;
            }

            int rok = Convert.ToInt32(pesel.Substring(0, 2));
            int miesiac = Convert.ToInt32(pesel.Substring(2, 2));
            int dzien = Convert.ToInt32(pesel.Substring(4, 2));

            miesiac %= 20;

            if (miesiac < 1 || miesiac > 12 || dzien < 1 || dzien > 31)
            {
                //MessageBox.Show("Data urodzenia w PESEL jest nieprawidłowa.");
                return false;
            }

            //Niezaimplementowane

            //ii.	Przedostatnia cyfra odpowiada płci: 
            // 1.Nieparzyste – kobieta
            //2.Parzyste i zero – mężczyźni

            /*
            int plecNumer = Convert.ToInt32(pesel[9].ToString());
            if ((plec == "K" && plecNumer % 2 == 0) || (plec == "M" && plecNumer % 2 != 0))
            {
                MessageBox.Show("Nieprawidłowy numer PESEL dla podanej płci.");
                return false;
            }
            */

            int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int sumaKontrolna = 0;

            for (int i = 0; i < wagi.Length; i++)
            {
                sumaKontrolna += wagi[i] * Convert.ToInt32(pesel[i].ToString());
            }

            int cyfraKontrolna = (10 - sumaKontrolna % 10) % 10;
            if (cyfraKontrolna != Convert.ToInt32(pesel[10].ToString()))
            {
                //MessageBox.Show("Nieprawidłowa cyfra kontrolna PESEL.");
                return false;
            }


            return true;
        }





















        //Dla WyszukajUzytkownikow z ZarzadzanieVoidami

        public List<Uzytkownik> WyszukajUzytkownikow(string szukanyTekst)
        {
            string query = "SELECT * FROM dbo.Uzytkownicy WHERE Login LIKE @szukanyTekst OR Imie LIKE @szukanyTekst OR Nazwisko LIKE @szukanyTekst OR Email LIKE @szukanyTekst OR NumerTelefonu LIKE @szukanyTekst";
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
                                NumerTelefonu = reader["NumerTelefonu"].ToString()
                            };
                            listaUzytkownikow.Add(uzytkownik);
                        }
                    }
                }
            }
            return listaUzytkownikow;
        }

        //Pobieranie uzytkownikow z bazy danych
        public List<Uzytkownik> PobierzUzytkownikow()
        {
            List<Uzytkownik> listaUzytkownikow = new List<Uzytkownik>();

            using (SqlConnection conn = new SqlConnection(StringPolaczeniowy))
            {
                string query = "SELECT * FROM dbo.Uzytkownicy";

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
                                NumerTelefonu = reader["NumerTelefonu"].ToString()
                            };
                            listaUzytkownikow.Add(uzytkownik);
                        }
                    }
                }
            }

            return listaUzytkownikow;
        }
    }
}
