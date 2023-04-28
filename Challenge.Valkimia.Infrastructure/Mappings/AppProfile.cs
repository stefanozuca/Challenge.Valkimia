using AutoMapper;

namespace Challenge.Valkimia.Infrastructure.Mappings
{
    internal class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Domain.Entities.Cliente, Infrastructure.Models.Application.Cliente>();
            CreateMap<Infrastructure.Models.Application.Cliente, Domain.Entities.Cliente>();
            
            CreateMap<Domain.Entities.Ciudad, Infrastructure.Models.Application.Ciudad>();
            CreateMap<Infrastructure.Models.Application.Ciudad, Domain.Entities.Ciudad>();
            
            CreateMap<Domain.Entities.Factura, Infrastructure.Models.Application.Factura>();
            CreateMap<Infrastructure.Models.Application.Factura, Domain.Entities.Factura>();

        }
    }
}
