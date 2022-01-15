using AutoMapper;
using EquipmentRental.Models;
using EquipmentRental.Models.ApiModels;

namespace EquipmentRental.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Rent, RentResource>();
            CreateMap<SportEquipment, SportEquipmentResource>();
            CreateMap<User, UserResource>();
        }
    }
}
