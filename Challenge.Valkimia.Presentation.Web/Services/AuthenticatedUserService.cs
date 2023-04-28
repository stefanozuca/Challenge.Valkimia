using Challenge.Valkimia.Application;
using Challenge.Valkimia.Infrastructure.Models.Application;
using System.Security.Claims;

namespace Challenge.Valkimia.Presentation.Web.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? null;
            Username = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value ?? null;
            Name = httpContextAccessor.HttpContext?.User?.FindFirst(Cliente.FullNameClaimType)?.Value ?? null;
        }

        public string UserId { get; }

        public string Username { get; }
        public string Name { get; }
    }
}
