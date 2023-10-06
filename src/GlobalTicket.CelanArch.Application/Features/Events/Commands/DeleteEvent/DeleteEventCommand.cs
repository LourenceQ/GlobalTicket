using MediatR;

namespace GlobalTicket.CelanArch.Application.Features.Events.Commands.DeleteEvent;
public class DeleteEventCommand : IRequest
{
    public Guid EventId { get; set; }
}
