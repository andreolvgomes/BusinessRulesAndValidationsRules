using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BusinessRulesAndValidationsRules
{
    public class Vendedores
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Product
    {
        [Required(ErrorMessage = "Informe o Id do Produto")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Informe a descrição do produto")]
        public string Descricao { get; set; }

        [Required, MinLength(1, ErrorMessage = "At least one item required in work order")]
        public List<string> Empresas { get; set; } = new List<string>();

        [EmailAddress]
        [Required(ErrorMessage = "Informe o Email do produto")]
        public string Email { get; set; }

        [JsonProperty("preco", ItemConverterType = typeof(decimal))]
        [JsonConverter(typeof(decimal))]
        [Required(ErrorMessage = "Informe o preço do produto")]
        public decimal Preco { get; set; }

        [JsonProperty("estoque")]
        [MinValue(1, ErrorMessage = "A quantidade em estoque deve ser de no mínimo 1 (uma) unidade")]
        public int Estoque { get; set; }

        [JsonProperty("disponivel", ItemConverterType = typeof(bool))]
        [JsonConverter(typeof(bool))]
        public bool Disponivel { get; set; }
    }
}