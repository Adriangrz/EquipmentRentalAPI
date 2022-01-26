using AutoMapper;
using EquipmentRental.Models;
using EquipmentRental.Models.ApiModels;

namespace EquipmentRental.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<CategoryResource, Category>();
            CreateMap<SaveUpdateCategoryResource, Category>();
            CreateMap<RentResource, Rent>();
            CreateMap<SaveRentResource, Rent>();
            CreateMap<UpdateRentResource, Rent>();
            CreateMap<SportEquipmentResource, SportEquipment>();
            CreateMap<SaveUpdateSportEquipmentResource, SportEquipment>();
            CreateMap<UserResource, User>();
            CreateMap<SaveUpdateUserResource, User>();
            CreateMap<AuthUserResource, User>();
        }
    }
}
