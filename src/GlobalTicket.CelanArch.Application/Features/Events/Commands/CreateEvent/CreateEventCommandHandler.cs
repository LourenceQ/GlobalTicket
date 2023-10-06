using AutoMapper;
using GlobalTicket.CelanArch.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GlobalTicket.CelanArch.Application.Features.Events.Commands.CreateEvent;
public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;


    public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository)
    {
        _mapper = mapper;
        _eventRepository = eventRepository;
    }

    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        /*var validator = new CreateEventCommandValidator(_eventRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
            throw new Exceptions.ValidationException(validationResult);*/

        var @event = _mapper.Map<Event>(request);


        @event = await _eventRepository.AddAsync(@event);

        return @event.EventId;
    }
}
