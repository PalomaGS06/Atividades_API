using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIMaisEventos.Models
{
    public class Categorias
    {
        public int Id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Categoria { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Imagem { get; set; }
    }
}
