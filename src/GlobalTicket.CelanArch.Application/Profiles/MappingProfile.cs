using AutoMapper;
using GlobalTicket.CelanArch.Application.Features.Events;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GlobalTicket.CelanArch.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Event, EventListVm>().ReverseMap();
    }
}
