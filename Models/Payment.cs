using System;
using System.Collections.Generic;

namespace GymApp.Models;

public partial class Payment
{
    public int Id { get; set; }

    public string? ServiceType { get; set; }

    public decimal? Amount { get; set; }

    public string? PayMethod { get; set; }

    public DateTime? Date { get; set; }

    public int? MemberId { get; set; }

    public int? AdminStaffId { get; set; }

    public virtual AdminStaff? AdminStaff { get; set; }

    public virtual Member? Member { get; set; }
}
