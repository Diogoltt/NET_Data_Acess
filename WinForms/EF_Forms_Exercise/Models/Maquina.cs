using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF_Forms_Exercise.Models
{
    [Table("maquina")]
    public class Maquina
    {
        [Key]
        [Column("id_maquina")]
        public int Id { get; set; }

        [Column("tipo")]
        public string Tipo { get; set; } = string.Empty;

        [Column("velocidade")]
        public int Velocidade { get; set; }

        [Column("harddisk")]
        public int HardDisk { get; set; }

        [Column("placa_rede")]
        public int PlacaRede { get; set; }

        [Column("memoria_ram")]
        public int MemoriaRam { get; set; }

        [ForeignKey("usuario")]
        [Column("fk_usuario")]
        public int? UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

        public ICollection<Software> Softwares { get; set; } = new List<Software>();
    }
}
