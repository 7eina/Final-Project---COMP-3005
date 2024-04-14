using GymApp.Models;

namespace GymApp.ViewModels
{
    public class TrainerDashboardViewModel
    {
        public required Trainer TrainerInfo { get; set; }

        public IEnumerable<Availability> Availabilities { get; set; } = new List<Availability>();

        public IEnumerable<Member> Members { get; set; } = new List<Member>();

    }
}
