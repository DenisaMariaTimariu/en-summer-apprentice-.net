using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

        public int Add(Event @event)
        {
            throw new NotImplementedException();
        }

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
                throw new Exception("The object was not found!");
            }

            return @event;
        }

        public void Update(Event @event)
        {
            //var eventEntity = GetById(@event.EventId);
            //eventEntity = @event;
            _dbContext.Entry(@event).State=EntityState.Modified;
           _dbContext.SaveChanges();
        }
    }
}