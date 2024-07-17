using System.ComponentModel.DataAnnotations;

namespace BitotecaApi.Models;

public class Genero
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }
}
