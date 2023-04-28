using Challenge.Valkimia.Application.DTOs;
using Challenge.Valkimia.Common;

namespace Challenge.Valkimia.Application
{
    public interface IUserAuthenticationService
    {
        Task<Result<string>> Login(LoginRequestDTO loginRequest);
        Task<Result> Logout();
    }
}
