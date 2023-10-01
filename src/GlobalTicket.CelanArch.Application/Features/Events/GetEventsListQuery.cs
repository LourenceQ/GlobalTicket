using MediatR;

namespace GlobalTicket.CelanArch.Application.Features.Events;

public class GetEventsListQuery : IRequest<List<EventListVm>>
{
}
