using System.Diagnostics;

namespace Entity
{
    public class Executar
    {
        static void Main(string[] args)
        {
            const string SPACING = "-----------------------------";

            var crud = new Crud();

            var sw = new Stopwatch();
            TimeSpan tempoTotal;

            sw.Start();
            crud.ListarUsuarios();
            sw.Stop();
            System.Console.WriteLine($"Tempo de listagem: {sw.ElapsedMilliseconds}ms");
            System.Console.WriteLine(SPACING);

            System.Console.WriteLine("Inserindo um novo usuário");
            sw.Restart();
            crud.InserirUsuario(8, "Pessoa 8", "pessoa8@gmail.com");
            sw.Stop();
            System.Console.WriteLine($"Tempo de inserção: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoInsercao = sw.Elapsed;
            crud.ListarUsuarios();
            System.Console.WriteLine(SPACING);

            System.Console.WriteLine("Atualizando um usuário");
            sw.Restart();
            crud.AtualizarUsuario(8, "Pessoa atualizada 8");
            sw.Stop();
            System.Console.WriteLine($"Tempo de atualização: {sw.ElapsedMilliseconds}ms");
            crud.ListarUsuarios();
            System.Console.WriteLine(SPACING);

            System.Console.WriteLine("Deletando um usuário");
            sw.Restart();
            crud.DeletarUsuario(8);
            sw.Stop();
            System.Console.WriteLine($"Tempo de deleção: {sw.ElapsedMilliseconds}ms");
            crud.ListarUsuarios();
            System.Console.WriteLine(SPACING);

            tempoTotal = tempoInsercao + sw.Elapsed;
            System.Console.WriteLine($"Tempo total de execução: {tempoTotal.TotalMilliseconds}ms");
        }
    }
}