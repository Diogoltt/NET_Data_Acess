using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DapperExemplo
{
    [Table("usuarios")] // Atributo de mapeamento c# para mapear os campos da tabela de usuárioss para a classe de usuários
    public class Usuarios
    {
        [Key] // Atributo de mapeamento de chave primária
        [Column("id")] // Para chave estrangeira: [ForeignKey("column_name")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = string.Empty; // Iniciar propriedade com string vazia

        [Column("email")]
        public string Email { get; set; } = string.Empty;
    }
}