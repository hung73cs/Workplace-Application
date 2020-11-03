using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using System.Data;

namespace Entities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects     
            CreateMap<User, UserVM>().ReverseMap();
            CreateMap<Permission, PermissionVM>().ReverseMap();
            CreateMap<Department, DepartmentVM>().ReverseMap();
            CreateMap<Location, LocationVM>().ReverseMap();
            CreateMap<Reservation, ReservationVM>().ReverseMap();
        }
    }
}
