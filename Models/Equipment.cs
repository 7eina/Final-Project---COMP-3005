using System;
using System.Collections.Generic;

namespace GymApp.Models;

public partial class Equipment
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly MaintenanceDuedate { get; set; }

    public DateOnly? LastMaintenanceDate { get; set; }

    public DateOnly PurchaseDate { get; set; }

    public string? MaintenanceInfo { get; set; }

    public int? RoomId { get; set; }

    public int? AdminStaffId { get; set; }

    public virtual AdminStaff? AdminStaff { get; set; }

    public virtual Room? Room { get; set; }
}
