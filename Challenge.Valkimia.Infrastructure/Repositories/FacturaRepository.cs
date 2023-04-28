using AutoMapper;
using Challenge.Valkimia.Application;
using Challenge.Valkimia.Domain.Entities;

namespace Challenge.Valkimia.Infrastructure.Repositories
{
    public class FacturaRepository : EFRepository<Factura,Infrastructure.Models.Application.Factura,Guid> , IFacturaRepository
    {
        public FacturaRepository(IMapper mapper, IEntityRepository<Infrastructure.Models.Application.Factura,Guid> entityRepository)
            : base(mapper, entityRepository)
        {

        }
    }
}
