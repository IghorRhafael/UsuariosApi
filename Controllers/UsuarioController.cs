using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.DTO;
using UsuariosApi.Models;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly UserManager<Usuario> _userManager;

    public UsuarioController(IMapper mapper, UserManager<Usuario> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto userDto)
    {
        Usuario usuario =  _mapper.Map<Usuario>(userDto);
        var result = await _userManager.CreateAsync(usuario, userDto.Password);

        if (result.Succeeded)
        {
            return Ok("Usuário Cadastrado!");
        }

        throw new ApplicationException("Erro ao cadastrar usuário");
    }
}
