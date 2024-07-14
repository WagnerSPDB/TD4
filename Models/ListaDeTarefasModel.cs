using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace td4.Models;

public class ListaDeTarefasModel
{

    public int Id { get; set; }
    [Required(ErrorMessage = "A tarefa é obrigatória.")]
    public string? Tarefa { get; set; }

    [Required(ErrorMessage = "A data é obrigatória.")]
    public DateTime Data { get; set; }

    [Required(ErrorMessage = "A hora é obrigatória.")]
    public TimeSpan Hora { get; set; }
}
