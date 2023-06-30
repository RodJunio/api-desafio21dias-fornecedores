using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_desafio21dias_fornecedores.Models
{
    [Table("materiais")]
    public partial class Material
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name", TypeName = "varchar")]
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Column("aluno_id", TypeName = "varchar")]
        [Required]
        public int AlunoId { get; set; }
    }
}
