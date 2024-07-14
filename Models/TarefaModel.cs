using System.ComponentModel.DataAnnotations;

namespace td4.Models;

public class TarefaModel
{
    public int Id {get; set;}

    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "A categoria é obrigatória.")]
    public string? Categoria {get; set;}

}
