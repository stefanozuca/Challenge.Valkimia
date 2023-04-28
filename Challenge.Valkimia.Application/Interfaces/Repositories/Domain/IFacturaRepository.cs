using Challenge.Valkimia.Domain.Entities;

namespace Challenge.Valkimia.Application
{
    public interface IFacturaRepository : IReadRepository<Factura>, IWriteRepository<Factura>
    {
    }
}
