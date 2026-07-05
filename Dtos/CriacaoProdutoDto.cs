using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;


public class CriacaoProdutoDTO
    {
        [Required]
        [MaxLength (20, ErrorMessage ="Maximo de caracteres 20")]
        public string Nome {get; set;} = string.Empty;
        [Range(minimum:0.01, maximum: 1000.00,ErrorMessage ="O preço deve ser maior que zero." )]
        public double Preco {get; set;} = 0.0;
    }

