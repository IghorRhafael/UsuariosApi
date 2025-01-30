using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UsuariosApi.Authorization;

public class IdadeAuthorization : AuthorizationHandler<IdadeMinima>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinima requirement)
    {
        var dataNascimentoClaim = context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth);

        if (dataNascimentoClaim is null)
        {
            context.Fail();
            return Task.CompletedTask;
        }

        var dataNascimento = DateTime.Parse(dataNascimentoClaim.Value);

        var idade = DateTime.Today.Year - dataNascimento.Year;

        // Se a data de nascimento ainda não ocorreu este ano, subtrai um ano da idade
        if (dataNascimento > DateTime.Today.AddYears(-idade))
        {
            idade--;
        }

        if (idade >= requirement.Idade)
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }

        return Task.CompletedTask;
    }
}
