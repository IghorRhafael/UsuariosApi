using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.DTO;

public class CreateUsuarioDto
{
    [Required]
    public required string UserNome { get; set; }

    [Required]
    public DateTime DataNascimento { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string? ConfirmPassword { get; set; }
}
