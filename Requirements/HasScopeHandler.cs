using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace splitourbill_backend.Requirements
{
    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopeRequirement requirement)
        {
            if (!context.User.HasClaim(claim => claim.Type == "permissions" && claim.Issuer == requirement.Issuer))
                return Task.CompletedTask;

            var scopes = context.User.FindFirst(claim => claim.Type == "permissions" && claim.Issuer == requirement.Issuer).Value.Split(' ');

            if (scopes.Any(s => s == requirement.Scope))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}