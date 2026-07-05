using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Mercado.Model{
 class Produto
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Nome { get; set; }
    [Required]
    public double Preco { get; set; } = 0.0;
}
}
