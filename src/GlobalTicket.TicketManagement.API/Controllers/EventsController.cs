﻿using GlobalTicket.CelanArch.Application.Features.Events.Commands.CreateEvent;
using GlobalTicket.CelanArch.Application.Features.Events.Commands.DeleteEvent;
using GlobalTicket.CelanArch.Application.Features.Events.Commands.UpdateEvent;
using GlobalTicket.CelanArch.Application.Features.Events.Queries.GetEventDetail;
using GlobalTicket.CelanArch.Application.Features.Events.Queries.GetEventList;
using GlobalTicket.CelanArch.Application.Features.Events.Queries.GetEventsExport;
using GlobalTicket.TicketManagement.API.Utility;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GlobalTicket.TicketManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : Controller
{
    private readonly IMediator _mediator;

    public EventsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetAllEvents")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<EventListVm>>> GetAllEvents()
    {
        var dtos = await _mediator.Send(new GetEventsListQuery());
        return Ok(dtos);
    }

    [HttpGet("{id}", Name = "GetEventById")]
    public async Task<ActionResult<EventDetailVm>> GetEventById(Guid id)
    {
        var getEventDetailQuery = new GetEventDetailQuery() { Id = id };
        return Ok(await _mediator.Send(getEventDetailQuery));
    }

    [HttpPost(Name = "AddEvent")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateEventCommand createEventCommand)
    {
        var id = await _mediator.Send(createEventCommand);
        return Ok(id);
    }

    [HttpPut(Name = "UpdateEvent")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update([FromBody] UpdateEventCommand updateEventCommand)
    {
        await _mediator.Send(updateEventCommand);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteEvent")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
        var deleteEventCommand = new DeleteEventCommand() { EventId = id };
        await _mediator.Send(deleteEventCommand);
        return NoContent();
    }

    [HttpGet("export", Name = "ExportEvents")]
    [FileResultContentType("text/csv")]
    public async Task<FileResult> ExportEvents()
    {
        var fileDto = await _mediator.Send(new GetEventsExportQuery());

        return File(fileDto.Data, fileDto.ContentType, fileDto.EventExportFileName);
    }
}
