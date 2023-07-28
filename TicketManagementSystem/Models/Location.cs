using System;
using System.Collections.Generic;

namespace TicketManagementSystem.Models;

public partial class Location
{
    public int LocationId { get; set; }

    public string? LocationName { get; set; }

    public int? Capacity { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
