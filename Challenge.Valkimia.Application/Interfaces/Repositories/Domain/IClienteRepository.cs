using Challenge.Valkimia.Common;
using Challenge.Valkimia.Domain.Entities;

namespace Challenge.Valkimia.Application
{
    public interface IClienteRepository : IReadRepository<Cliente>, IWriteRepository<Cliente>
    {
        /// <summary>
        /// Retrieves all clientes
        /// </summary>
        /// <returns>list of <see cref="User"/></returns>
        Task<Result<IList<Cliente>>> GetAllClientes(QueryOptions options);
    }
}
