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
            CreateMap<RentResource, Rent>();
            CreateMap<SportEquipmentResource, SportEquipment>();
            CreateMap<UserResource, User>();
        }
    }
}
