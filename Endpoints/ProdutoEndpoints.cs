using Mercado.Model;
using Mercado.Data;
using Microsoft.EntityFrameworkCore;


public  static class ProdutoApi 
{

public static void map(WebApplication app){
//mostrar produto
app.MapGet("/produto", (ProdutoDb db) =>
{
    return Results.Ok(db.produtos);
});

// cadastro de um novo item
app.MapPost ("/produto", async ( CriacaoProdutoDTO item, ProdutoDb db )  =>
{
    /* ele ira validar o mesmo nome que recebe e vai se tornar true
   if (cadastroProduto.Nome.Contains(cadastroProduto.Nome))
   {
     listaProduto.Add(cadastroProduto);
   }

    return Results.NotFound("Não tem nome");
   */
   
    
    Produto produto = new Produto
    {
       Nome = item.Nome,
       Preco = item.Preco
    };

    await db.AddAsync(produto);
    await db.SaveChangesAsync();
    return Results.Created($"/produto/{produto.Id}", produto);

    
}
);

// atualizaçao dos cadastraso
app.MapPut("/produto/{id}", async (int id, AtualizacaoDto dto, ProdutoDb db) =>
{
  /*foreach (var procuraItem in listaProduto)
  {
    if (id == procuraItem.Id)
        {
            procuraItem.Nome = nomeAtualizado.Nome;
            return Results.Ok("Atualizacao feita");
        }
  }
  return Results.BadRequest("Id não encontrado");*/

  //var produto = listaProduto.FirstOrDefault(p => p.Id == id);
    
    //if (produto.Id == null)
    //if (produto == null)
        //return Results.NotFound("Id Invalida");

    //produto.Nome = atualizado.Nome;

    //return Results.Ok("Atualizacao feita");

    var produto = await db.produtos.FindAsync(id);
    if (produto == null) return Results.NotFound("ID não encontrado");
    
    produto.Nome = dto.Nome;
    if (string.IsNullOrEmpty(dto.Nome)) return Results.NotFound("precisa de um nome");
    

    await db.SaveChangesAsync();
    return Results.Ok("Atualizado com sucesso");


}
);


// buscar por id 
app.MapGet("/produto/{id}", async (int id, ProdutoDb db) =>
{
  /* foreach (Produto produto in listaProduto)
   {
    //if (produto.Id == id)
        {
            //return Results.Ok(produto);
        }
   }
   return Results.NotFound("Id invalido");*/

    var produto = await db.produtos.FindAsync(id);
     if (produto == null) return Results.NotFound("ID não encontrado");

    return Results.Ok(db.produtos);    

}
);

app.MapDelete("/produto/{id}", async (int id, ProdutoDb db) =>
{
   /*  foreach (var DeletaUser in listaProduto)
  {
    if (id == DeletaUser.Id)
        {
           listaProduto.Remove(DeletaUser);
        }
  }
     return Results.BadRequest("Id não encontrado");*/

 //var produto = listaProduto.FirstOrDefault(p => p.Id == id);
    
    //if (produto.Id == null)
    //if (produto == null)
        //return Results.NotFound("Id Invalida");

    //listaProduto.Remove(produto);
    //return Results.Ok("Atualizacao feita");

    var produto = await db.produtos.FindAsync(id);
     if (produto == null) return Results.NotFound("ID não encontrado");


    db.produtos.Remove(produto);
    await db.SaveChangesAsync();
    return Results.Ok("Item removido com sucesso");

}
);
}
}
