namespace TicketManagementSystem.Models.DTO
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int TicketCategoryId { get; set; }
        public DateTime OrderedAt { get; set; }
        public int NumberOfTickets { get; set; }
        public float totalPrice { get; set; }
    }
}
