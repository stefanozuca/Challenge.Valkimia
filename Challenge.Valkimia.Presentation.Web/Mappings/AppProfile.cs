using AutoMapper;
using Challenge.Valkimia.Application.Commands;
using Challenge.Valkimia.Application.DTOs;
using Challenge.Valkimia.Application.ReadModels;
using Challenge.Valkimia.Domain.Entities;
using Challenge.Valkimia.Presentation.Web.ViewModels;

namespace Challenge.Valkimia.Presentation.Web.Mappings
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<LoginViewModel, LoginRequestDTO>();
            CreateMap<Cliente, ClienteReadModel>()
                .ForMember(target => target.NombreCiudad, source => source.MapFrom(x => x.IdCiudadNavigation.Nombre))
                .ForMember(target => target.CantidadFacturas, source => source.MapFrom(x => x.Facturas.Count));

            CreateMap<CreateClienteViewModel, CreateClienteCommand>();
        }
    }
}
