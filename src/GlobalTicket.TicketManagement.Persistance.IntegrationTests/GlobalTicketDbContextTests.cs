﻿using GlobalTicket.CelanArch.Application.Contracts;
using GlobalTicket.TicketManagement.Domain.Entities;
using GlobalTicket.TicketManagement.Persistence;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;

namespace GlobalTicket.TicketManagement.Persistance.IntegrationTests;
public class GlobalTicketDbContextTests
{
    private readonly GlobalTicketDbContext _globoTicketDbContext;
    private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
    private readonly string _loggedInUserId;

    public GlobalTicketDbContextTests()
    {
        var dbContextOptions = new DbContextOptionsBuilder<GlobalTicketDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        _loggedInUserId = "00000000-0000-0000-0000-000000000000";
        _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
        _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

        _globoTicketDbContext = new GlobalTicketDbContext(dbContextOptions
            , _loggedInUserServiceMock.Object);
    }

    [Fact]
    public async void Save_SetCreatedByProperty()
    {
        var ev = new Event() { EventId = Guid.NewGuid(), Name = "Test event" };

        _globoTicketDbContext.Events.Add(ev);
        await _globoTicketDbContext.SaveChangesAsync();

        ev.CreatedBy.ShouldBe(_loggedInUserId);
    }
}
