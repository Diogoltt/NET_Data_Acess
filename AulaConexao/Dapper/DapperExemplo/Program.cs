using System;
using System.Diagnostics;

namespace DapperExemplo
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string SPACING = "------------------";
            var stopwatch = new Stopwatch();
            var crud = new Crud();

            TimeSpan tempoTotal = TimeSpan.Zero;

            stopwatch.Start();
            crud.ListarUsuario();
            stopwatch.Stop();
            tempoTotal += stopwatch.Elapsed;
            Console.WriteLine($"Tempo para listar usuários: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine(SPACING);

            stopwatch.Restart();
            crud.InsertUsuario(13, "Teste123", "teste123@gmail.com");
            stopwatch.Stop();
            tempoTotal += stopwatch.Elapsed;
            Console.WriteLine($"Tempo para inserir usuário: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine(SPACING);

            stopwatch.Restart();
            crud.ListarUsuario();
            stopwatch.Stop();
            tempoTotal += stopwatch.Elapsed;
            Console.WriteLine($"Tempo para listar usuários após inserção: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine(SPACING);

            stopwatch.Restart();
            crud.AtualizarUsuario(13, "testeupdate");
            stopwatch.Stop();
            tempoTotal += stopwatch.Elapsed;
            Console.WriteLine($"Tempo para atualizar usuário: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine(SPACING);

            stopwatch.Restart();
            crud.ListarUsuario();
            stopwatch.Stop();
            tempoTotal += stopwatch.Elapsed;
            Console.WriteLine($"Tempo para listar usuários após atualização: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine(SPACING);

            stopwatch.Restart();
            crud.DeletarUsuario(13);
            stopwatch.Stop();
            tempoTotal += stopwatch.Elapsed;
            Console.WriteLine($"Tempo para deletar usuário: {stopwatch.ElapsedMilliseconds} ms");

            Console.WriteLine(SPACING);
            Console.WriteLine($"Tempo total de execução: {tempoTotal.TotalMilliseconds} ms");
        }
    }
}