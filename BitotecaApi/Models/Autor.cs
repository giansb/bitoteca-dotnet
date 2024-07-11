using System.ComponentModel.DataAnnotations;

namespace BitotecaApi.Models
{
    public class Autor
    {
        [Key]

        public int Id { get; set; }

        [Required(ErrorMessage ="O nome do autor é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A biografia do autor é obrigatória")]
        [MaxLength(1500, ErrorMessage ="O tamanho máximo para a biografia do autor é de 1500 caracteres")]
        public string biografia { get; set; }

        [Required(ErrorMessage = "A url da imagem do autor é obrigatória")]
        public string imagem_url { get; set; }
    }
}
