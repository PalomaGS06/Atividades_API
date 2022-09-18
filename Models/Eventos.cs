using System;
using System.ComponentModel.DataAnnotations;


namespace APIMaisEventos.Models
{
    public class Eventos
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Informar o dia e horário!")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "Informar se está ativo!")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Informar o preço do evento!")]
        public decimal Preco { get; set; }

        
        [Required(ErrorMessage = "Informar o Id da Categoria!")]
        public Categorias Categoria { get; set; }

    }
}
