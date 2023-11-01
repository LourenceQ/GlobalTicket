using AutoMapper;
using GlobalTicket.CelanArch.Application.Contracts.Infrastructure;
using GlobalTicket.CelanArch.Application.Contracts.Persistance;
using GlobalTicket.CelanArch.Application.Models.Mail;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GlobalTicket.CelanArch.Application.Features.Events.Commands.CreateEvent;
public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;

    public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository, IEmailService emailService)
    {
        _mapper = mapper;
        _eventRepository = eventRepository;
        _emailService = emailService;
    }

    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var @event = _mapper.Map<Event>(request);

        var validator = new CreateEventCommandValidator(_eventRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
            throw new GlobalTicket.TicketManagement.Application.Exceptions.ValidationException(validationResult);

        var email = new Email()
        {
            To = "teste@teste.com",
            Body = $"A new event was created: {request}",
            Subject = "A New event was created"
        };

        try
        {
            await _emailService.SendEmail(email);
        }
        catch (Exception ex)
        {
            // logging
        }

        @event = await _eventRepository.AddAsync(@event);

        return @event.EventId;
    }
}
