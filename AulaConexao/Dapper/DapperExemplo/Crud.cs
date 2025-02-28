using System.Data;
using Dapper;

namespace DapperExemplo
{
    public class Crud
    {
        public void InsertUsuario(int id, string nome, string email)
        {
            using (IDbConnection db = Conexao.GetConexao())
            {
                string query = @$"
                INSERT INTO 
                    usuarios (id, nome, email)
                VALUES
                    ({id}, '{nome}', '{email}')";
                
                db.Execute(query);
                System.Console.WriteLine($"Usuário {nome} inserido com sucesso");
            }
        }

        public void ListarUsuario()
        {
            using (IDbConnection db = Conexao.GetConexao())
            {
                string query = @"
                SELECT 
                    *
                FROM
                    usuarios
                ";
                var usuarios = db.Query<Usuarios>(query).ToList();

                System.Console.WriteLine("\n Lista de usuários: \n");
                foreach (var usuario in usuarios)
                {
                    System.Console.WriteLine($"Id: {usuario.Id} | Nome: {usuario.Nome} | Email: {usuario.Email}");
                }
            }
        }

        public void AtualizarUsuario (int id, string novoNome)
        {
            using (IDbConnection db = Conexao.GetConexao())
            {
                string query = @$"
                UPDATE
                    usuarios
                SET
                    nome = '{novoNome}'
                WHERE
                    id = {id}";
                db.Execute(query);
                System.Console.WriteLine($"Usuário com id {id} atualizado com sucesso");
            }
        }

        public void DeletarUsuario(int id)
        {
            using (IDbConnection db = Conexao.GetConexao())
            {
                string query = @$"
                DELETE
                FROM
                    usuarios
                WHERE
                    id = {id}";
                db.Execute(query);
                System.Console.WriteLine($"Usuário com id {id} deletado com sucesso");
            }
        }
    }
}