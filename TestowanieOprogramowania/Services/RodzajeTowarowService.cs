using Microsoft.Data.SqlClient;
using System.Data;

namespace TestowanieOprogramowania.Services
{
    public class RodzajeTowarowService
    {
        private readonly string _connectionString;

        public RodzajeTowarowService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable PobierzRodzajeTowarow()
        {
            string query = "SELECT RodzajTowaruID, NazwaRodzaju, StawkaVAT FROM RodzajeTowarow";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public void DodajRodzajTowaru(string nazwaRodzaju, string stawkaVAT)
        {
            string query = "INSERT INTO RodzajeTowarow (NazwaRodzaju, StawkaVAT) VALUES (@NazwaRodzaju, @StawkaVAT)";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NazwaRodzaju", nazwaRodzaju);
                    cmd.Parameters.AddWithValue("@StawkaVAT", stawkaVAT);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UsunRodzajTowaru(int rodzajTowaruId)
        {
            string query = "DELETE FROM RodzajeTowarow WHERE RodzajTowaruID = @RodzajTowaruID";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RodzajTowaruID", rodzajTowaruId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
