using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.DTO;

public class LoginUsuarioDto 
{
    [Required]
    public required string Username { get; set; }

    [Required]
    public required string Password { get; set; }
}
