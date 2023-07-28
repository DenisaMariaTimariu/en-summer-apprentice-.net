namespace TicketManagementSystem.Models.DTO
{
    public class EventDto
    {
        public int EventId { get; set; }
        public string Name { get; set; }

        public string EventDescription { get; set; }

        public string EventType { get; set; }

        public string Location { get; set; } 
    }
}
