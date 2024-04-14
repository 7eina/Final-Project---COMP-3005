using System;
using System.Collections.Generic;

namespace GymApp.Models;

public partial class Session
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? DifficultyLevel { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
