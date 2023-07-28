﻿using TicketManagementSystem.Models;
//using TMS.Api.Models;

namespace TMS.Api.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();

        Task<Event> GetById(int id);

        int Add(Event @event);

        void Update(Event @event);

        Event Delete(Event @event);
    }
}
