using api.Models;

namespace api.ModelViews;

public class ClienteRepositorio
{
    private ClienteRepositorio() {
        Lista = new List<Cliente>();
    }

    public List<Cliente> Lista = default!;
    private static ClienteRepositorio? clienteRepositorio;

    public static ClienteRepositorio Instancia()
    {
        if(clienteRepositorio is null) clienteRepositorio = new ClienteRepositorio();
        return clienteRepositorio;
    }
}