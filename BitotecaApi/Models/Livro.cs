using System.ComponentModel.DataAnnotations;

namespace BitotecaApi.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Id_autor {  get; set; }
        public string ISBN { get; set; }
        public int Id_editora { get; set; }
        public DateTime Data_publicacao { get; set; }
        public int Numero_paginas { get; set; }
        public int Id_genero { get; set; }
        public string Descricao { get; set; }
        public int Id_idioma { get; set; }
        public DateTime Data_cadastro { get; set; }
        public decimal preco {  get; set; }
        public string Imagem_url { get; set; }
        public int Qtd_estoque { get; set; }
        public string Sinopsia { get; set; }
        public int Qtd_vendidos { get; set; }
    }
}
