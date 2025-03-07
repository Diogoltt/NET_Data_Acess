using Npgsql;

namespace Exemplo3_ADO_Forms
{
    public class CRUD
    {
        const string CONNECTION_STRING = "Host=localhost;Database=Aula1;Username=postgres;Password=30427693";

        public void InserirUsuario(int id, string nome, string email)
        {
            string query = @"
            INSERT INTO
                Usuario (id, nome, email)
            VALUES
            (@id, @nome, @email)";

            using (var connect = new NpgsqlConnection(CONNECTION_STRING))
            {
                connect.Open();
                using (var command = new NpgsqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nome", nome);
                    command.Parameters.AddWithValue("@email", email);                        
                    
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<string> ListarUsuarios()
        {
            var usuario = new List<string>();
            string query = "SELECT * FROM Usuario";

            using (var connect = new NpgsqlConnection(CONNECTION_STRING))
            {
                connect.Open();
                using (var command = new NpgsqlCommand(query, connect))
                {
                    using (NpgsqlDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string linha = $"ID: {dr["id"]} Nome: {dr["nome"]} Email: {dr["email"]}";
                            usuario.Add(linha);
                        }
                    }
                }
            }
            return usuario;
        }

        public void AtualizarUsuario(int id, string novoNome)
        {
            string query = "Update usuario set Nome = @Nome where id = @id";

            using (var connect = new NpgsqlConnection(CONNECTION_STRING))
            {
                connect.Open();
                using (var command = new NpgsqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nome", novoNome);
                }
            }
        }

        public void DeletarUsuario(int id)
        {
            string query = "DELETE FROM Usuario WHERE id = @id";

            using (var connect = new NpgsqlConnection(CONNECTION_STRING))
            {
                connect.Open();
                using (var command = new NpgsqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}