using System.ComponentModel.DataAnnotations;

namespace APIMaisEventos.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informar seu nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informar seu email!")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informar um email válido!!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informar sua senha!")]
        [MinLength(8)] // Colocar senha de até 8 dígitos 
                       // definindo um valor mínimo para a senha
        public string Senha { get; set; }

        public string Imagem { get; set; }
    }
}

// Esse símbolo .+ significa 'qualquer coisa'