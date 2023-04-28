using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Challenge.Valkimia.Presentation.Resources.Interfaces
{
    public interface IAuthorizationStateProvider
    {
        bool this[IAuthorizationRequirement requirement] { get; }

        Task<bool> Any(IAuthorizationRequirement[] requirements);

        Task Refresh();

        Task<bool> TryAddAndCheckRequirement(IAuthorizationRequirement requirement);
    }
}
