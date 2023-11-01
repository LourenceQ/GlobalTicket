using GlobalTicket.TicketManagement.Domain.Entities;

namespace GlobalTicket.CelanArch.Application.Contracts.Persistance;

public interface ICategoryRepository : IAsyncRepository<Category>
{
    Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents);
}
