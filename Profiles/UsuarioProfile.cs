using AutoMapper;
using UsuariosApi.Data.DTO;
using UsuariosApi.Models;

namespace UsuariosApi.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CreateUsuarioDto, Usuario>();
    }
}