using System.Data.SqlClient;

namespace redmax
{
    public static class Conexion
    {
        // Cadena de conexión usando autenticación de Windows
        private static string cadena ="Server=(localdb)\\MSSQLLocalDB;Database=ControlHardwareSoftware;Integrated Security=True;";

        public static SqlConnection Conectar()
        {
            return new SqlConnection(cadena);
        }
    }
}
