using Npgsql;

namespace Exemplo1
{
    public class Executar
    {
        static void notMain(string[] args)
        {
            string StringConnect = "Host=localhost;Database=dataconnect;Username=postgres;Password=30427693";

            using (var connection = new NpgsqlConnection(StringConnect))
            {
                try
                {
                    connection.Open();
                    System.Console.WriteLine("Conexão aberta com postgres");

                    string query = "SELECT * FROM public.usuarios";

                    /* // Insert
                    string insertQuery = 
                    @"INSERT INTO 
                        usuarios (id, nome, email)
                    VALUES
                        (6, 'Diogo', 'Diogo@gmail.com')
                    ";
                    using (var command = new NpgsqlCommand(insertQuery, connection))
                    {
                        int row = command.ExecuteNonQuery(); // ExecuteNonQuery executa um comando que não retorna dados, como insert update ou delete
                        System.Console.WriteLine("Linhas afetadas: " + row);
                    } */

                    // Delete
                    string deleteQuery =
                    @"DELETE
                    FROM
                        usuarios
                    WHERE
                        usuarios.id = 4";

                    /* using (var command = new NpgsqlCommand(deleteQuery, connection))
                    {
                        int row = command.ExecuteNonQuery(); // ExecuteNonQuery executa um comando que não retorna dados, como insert update ou delete
                        System.Console.WriteLine("Linhas afetadas: " + row);
                    } */

                    // Update
                    string updateQuery =
                    @"UPDATE
                        usuarios
                    SET
                        nome = 'Francisco'
                    WHERE
                        id = 6
                    ";

                    using (var command = new NpgsqlCommand(updateQuery, connection))
                    {
                        int row = command.ExecuteNonQuery(); // ExecuteNonQuery executa um comando que não retorna dados, como insert update ou delete
                        System.Console.WriteLine("Linhas afetadas: " + row);
                    }

            

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            System.Console.WriteLine("Tabelas do banco de dados:");
                            while (reader.Read())
                            {
                                System.Console.WriteLine($"ID: {reader.GetInt32(0)} | Nome: {reader.GetString(1)} | Email: {reader.GetString(2)}");
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("Erro: " + e.Message);
                }

            }
        }
    }
}