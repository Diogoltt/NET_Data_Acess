using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    [Table("usuarios")] // Define explicitamente o nome da tabela

    public class Usuario
    {
        [Column("id")] // Define explicitamente o nome da coluna
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = string.Empty; // Valor padrão que evita campo nulo

        [Column("email")]
        public string Email { get; set; } = string.Empty;

    }
}