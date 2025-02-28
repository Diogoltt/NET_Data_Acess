using System.Data;

namespace DapperExemplo
{
    public class Conexao
    {
        private static readonly string StringConnect = "Host=localhost;Database=dataconnect;Username=postgres;Password=30427693";

        public static IDbConnection GetConexao()
        {
            return new Npgsql.NpgsqlConnection(StringConnect);
        }

    }
}