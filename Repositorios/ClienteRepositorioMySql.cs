using api.Models;

namespace api.ModelViews;

public class ClienteRepositorioMySql
{
    private ClienteRepositorioMySql() {
        Lista = new List<Cliente>();
    }

    public List<Cliente> Lista = default!;
    private static ClienteRepositorioMySql? clienteRepositorio;

    public static ClienteRepositorioMySql Instancia()
    {
        if(clienteRepositorio is null) clienteRepositorio = new ClienteRepositorioMySql();
        return clienteRepositorio;
    }
}