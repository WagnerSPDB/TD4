using System.ComponentModel.DataAnnotations;

namespace td4.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string? Nome { get; set; }
    }
}
