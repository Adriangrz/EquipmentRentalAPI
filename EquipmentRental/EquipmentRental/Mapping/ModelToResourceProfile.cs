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
            CreateMap<Category, SaveUpdateCategoryResource>();
            CreateMap<Rent, RentResource>();
            CreateMap<Rent, SaveRentResource>();
            CreateMap<Rent, UpdateRentResource>();
            CreateMap<SportEquipment, SportEquipmentResource>();
            CreateMap<SportEquipment, SaveUpdateSportEquipmentResource>();
            CreateMap<User, UserResource>();
            CreateMap<User, SaveUpdateUserResource>();
            CreateMap<User, ReturnedUserResource>();
        }
    }
}
