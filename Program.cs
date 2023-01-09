using api.Models;
using api.ModelViews;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

ClienteRepositorio.Instancia().Lista.Add(new Cliente { Id = 1, Nome="Luan"});
ClienteRepositorio.Instancia().Lista.Add(new Cliente { Id = 2, Nome="Bea"});
ClienteRepositorio.Instancia().Lista.Add(new Cliente { Id = 3, Nome="Leo"});
ClienteRepositorio.Instancia().Lista.Add(new Cliente { Id = 4, Nome="Carina"});
ClienteRepositorio.Instancia().Lista.Add(new Cliente { Id = 5, Nome="Sung Ju"});

app.Run();
