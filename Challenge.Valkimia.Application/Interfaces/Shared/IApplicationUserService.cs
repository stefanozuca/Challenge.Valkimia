using Challenge.Valkimia.Application.DTOs;
using Challenge.Valkimia.Common;
using Challenge.Valkimia.Domain.Entities;

namespace Challenge.Valkimia.Application
{
    public interface IApplicationUserService
    {
        /// <summary>
        /// Creates a new user according to the provided <paramref name="user"/>
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="isActive"></param>
        /// <returns></returns>
        Task<Result> CreateUser(Cliente user, string password, List<string> roles, bool isActive);

        /// <summary>
        /// Activates the application user with username <paramref name="email"/>
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<Result> ActivateUser(string email);

        /// <summary>
        /// Deactivates the application user with username <paramref name="email"/>
        /// </summary>
        /// <returns></returns>
        Task<Result> DeactivateUser(string email);

        /// <summary>
        /// Retrieves all users
        /// </summary>
        /// <returns>list of <see cref="Cliente"/></returns>
        Task<Result<IList<Cliente>>> GetAllUsers(QueryOptions options);

        /// <summary>
        /// Get user
        /// </summary>
        /// <param name="id">the user ID</param>
        /// <returns> a <see cref="Cliente"/></returns>
        Task<Result<Cliente>> GetUser(Guid id);

        /// <summary>
        /// Changes a user's password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<Result> ChangePassword(string email, string password);

        Task<Result> UpdateUserDetails(UpdateUserDetailsDTO request);

        /// <summary>
        /// Adds a role to a user
        /// </summary>
        /// <param name="request">the role assignment request</param>
        /// <returns></returns>
        Task<Result> AddRoles(RoleAssignmentRequestDTO request);

        /// <summary>
        /// Removes a role from a user
        /// </summary>
        /// <param name="request">the role assignment request</param>
        /// <returns></returns>
        Task<Result> RemoveRoles(RoleAssignmentRequestDTO request);

        /// <summary>
        /// Updates a user's roles
        /// </summary>
        /// <param name="username">the username</param>
        /// <param name="roles">the list of new roles</param>
        /// <returns></returns>
        Task<Result> UpdateRoles(string username, List<string> roles);

    }
}
