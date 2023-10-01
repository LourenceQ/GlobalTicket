using AutoMapper;
using GlobalTicket.CelanArch.Application.Contracts.Persistance;
using MediatR;

namespace GlobalTicket.CelanArch.Application.Features.Events;

public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventListVm>>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<EventListVm> _eventsRepository;

    public GetEventsListQueryHandler(IMapper mapper, IAsyncRepository<EventListVm> eventsRepository)
    {
        _mapper = mapper;
        _eventsRepository = eventsRepository;
    }


    public async Task<List<EventListVm>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
    {
        var allEvents = (await _eventsRepository.ListAllAsync()).OrderBy(x => x.Date);

        return _mapper.Map<List<EventListVm>>(allEvents);
    }
}
