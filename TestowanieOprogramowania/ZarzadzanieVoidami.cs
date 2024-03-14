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

        string StringPolaczeniowy = PolaczenieBazyDanych.StringPolaczeniowy();



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



        public void UsunUzytkownikaZBazy(int userId)
        {
            UsunPowiazaneUprawnienia(userId);
            string query = "DELETE FROM dbo.Uzytkownicy WHERE UzytkownikID = @userId";

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
                        MessageBox.Show("Użytkownik został usunięty.");
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

        


    }

}

        

    


