﻿using GlobalTicket.TicketManagement.Application.Responses;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Categories.Commands.CreateCateogry;

public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
{
    public string Name { get; set; } = string.Empty;
}
