using api.Models;
using api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.ModelViews;


public class ClienteContexto : DbContext 
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conexao = Environment.GetEnvironmentVariable("DATABASE_URL_CDF");
        if(conexao is null) conexao = "Server=localhost;Database=locacaoVeiculosCDFGroupBy;Uid=root;Pwd=root;";
        optionsBuilder.UseMySql(conexao, ServerVersion.AutoDetect(conexao));
    }

    public DbSet<Cliente> Clientes { get; set; } = default!;
}

public class ClienteRepositorioEntity : IServico
{
    private ClienteContexto contexto;
    public ClienteRepositorioEntity()
    {
        contexto = new ClienteContexto();
    }

    private string? conexao = null;

    public List<Cliente> Todos()
    {
        return contexto.Clientes.ToList();
    }

    public void Incluir(Cliente cliente)
    {
        contexto.Clientes.Add(cliente);
        contexto.SaveChanges();
    }

    public Cliente Atualizar(Cliente cliente)
    {
        contexto.Entry(cliente).State = EntityState.Modified;
        contexto.SaveChanges();

        return cliente;
    }

    public void Apagar(Cliente cliente)
    {
        var obj = contexto.Clientes.Find(cliente.Id);
        if(obj is null) throw new Exception("Cliente não encontrado");
        contexto.Clientes.Remove(obj);
        contexto.SaveChanges();
    }
}