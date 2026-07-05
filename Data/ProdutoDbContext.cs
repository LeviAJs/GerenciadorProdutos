using Mercado.Model;
using Microsoft.EntityFrameworkCore;

namespace Mercado.Data{

 class ProdutoDb : DbContext
{
    public ProdutoDb( DbContextOptions options) : base(options) {}
    public DbSet<Produto> produtos {get; set;}
}
}
