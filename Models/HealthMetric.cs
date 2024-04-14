using System;
using System.Collections.Generic;

namespace GymApp.Models;

public partial class HealthMetric
{
    public int Id { get; set; }

    public decimal? HeartRate { get; set; }

    public decimal? BloodPressUp { get; set; }

    public decimal? BloodPressDown { get; set; }

    public decimal? CholesterolLevel { get; set; }

    public decimal? WeightKg { get; set; }

    public DateTime? Date { get; set; }

    public int? MemberId { get; set; }

    public virtual Member? Member { get; set; }
}
