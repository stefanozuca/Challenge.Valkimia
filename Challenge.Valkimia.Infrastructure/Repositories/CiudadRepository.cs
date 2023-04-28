using AutoMapper;
using Challenge.Valkimia.Application;
using Challenge.Valkimia.Domain.Entities;

namespace Challenge.Valkimia.Infrastructure.Repositories
{
    public class CiudadRepository : EFRepository<Ciudad, Infrastructure.Models.Application.Ciudad, Guid> , ICiudadRepository
    {
        public CiudadRepository(IMapper mapper,
            IEntityRepository<Infrastructure.Models.Application.Ciudad, Guid> pesistenceRepo)
            : base(mapper, pesistenceRepo)
        {

        }
    }
}
