﻿using System.ComponentModel.DataAnnotations;

namespace BitotecaApi.Models
{
    public class Editora
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cep { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
