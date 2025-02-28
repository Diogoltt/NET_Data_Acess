using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkExercise
{
    public class Crud
    {
        public void InserirUsuario(int id, string nomeUsuario, string password, int ramal, string especialidade)
        {
            using (var db = new Ligacao())
            {
                db.Usuarios.Add(new Usuario
                {
                    Id = id,
                    NomeUsuario = nomeUsuario,
                    Password = password,
                    Ramal = ramal,
                    Especialidade = especialidade
                });
                db.SaveChanges();
                System.Console.WriteLine("Usuário inserido com sucesso");
            }
        }

        public void ListarUsuarios()
        {
            using (var db = new Ligacao())
            {
                var usuarios = db.Usuarios.ToList();
                foreach (var usuario in usuarios)
                {
                    System.Console.WriteLine($"Id: {usuario.Id}, Nome: {usuario.NomeUsuario}, Ramal: {usuario.Ramal}, Especialidade: {usuario.Especialidade}");
                }
            }
        }

        public void AtualizarUsuario(int id, string novoNomeUsuario)
        {
            using (var db = new Ligacao())
            {
                var usuario = db.Usuarios.Find(id);
                if (usuario != null)
                {
                    usuario.NomeUsuario = novoNomeUsuario;
                    db.SaveChanges();
                    System.Console.WriteLine("Usuário foi atualizado no banco de dados");
                }
                else
                {
                    System.Console.WriteLine("usuário não encontrado");
                }
            }
        }

        public void DeletarUsuario(int id)
        {
            using (var db = new Ligacao())
            {
                var usuario = db.Usuarios
                    .Include(u => u.Maquinas) // Carrega as máquinas associadas ao usuário
                    .FirstOrDefault(u => u.Id == id);

                if (usuario != null)
                {
                    // Remove a associação do usuário com as máquinas
                    foreach (var maquina in usuario.Maquinas)
                    {
                        maquina.UsuarioId = null; // Define a chave estrangeira como NULL
                    }

                    // Remove o usuário
                    db.Usuarios.Remove(usuario);
                    db.SaveChanges();
                    Console.WriteLine("Usuário deletado com sucesso e máquinas desassociadas!");
                }
                else
                {
                    Console.WriteLine("Usuário não encontrado.");
                }
            }
        }

        public void InserirMaquina(int id, string tipo, int velocidade, int hardDisk, int placaRede, int memoriaRam, int usuarioId)
        {
            using (var db = new Ligacao())
            {
                db.Maquinas.Add(new Maquina
                {
                    Id = id,
                    Tipo = tipo,
                    Velocidade = velocidade,
                    HardDisk = hardDisk,
                    PlacaRede = placaRede,
                    MemoriaRam = memoriaRam,
                    UsuarioId = usuarioId
                });
                db.SaveChanges();
                Console.WriteLine("Máquina inserida com sucesso!");
            }
        }

        // Método para listar todas as máquinas
        public void ListarMaquinas()
        {
            using (var db = new Ligacao())
            {
                var maquinas = db.Maquinas.ToList();
                foreach (var maquina in maquinas)
                {
                    Console.WriteLine($"Id: {maquina.Id}, Tipo: {maquina.Tipo}, Velocidade: {maquina.Velocidade}, HD: {maquina.HardDisk}, Memória: {maquina.MemoriaRam}, Usuário ID: {maquina.UsuarioId}");
                }
            }
        }

        // Método para inserir um software
        public void InserirSoftware(int id, string produto, int hardDisk, int memoriaRam, int maquinaId)
        {
            using (var db = new Ligacao())
            {
                db.Softwares.Add(new Software
                {
                    Id = id,
                    Produto = produto,
                    HardDisk = hardDisk,
                    MemoriaRam = memoriaRam,
                    MaquinaId = maquinaId
                });
                db.SaveChanges();
                Console.WriteLine("Software inserido com sucesso!");
            }
        }

        // Método para listar todos os softwares
        public void ListarSoftwares()
        {
            using (var db = new Ligacao())
            {
                var softwares = db.Softwares.ToList();
                foreach (var software in softwares)
                {
                    Console.WriteLine($"Id: {software.Id}, Produto: {software.Produto}, HD: {software.HardDisk}, Memória: {software.MemoriaRam}, Máquina ID: {software.MaquinaId}");
                }
            }
        }
    }
}

