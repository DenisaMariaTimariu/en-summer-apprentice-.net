using TicketManagementSystem.Models;

namespace TicketManagementSystem.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();

        Task<Order> GetById(int id);

        void Update(Order @order);

        Order Delete(Order @order);
    }
}
