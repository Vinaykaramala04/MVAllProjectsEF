using System;
using System.Collections.Generic;

namespace DBFirstDay2.Models;

public partial class Passenger
{
    public int PassengerId { get; set; }

    public string? PassengerName { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
