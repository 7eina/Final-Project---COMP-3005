using System;
using System.Collections.Generic;

namespace GymApp.Models;

public partial class Availability
{
    public int Id { get; set; }

    public DateTime AvailableFrom { get; set; }

    public DateTime AvailableTo { get; set; }

    public int TrainerId { get; set; }

    public virtual Trainer Trainer { get; set; } = null!;
}
