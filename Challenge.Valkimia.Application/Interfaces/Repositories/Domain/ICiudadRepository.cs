using Challenge.Valkimia.Domain.Entities;

namespace Challenge.Valkimia.Application
{
    public interface ICiudadRepository : IReadRepository<Ciudad>, IWriteRepository<Ciudad>
    {

    }
}
