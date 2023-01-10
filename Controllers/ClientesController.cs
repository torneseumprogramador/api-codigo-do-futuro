using Microsoft.AspNetCore.Mvc;
using api.ModelViews;
using api.Models;

namespace api.Controllers;

[Route("clientes")]
public class ClientesController : ControllerBase
{
    // GET: Clientes
    [HttpGet("")]
    public IActionResult Index()
    {
        var clientes = ClienteRepositorio.Instancia().Lista;
        return StatusCode(200, clientes);
    }

    [HttpGet("{id}")]
    public IActionResult Details([FromRoute] int id)
    {
       var cliente = ClienteRepositorio.Instancia().Lista.Find(c => c.Id == id);

        return StatusCode(200, cliente);
    }

    
    // POST: Clientes
    [HttpPost("")]
    public IActionResult Create([FromBody] Cliente cliente)
    {
        ClienteRepositorio.Instancia().Lista.Add(cliente);
        return StatusCode(201, cliente);
    }


    // PUT: Clientes/5
    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Cliente cliente)
    {
        if (id != cliente.Id)
        {
            return StatusCode(400, new {
                Mensagem = "O Id do cliente precisa bater com o id da URL"
            });
        }

       var clienteDb = ClienteRepositorio.Instancia().Lista.Find(c => c.Id == id);
       if(clienteDb is null)
       {
            return StatusCode(404, new {
                Mensagem = "O cliente informado não existe"
            });
        }

        clienteDb.Nome = cliente.Nome;
        clienteDb.Endereco = cliente.Endereco;
        clienteDb.Telefone = cliente.Telefone;
        clienteDb.Email = cliente.Email;

        return StatusCode(200, clienteDb);
    }

    // POST: Clientes/5
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var clienteDb = ClienteRepositorio.Instancia().Lista.Find(c => c.Id == id);
        if(clienteDb is null)
        {
            return StatusCode(404, new {
                Mensagem = "O cliente informado não existe"
            });
        }

        ClienteRepositorio.Instancia().Lista.Remove(clienteDb);

        return StatusCode(204);
    }
}
