using System.ComponentModel.DataAnnotations;

namespace BitotecaApi.Models
{
    public class Editora
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
