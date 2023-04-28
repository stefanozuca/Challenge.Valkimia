using AutoMapper;
using Challenge.Valkimia.Common;
using Challenge.Valkimia.Common.Extensions;
using Challenge.Valkimia.Domain;
using Challenge.Valkimia.Domain.Entities;
using Challenge.Valkimia.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;

namespace Challenge.Valkimia.Infrastructure.Mappings
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUserRole, RolesEnum>()
                .ConvertUsing(r => r.Role.Name.ToEnum<RolesEnum>());

            CreateMap<Cliente, ApplicationUser>()
                .ForMember(target => target.Roles, opt => opt.Ignore());

            //CreateMap<ApplicationUser, User>()
            //    .ForMember(target => target.PrimaryPhoneNumber, source => source.MapFrom(m => m.PhoneNumber));

            //CreateMap<ApplicationUser, UserReadModel>();

            CreateMap<IdentityError, ResultError>()
                .ForMember(target => target.Error, opt => opt.MapFrom(source => source.Description));
        }
    }
}
