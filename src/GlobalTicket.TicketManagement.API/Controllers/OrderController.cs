﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GlobalTicket.TicketManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
