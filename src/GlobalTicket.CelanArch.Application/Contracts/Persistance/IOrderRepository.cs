﻿using GloboTicket.TicketManagement.Domain.Entities;

namespace GlobalTicket.CelanArch.Application.Contracts.Persistance;

public interface IOrderRepository : IAsyncRepository<Order>
{
}
