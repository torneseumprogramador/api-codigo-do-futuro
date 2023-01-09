using api.Models;

namespace api.Repositorios.Interfaces;

public interface IServico
{
    List<Cliente> Todos();
    void Incluir(Cliente cliente);
    Cliente Atualizar(Cliente cliente);
    void Apagar(Cliente cliente);
}