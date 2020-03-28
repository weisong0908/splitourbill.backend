using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace splitourbill_backend.Requirements
{
    public class HasPermissionHandler : AuthorizationHandler<HasPermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasPermissionRequirement requirement)
        {
            if (!context.User.HasClaim(claim => claim.Type == "permissions" && claim.Issuer == requirement.Issuer))
                return Task.CompletedTask;

            var scopes = context.User.FindAll(claim => claim.Type == "permissions" && claim.Issuer == requirement.Issuer);

            if (scopes.Any(s => s.Value == requirement.Permission))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}