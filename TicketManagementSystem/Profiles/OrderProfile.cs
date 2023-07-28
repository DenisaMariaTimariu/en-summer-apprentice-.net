using AutoMapper;
using TicketManagementSystem.Models.DTO;
using TicketManagementSystem.Models;

namespace TicketManagementSystem.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile() {

            CreateMap<Order, OrderPatchDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
