using System.ComponentModel.DataAnnotations;

public class AtualizacaoDto
{
    [Required]
      [MaxLength (20, ErrorMessage ="Maximo de caracteres 20")]
    public string? Nome {get; set;}
    [Required]
     [Range(minimum:0.01, maximum: 1000.00,ErrorMessage ="O preço deve ser maior que zero." )]
    public double Preco {get; set;}
}
