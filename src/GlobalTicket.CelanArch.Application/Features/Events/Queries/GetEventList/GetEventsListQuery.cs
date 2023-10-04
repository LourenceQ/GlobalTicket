using MediatR;

namespace GlobalTicket.CelanArch.Application.Features.Events.Queries.GetEventList;

public class GetEventsListQuery : IRequest<List<EventListVm>>
{
}
