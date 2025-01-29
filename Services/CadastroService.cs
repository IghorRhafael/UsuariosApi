using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.DTO;
using UsuariosApi.Models;

namespace UsuariosApi.Services;

public class CadastroService
{
    private readonly IMapper _mapper;
    private readonly UserManager<Usuario> _userManager;

    public CadastroService(IMapper mapper, UserManager<Usuario> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task CadastraUsuario(CreateUsuarioDto userDto)
    {
        Usuario usuario = _mapper.Map<Usuario>(userDto);
        var result = await _userManager.CreateAsync(usuario, userDto.Password);

        if (!result.Succeeded)
        {
            throw new ApplicationException("Erro ao cadastrar usuário");
        }
    }
}
