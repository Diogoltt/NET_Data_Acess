using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF_Forms_Exercise.Models
{
    [Table("software")]
    public class Software
    {
        [Key]
        [Column("id_software")]
        public int Id { get; set; }

        [Column("produto")]
        public string Produto { get; set; } = string.Empty;

        [Column("harddisk")]
        public int HardDisk { get; set; }

        [Column("memoria_ram")]
        public int MemoriaRam { get; set; }

        [ForeignKey("maquina")]
        [Column("fk_maquina")]
        public int MaquinaId { get; set; }

        public Maquina Maquina { get; set; } = null!;
    }
}
