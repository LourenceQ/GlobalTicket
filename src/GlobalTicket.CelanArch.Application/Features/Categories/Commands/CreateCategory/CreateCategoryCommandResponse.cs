using GlobalTicket.TicketManagement.Application.Features.Categories.Commands.CreateCateogry;

namespace GlobalTicket.TicketManagement.Application.Responses;

public class CreateCategoryCommandResponse : BaseResponse
{
    public CreateCategoryCommandResponse() : base()
    {

    }

    public CreateCategoryDto Category { get; set; } = default!;
}