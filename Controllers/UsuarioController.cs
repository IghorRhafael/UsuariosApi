using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.DTO;
using UsuariosApi.Models;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly CadastroService _cadastroService;

    public UsuarioController(IMapper mapper, UserManager<Usuario> userManager, CadastroService cadastroService)
    {
        _cadastroService = cadastroService;
    }

    [HttpPost]
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto userDto)
    {
        await _cadastroService.CadastraUsuario(userDto);
        return Ok("Usuário Cadastrado!");
    }
}