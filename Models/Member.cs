using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymApp.Models;

public partial class Member
{
    public int Id { get; set; }
    [Required]
    public string Fname { get; set; } = null!;

    [Required]
    public string Lname { get; set; } = null!;
    
    [EmailAddress]
    [Required]
    public string Email { get; set; } = null!;

    public string? Address { get; set; }

    public string Phone { get; set; } = null!;

    public DateTime? WeightGoalStartDate { get; set; }

    public DateTime? WeightGoalEndDate { get; set; }

    public decimal? WeightGoalStartKg { get; set; }

    public decimal? WeightGoalEndKg { get; set; }

    public decimal? HeightCm { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<HealthMetric> HealthMetrics { get; set; } = new List<HealthMetric>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
