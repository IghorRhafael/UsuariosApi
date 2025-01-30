using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.DTO;
using UsuariosApi.Models;

namespace UsuariosApi.Services;

public class UsuarioService
{
    private readonly IMapper _mapper;
    private readonly UserManager<Usuario> _userManager;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly TokenService _tokenservice;

    public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, TokenService tokenservice)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenservice = tokenservice;
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

    public async Task<string> Login(LoginUsuarioDto loginDto)
    {
        //Faz o login do usuario e não persiste cookie e não bloqueia a conta em caso de falha. 
        var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);

        if (!result.Succeeded) {
            throw new ApplicationException("Usuário não autenticado!");
        }

        var usuario = _signInManager
            .UserManager
            .Users.FirstOrDefault(u => loginDto.Username.ToUpper().Equals(u.NormalizedUserName));

        var token = _tokenservice.GenerateToken(usuario);

        return token;
    }
}
