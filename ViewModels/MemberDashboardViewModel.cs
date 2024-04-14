using GymApp.Models;

namespace GymApp.ViewModels
{
    public class MemberDashboardViewModel
    {
        public required Member MemberInfo { get; set; }

        public  IEnumerable<Booking> ClassBookings { get; set; } = new List<Booking>();

        public  IEnumerable<Booking> SessionBookings { get; set; } = new List<Booking>();

        public  IEnumerable<HealthMetric> HealthMetrics { get; set; } = new List<HealthMetric>();

        public  IEnumerable<Payment> Payments { get; set; } = new List<Payment>();
    }
}

