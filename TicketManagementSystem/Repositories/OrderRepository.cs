using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Models;

namespace TicketManagementSystem.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TicketDbContext _dbContext;


        public OrderRepository() {
            _dbContext = new TicketDbContext();
        }


        public IEnumerable<Order> GetAll()
        {
            var order = _dbContext.Orders;

            return order;
        }

        public async Task< Order> GetById(int id)
        {
            var @order = await _dbContext.Orders.Where(o => o.OrderId == id).FirstOrDefaultAsync();

            return @order;
        }

        public Order Delete(Order @order)
        {
            _dbContext.Remove(@order);
            _dbContext.SaveChanges();
            return @order;
        }

        public void Update(Order @order)
        {
            
            _dbContext.Entry(@order).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
