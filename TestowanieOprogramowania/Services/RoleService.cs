using Microsoft.Data.SqlClient;
using System.Data;

namespace TestowanieOprogramowania.Services
{
    public class RoleService
    {
        private readonly string _connectionString;

        public RoleService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool CzyRolaIstnieje(string nazwa)
        {
            string query = "SELECT COUNT(*) FROM dbo.Uprawnienia WHERE Nazwa_stanowiska = @Nazwa";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Nazwa", SqlDbType.NVarChar)).Value = nazwa;

                    conn.Open();
                    int liczbaNazw = (int)cmd.ExecuteScalar();
                    return liczbaNazw > 0;
                }
            }
        }

        public void DodajRole(string nazwa, string dostepDoListyUzytkownikow, string dostepDoListyUprawnien,
            string dodawanieUzytkownika, string usuwanieUzytkownika, string edytowanieUzytkownika, string dodawanieRoli,
            string usuwanieRoli, string edytowanieRoli, string nadajZmienRoleStanowisko, string rejestracjaNowegoTowaru,
            string zmienHaslo, string przegladStanuMagazynowego, string przegladanieHistoriiStanuMagazynowego,
            string przegladHistoriiUzupelniania, string zmianaVAT)
        {
            string query = "INSERT INTO dbo.Uprawnienia (Nazwa_stanowiska, DostepDoListyUzytkownikow, DostepDoListyUprawnien, DodawanieUzytkownika, UsuwanieUzytkownika, EdytowanieUzytkownika, DodawanieRoli, UsuwanieRoli, EdytowanieRoli, NadajZmienRoleStanowisko, RejestracjaNowegoTowaru, ZmienHaslo, PrzegladStanuMagazynowego, PrzegladanieHistoriiStanuMagazynowego, PrzegladHistoriiUzupelniania, zmianaVAT) " +
                           "VALUES (@Nazwa, @DostepDoListyUzytkownikow, @DostepDoListyUprawnien, @DodawanieUzytkownika, @UsuwanieUzytkownika, @EdytowanieUzytkownika, @DodawanieRoli, @UsuwanieRoli, @EdytowanieRoli, @NadajZmienRoleStanowisko, @RejestracjaNowegoTowaru, @ZmienHaslo, @PrzegladStanuMagazynowego, @PrzegladanieHistoriiStanuMagazynowego, @PrzegladHistoriiUzupelniania, @zmianaVAT)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Nazwa", SqlDbType.NVarChar)).Value = nazwa;
                    cmd.Parameters.Add(new SqlParameter("@DostepDoListyUzytkownikow", SqlDbType.NVarChar)).Value = dostepDoListyUzytkownikow;
                    cmd.Parameters.Add(new SqlParameter("@DostepDoListyUprawnien", SqlDbType.NVarChar)).Value = dostepDoListyUprawnien;
                    cmd.Parameters.Add(new SqlParameter("@DodawanieUzytkownika", SqlDbType.NVarChar)).Value = dodawanieUzytkownika;
                    cmd.Parameters.Add(new SqlParameter("@UsuwanieUzytkownika", SqlDbType.NVarChar)).Value = usuwanieUzytkownika;
                    cmd.Parameters.Add(new SqlParameter("@EdytowanieUzytkownika", SqlDbType.NVarChar)).Value = edytowanieUzytkownika;
                    cmd.Parameters.Add(new SqlParameter("@DodawanieRoli", SqlDbType.NVarChar)).Value = dodawanieRoli;
                    cmd.Parameters.Add(new SqlParameter("@UsuwanieRoli", SqlDbType.NVarChar)).Value = usuwanieRoli;
                    cmd.Parameters.Add(new SqlParameter("@EdytowanieRoli", SqlDbType.NVarChar)).Value = edytowanieRoli;
                    cmd.Parameters.Add(new SqlParameter("@NadajZmienRoleStanowisko", SqlDbType.NVarChar)).Value = nadajZmienRoleStanowisko;
                    cmd.Parameters.Add(new SqlParameter("@RejestracjaNowegoTowaru", SqlDbType.NVarChar)).Value = rejestracjaNowegoTowaru;
                    cmd.Parameters.Add(new SqlParameter("@ZmienHaslo", SqlDbType.NVarChar)).Value = zmienHaslo;
                    cmd.Parameters.Add(new SqlParameter("@PrzegladStanuMagazynowego", SqlDbType.NVarChar)).Value = przegladStanuMagazynowego;
                    cmd.Parameters.Add(new SqlParameter("@PrzegladanieHistoriiStanuMagazynowego", SqlDbType.NVarChar)).Value = przegladanieHistoriiStanuMagazynowego;
                    cmd.Parameters.Add(new SqlParameter("@PrzegladHistoriiUzupelniania", SqlDbType.NVarChar)).Value = przegladHistoriiUzupelniania;
                    cmd.Parameters.Add(new SqlParameter("@zmianaVAT", SqlDbType.NVarChar)).Value = zmianaVAT;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public DataTable PobierzDaneRoli(int roleId)
        {
            string query = "SELECT [Nazwa_stanowiska], [DostepDoListyUzytkownikow], [DostepDoListyUprawnien], [DodawanieUzytkownika], [UsuwanieUzytkownika], [EdytowanieUzytkownika], [DodawanieRoli], [UsuwanieRoli], [EdytowanieRoli], [NadajZmienRoleStanowisko],[RejestracjaNowegoTowaru],[ZmienHaslo],[PrzegladStanuMagazynowego],[PrzegladanieHistoriiStanuMagazynowego],[PrzegladHistoriiUzupelniania],[zmianaVAT] FROM dbo.Uprawnienia WHERE UprawnienieID = @roleId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@roleId", roleId);

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);

                return dt;
            }
        }

        public bool CzyNazwaRoliIstnieje(string nazwa)
        {
            string query = "SELECT COUNT(*) FROM dbo.Uprawnienia WHERE Nazwa_stanowiska = @Nazwa";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nazwa", nazwa);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public bool AktualizujRole(int roleId, string nazwaRoli, string dostepDoListyUzytkownikow, string dostepDoListyUprawnien,
                                   string dodawanieUzytkownika, string usuwanieUzytkownika, string edytowanieUzytkownika,
                                   string dodawanieRoli, string usuwanieRoli, string edytowanieRoli, string nadawanieRoli,
                                   string rejesrowanieTowaru, string zmianaHasla, string przegladStanuMagazynowego,
                                   string przegladanieHistoriiStanuMagazynowego, string przegladHistoriiUzupelniania,
                                   string zmianaVAT)
        {
            string query = @"UPDATE dbo.Uprawnienia 
                             SET Nazwa_stanowiska = @NazwaRoli, 
                                 DostepDoListyUzytkownikow = @DostepDoListyUzytkownikow, 
                                 DostepDoListyUprawnien = @DostepDoListyUprawnien, 
                                 DodawanieUzytkownika = @DodawanieUzytkownika, 
                                 UsuwanieUzytkownika = @UsuwanieUzytkownika, 
                                 EdytowanieUzytkownika = @EdytowanieUzytkownika, 
                                 DodawanieRoli = @DodawanieRoli, 
                                 UsuwanieRoli = @UsuwanieRoli, 
                                 EdytowanieRoli = @EdytowanieRoli,
                                 NadajZmienRoleStanowisko = @NadajZmienRoleStanowisko,
                                 RejestracjaNowegoTowaru = @RejestracjaNowegoTowaru,
                                 ZmienHaslo = @ZmienHaslo,
                                 PrzegladStanuMagazynowego = @PrzegladStanuMagazynowego,
                                 PrzegladanieHistoriiStanuMagazynowego = @PrzegladanieHistoriiStanuMagazynowego,
                                 PrzegladHistoriiUzupelniania = @PrzegladHistoriiUzupelniania,
                                 zmianaVAT = @zmianaVAT
                             WHERE UprawnienieID = @ID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NazwaRoli", nazwaRoli);
                cmd.Parameters.AddWithValue("@DostepDoListyUzytkownikow", dostepDoListyUzytkownikow);
                cmd.Parameters.AddWithValue("@DostepDoListyUprawnien", dostepDoListyUprawnien);
                cmd.Parameters.AddWithValue("@DodawanieUzytkownika", dodawanieUzytkownika);
                cmd.Parameters.AddWithValue("@UsuwanieUzytkownika", usuwanieUzytkownika);
                cmd.Parameters.AddWithValue("@EdytowanieUzytkownika", edytowanieUzytkownika);
                cmd.Parameters.AddWithValue("@DodawanieRoli", dodawanieRoli);
                cmd.Parameters.AddWithValue("@UsuwanieRoli", usuwanieRoli);
                cmd.Parameters.AddWithValue("@EdytowanieRoli", edytowanieRoli);
                cmd.Parameters.AddWithValue("@NadajZmienRoleStanowisko", nadawanieRoli);
                cmd.Parameters.AddWithValue("@RejestracjaNowegoTowaru", rejesrowanieTowaru);
                cmd.Parameters.AddWithValue("@ZmienHaslo", zmianaHasla);
                cmd.Parameters.AddWithValue("@PrzegladStanuMagazynowego", przegladStanuMagazynowego);
                cmd.Parameters.AddWithValue("@PrzegladanieHistoriiStanuMagazynowego", przegladanieHistoriiStanuMagazynowego);
                cmd.Parameters.AddWithValue("@PrzegladHistoriiUzupelniania", przegladHistoriiUzupelniania);
                cmd.Parameters.AddWithValue("@zmianaVAT", zmianaVAT);
                cmd.Parameters.AddWithValue("@ID", roleId);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
