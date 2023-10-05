using MediatR;

namespace GlobalTicket.CelanArch.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
public class GetCategoriesListWithEventsQuery : IRequest<List<CategoryEventListVm>>
{
    public bool IncludeHistory { get; set; }
}
