using AutoMapper;
using Resturant.Management.System.APIs.DTOs;
using Resturant.Management.System.Core.Entites;

namespace Resturant.Management.System.APIs.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<MenueItem , MenueItemDto>().ReverseMap();
            CreateMap<Menue , MenueDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Sales, SalesDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();

        }
    }
}
