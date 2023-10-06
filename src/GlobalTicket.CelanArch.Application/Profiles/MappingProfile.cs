﻿using AutoMapper;
using GlobalTicket.CelanArch.Application.Features.Categories.Queries.GetCategoriesList;
using GlobalTicket.CelanArch.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using GlobalTicket.CelanArch.Application.Features.Events.Commands.CreateEvent;
using GlobalTicket.CelanArch.Application.Features.Events.Commands.DeleteEvent;
using GlobalTicket.CelanArch.Application.Features.Events.Commands.UpdateEvent;
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
        CreateMap<Category, CategoryListVm>();
        CreateMap<Category, CategoryEventListVm>();

        CreateMap<Event, CreateEventCommand>().ReverseMap();
        CreateMap<Event, UpdateEventCommand>().ReverseMap();
        CreateMap<Event, DeleteEventCommand>().ReverseMap();
    }
}