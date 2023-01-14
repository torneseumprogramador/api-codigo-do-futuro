using System.ComponentModel.DataAnnotations.Schema; 
    
namespace api.Models;

[Table("administradores")]
public record Administrador
{
    public int Id { get;set; } = default!;
    public string Nome { get;set; } = default!;
    public string Email { get;set; } = default!;
    public string Senha { get;set; } = default!;
    public string Permissao { get;set; } = default!;
}
