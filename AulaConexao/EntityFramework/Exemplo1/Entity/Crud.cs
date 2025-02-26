namespace Entity
{
    public class Crud
    {
        public void InserirUsuario(int id, string nome, string email)
        {
            using (var db = new Ligacao())
            {
                db.Usuarios.Add(new Usuario { Id = id, Nome = nome, Email = email});
                db.SaveChanges();
            }
        }

        public void ListarUsuarios()
        {
            using (var db = new Ligacao())
            {
                var usuarios = db.Usuarios.ToList();
                foreach ( var usuario in usuarios)
                {
                    System.Console.WriteLine($"Id: {usuario.Id} Nome: {usuario.Nome} Email: {usuario.Email}");
                }
            }
        }

        public void AtualizarUsuario(int id, string novoNome)
        {
            using (var db = new Ligacao())
            {
                var usuario = db.Usuarios.Find(id); // Procura usuário pelo id
                if (usuario != null)
                {
                    usuario.Nome = novoNome;
                    db.SaveChanges();
                    System.Console.WriteLine("Usuário foi atualizado no banco de dados.");
                }
                else
                {
                    System.Console.WriteLine("Usuário não encontrados");
                }
            }
        }

        public void DeletarUsuario(int id)
        {
            using (var db = new Ligacao())
            {
                var usuario = db.Usuarios.Find(id);
                if (usuario != null)
                {
                    db.Usuarios.Remove(usuario);
                    db.SaveChanges();
                    System.Console.WriteLine("Usuário deletado com sucesso");
                }
                else
                {
                    System.Console.WriteLine("Usuário não encontrado");
                }
            }
        }
    }
}