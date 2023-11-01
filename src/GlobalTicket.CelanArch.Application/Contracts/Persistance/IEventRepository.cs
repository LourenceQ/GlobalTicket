using GlobalTicket.TicketManagement.Domain.Entities;

namespace GlobalTicket.CelanArch.Application.Contracts.Persistance;

public interface IEventRepository : IAsyncRepository<Event>
{
    Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate);
}
