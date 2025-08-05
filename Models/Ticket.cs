using System;
using System.Collections.Generic;

namespace DBFirstDay2.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int PassengerId { get; set; }

    public string TicketNumber { get; set; } = null!;

    public DateTime JourneyDate { get; set; }

    public decimal Price { get; set; }

    public virtual Passenger Passenger { get; set; } = null!;
}
