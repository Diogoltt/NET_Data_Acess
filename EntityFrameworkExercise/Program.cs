namespace EntityFrameworkExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            var crud = new Crud();

            crud.InserirUsuario(1, "Diogo Leite", "senha123", 1234, "Desenvolvedor");

            crud.ListarUsuarios();

            crud.InserirMaquina(1, "Desktop", 3000, 500, 100, 16, 1);
        
            crud.ListarMaquinas();

            crud.InserirSoftware(1, "VSCODE", 20, 8, 1);

            crud.ListarSoftwares();

            crud.AtualizarUsuario(1, "Diogo Update");

            crud.DeletarUsuario(1);
        }
    }
}