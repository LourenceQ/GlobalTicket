using AutoMapper;
using GlobalTicket.CelanArch.Application.Features.Events.Queries.GetEventDetail;
using GlobalTicket.CelanArch.Application.Features.Events.Queries.GetEventList;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GlobalTicket.CelanArch.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Event, EventListVm>().ReverseMap();
        CreateMap<Event, EventDetailVm>().ReverseMap();
        CreateMap<Category, CategoryDto>();
    }
}
