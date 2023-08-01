using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TicketManagementSystem.Exceptions;
using TicketManagementSystem.Models;
//using TicketManagementSystem.Repositories;
//using TMS.Api.Models;

namespace TMS.Api.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly TicketDbContext _dbContext;

        public EventRepository()
        {
            _dbContext = new TicketDbContext();
        }

       /* public async Task<Event> Add(Event @event)
        {
            _dbContext.Events.Add(@event);
            await _dbContext.SaveChangesAsync();
            return @event;
        }*/

        public Event Delete(Event @event)
        {
            _dbContext.Remove(@event);
            _dbContext.SaveChanges();
            return @event;
        }

        public IEnumerable<Event> GetAll()
        {
            var events = _dbContext.Events.Include(e=>e.Location).Include(e=>e.EventType);

            return events;
        }

        public async Task<Event> GetById(int id)
        {
            var @event =await _dbContext.Events.Include(e => e.Location).Include(e => e.EventType).Where(e => e.EventId == id).FirstOrDefaultAsync();
            if(@event == null)
            {
                throw new EntityNotFoundException(id, nameof(Event));
            }

            return @event;
        }

        public void Update(Event @event)
        {
            _dbContext.Entry(@event).State=EntityState.Modified;
           _dbContext.SaveChanges();
        }
    }
}