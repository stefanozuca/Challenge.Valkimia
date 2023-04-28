using Challenge.Valkimia.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Valkimia.Application.Queries
{
    public class GetAllCiudadesQuery : IRequest<IEnumerable<Ciudad>>
    {
        public class GetAllCiudadesQueryHandler : IRequestHandler<GetAllCiudadesQuery, IEnumerable<Ciudad>>
        {
            ICiudadRepository _ciudadRepository;
            public GetAllCiudadesQueryHandler(ICiudadRepository ciudadRepository){
                _ciudadRepository = ciudadRepository;
            }

            public async Task<IEnumerable<Ciudad>> Handle(GetAllCiudadesQuery request, CancellationToken cancellationToken)
            {
                return await _ciudadRepository.GetAll().ToListAsync();
            }
        }

    }
}
