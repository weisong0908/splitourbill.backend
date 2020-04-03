using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;

namespace splitourbill_backend.Filters
{
    public class ObtainUserIdAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = context.HttpContext.User.Claims.SingleOrDefault(c => c.Type == "http://localhost:8080/application_user_id").Value;

            context.HttpContext.User.AddIdentity(new ClaimsIdentity(new List<Claim>() { new Claim("user_id", userId) }));
        }
    }
}