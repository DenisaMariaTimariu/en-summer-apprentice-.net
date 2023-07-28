using AutoMapper;
using TicketManagementSystem.Models;
using TicketManagementSystem.Models.DTO;

namespace TicketManagementSystem.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile() {
            

            CreateMap<Event, EventDto>().ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location != null ? src.Location.LocationName : null))

                 .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType != null ? src.EventType.EventTypeName : null));



            CreateMap<EventDto, Event>()

              .ForMember(dest => dest.Location, opt => opt.Ignore())

              .ForMember(dest => dest.EventType, opt => opt.Ignore());

            CreateMap<Event, EventPatchDto>().ReverseMap();
        }
    }
}

