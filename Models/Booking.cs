using System;
using System.Collections.Generic;

namespace GymApp.Models;

public partial class Booking
{
    public int Id { get; set; }

    public decimal? Amount { get; set; }

    public string? Method { get; set; }

    public DateTime? Date { get; set; }

    public bool? IsClass { get; set; }

    public bool? IsSession { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? MemberId { get; set; }

    public int? AdminStaffId { get; set; }

    public int? RoomId { get; set; }

    public int? SessionId { get; set; }

    public int? ClassId { get; set; }

    public int? TrainerId { get; set; }

    public virtual AdminStaff? AdminStaff { get; set; }

    public virtual Class? Class { get; set; }

    public virtual Member? Member { get; set; }

    public virtual Room? Room { get; set; }

    public virtual Session? Session { get; set; }

    public virtual Trainer? Trainer { get; set; }
}
