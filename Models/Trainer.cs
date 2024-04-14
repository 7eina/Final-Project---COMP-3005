using System;
using System.Collections.Generic;

namespace GymApp.Models;

public partial class Trainer
{
    public int Id { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public string? Address { get; set; }

    public string Phone { get; set; } = null!;

    public virtual ICollection<Availability> Availabilities { get; set; } = new List<Availability>();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
