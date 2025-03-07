using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Forms_Exercise.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        [Column("id_usuario")]
        public int Id { get; set; }

        [Column("password")]
        public string Password { get; set; } = string.Empty;

        [Column("nome_usuario")]
        public string NomeUsuario { get; set; } = string.Empty;

        [Column("ramal")]
        public int Ramal { get; set; }

        [Column("especialidade")]
        public string Especialidade { get; set; } = string.Empty;

        public ICollection<Maquina> Maquinas { get; set; } = new List<Maquina>();
    }
}
