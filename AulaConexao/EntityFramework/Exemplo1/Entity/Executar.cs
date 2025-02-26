namespace Entity
{
    public class Executar
    {
        static void Main(string[] args)
        {
            const string SPACING = "-----------------------------";
            
            var crud = new Crud();
            crud.ListarUsuarios();
            System.Console.WriteLine(SPACING);
            
            System.Console.WriteLine("Inserindo um novo usuário");
            crud.InserirUsuario(8, "Pessoa 8", "pessoa8@gmail.com");
            crud.ListarUsuarios();
            System.Console.WriteLine(SPACING);

            System.Console.WriteLine("Atualizando um usuário");
            crud.AtualizarUsuario(8, "Pessoa atualizada 8");
            crud.ListarUsuarios();
            System.Console.WriteLine(SPACING);

            System.Console.WriteLine("Deletando um usuário");
            crud.DeletarUsuario(8);
            crud.ListarUsuarios();
            System.Console.WriteLine(SPACING);
        }
    }
}