
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Diagnostics.Tracing;
using Mercado.Data;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


// para conseguir abri o swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("AppDbConnecticonString");
builder.Services.AddDbContext<ProdutoDb>(Options => Options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString) ));


var app = builder.Build();
ProdutoApi.map(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
     //interface gráfica 
    app.MapSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();







/*
correção agora dia 19/06

Delete poderia ser 
app.MapDelete("/Deletar/{id}", (int id){

var produto = listaProduto.FirstOrDefault(p => p.id == id)

if (produto != null){
listaProduto.Remove(produto);
}
}
);

app.MapPut("Atualizacao/{id}, (int id, Produto NomeAtualizado ){

var produto = lista.ProdutoFristOrDefault(p => p.id == id)

if (produto != null){

produto.Nome = NomeAtualizado.Nome;

}

});

return Result.ok("Produto removido")

return Resulta.NotFound();


GET    /produtos
GET    /produtos/{id}
POST   /produtos
PUT    /produtos/{id}
DELETE /produtos/{id}

*/



app.Run();
