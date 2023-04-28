using AutoMapper;
using Challenge.Valkimia.Application;
using Challenge.Valkimia.Common;
using Challenge.Valkimia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;

namespace Challenge.Valkimia.Infrastructure.Repositories;

public class ClienteRepository : EFRepository<Cliente, Infrastructure.Models.Application.Cliente,Guid> , IClienteRepository
{
    private readonly IMapper _mapper;
    private readonly ILogger<ClienteRepository> _logger;
    private readonly IEntityRepository<Infrastructure.Models.Application.Cliente, Guid> _repo;
    public ClienteRepository(
        IMapper mapper, 
        ILogger<ClienteRepository> logger,
        IEntityRepository<Infrastructure.Models.Application.Cliente,Guid> pesistenceRepo)
        : base(mapper, pesistenceRepo)
    {
        _mapper = mapper;
        _logger = logger;
        _repo = pesistenceRepo;
    }

    public async Task<Result<IList<Cliente>>> GetAllClientes(QueryOptions options = null) {
        var serviceResult = new Result<IList<Cliente>>();

        try {
            var query = _repo.GetAll().AsQueryable();

            if (!string.IsNullOrWhiteSpace(options?.SearchTerm)) {
                query = query.Where(c => EF.Functions.Like(c.Nombre, $"%{options.SearchTerm}%"));
            }

            if (!string.IsNullOrWhiteSpace(options?.OrderBy)) {
                query = query.OrderBy(options.OrderBy);
            }

            if (options?.Skip != null && options?.PageSize != null) {
                query = query.Skip(options.Skip);
                query = query.Take(options.PageSize);
            }

            serviceResult.Data = await _mapper.ProjectTo<Cliente>(query).ToListAsync();
            serviceResult.Successful();
        }
        catch (Exception ex) {
            ServicesHelper.HandleServiceError(ref serviceResult, _logger, ex, "Error tratando de obtener clientes.");
        }

        return serviceResult;
    }
}
