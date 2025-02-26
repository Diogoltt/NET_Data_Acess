using System;
using System.Diagnostics;
using Npgsql;

namespace Exemplo1
{
    public class Crud
    {
        string StringConnect = "Host=localhost;Database=dataconnect;Username=postgres;Password=30427693";

        void InserirUsuario(int id, string nome, string email)
        {
            string Query = @"
            INSERT INTO 
                usuarios (id, nome, email) 
            VALUES 
                (@id, @nome, @email)";

            using (var connect = new NpgsqlConnection(StringConnect))
            {
                connect.Open();
                using (var cmd = new NpgsqlCommand(Query, connect))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("nome", nome);
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        void LerUsuario()
        {
            string Query = @"
            SELECT
                *
            FROM
                usuarios";

            using (var connect = new NpgsqlConnection(StringConnect))
            {
                connect.Open();
                using (var cmd = new NpgsqlCommand(Query, connect))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Id: {reader["id"]}, Nome: {reader["nome"]}, Email: {reader["email"]}");
                        }
                    }
                }
            }
        }

        void AtualizarUsuario(int id, string nome)
        {
            string Query = @"
            UPDATE
                usuarios
            SET
                nome = @nome
            WHERE
                id = @id";

            using (var connect = new NpgsqlConnection(StringConnect))
            {
                connect.Open();
                using (var cmd = new NpgsqlCommand(Query, connect))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("nome", nome);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        void DeletarUsuario(int id)
        {
            string Query = @"
            DELETE
            FROM
                usuarios
            WHERE
                id = @id";

            using (var connect = new NpgsqlConnection(StringConnect))
            {
                connect.Open();
                using (var cmd = new NpgsqlCommand(Query, connect))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        static void Main(string[] args)
        {

            var crud = new Crud();
            var sw = new Stopwatch();
            TimeSpan tempoTotal;

            sw.Start();
            System.Console.WriteLine();
            crud.InserirUsuario(7, "Fulano", "fulano@gmail.com");
            sw.Stop();
            System.Console.WriteLine($"Tempo de inserção: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoInsercao = sw.Elapsed;

            sw.Restart();
            System.Console.WriteLine("Leitura de registros: ");
            crud.LerUsuario();
            sw.Stop();
            System.Console.WriteLine($"Tempo de leitura: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoLeitura = sw.Elapsed;
            System.Console.WriteLine();

            sw.Restart();
            System.Console.WriteLine("Atualizando ID 7");
            System.Console.WriteLine();
            crud.AtualizarUsuario(7, "Ciclano");
            sw.Start();
            System.Console.WriteLine($"Tempo de update: {sw.ElapsedMilliseconds}ms");
            System.Console.WriteLine();
            TimeSpan tempoAtualizacao = sw.Elapsed;


            sw.Restart();
            System.Console.WriteLine("Delete de registros: ");
            crud.DeletarUsuario(7);
            sw.Stop();
            System.Console.WriteLine($"Tempo de deleção: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoDelecao = sw.Elapsed;

            tempoTotal = tempoInsercao + tempoLeitura + tempoAtualizacao + tempoDelecao;
            System.Console.WriteLine($"Tempo total de execução: {tempoTotal}");
        }
    }
}