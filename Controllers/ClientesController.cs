using Microsoft.AspNetCore.Mvc;
using api.ModelViews;
using api.Models;
using api.Repositorios.Interfaces;

namespace api.Controllers;

[Route("clientes")]
public class ClientesController : ControllerBase
{
    private IServico _servico;
    public ClientesController(IServico servico)
    {
        _servico = servico;
    }
    // GET: Clientes
    [HttpGet("")]
    public IActionResult Index()
    {
        var clientes = _servico.Todos();
        return StatusCode(200, clientes);
    }

    [HttpGet("{id}")]
    public IActionResult Details([FromRoute] int id)
    {
       var cliente = _servico.Todos().Find(c => c.Id == id);

        return StatusCode(200, cliente);
    }

    
    // POST: Clientes
    [HttpPost("")]
    public IActionResult Create([FromBody] Cliente cliente)
    {
        _servico.Incluir(cliente);
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

        var clienteDb = _servico.Atualizar(cliente);

        return StatusCode(200, clienteDb);
    }

    // POST: Clientes/5
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var clienteDb = _servico.Todos().Find(c => c.Id == id);
        if(clienteDb is null)
        {
            return StatusCode(404, new {
                Mensagem = "O cliente informado não existe"
            });
        }

        _servico.Apagar(clienteDb);

        return RedirectToAction(nameof(Index));
    }
}
