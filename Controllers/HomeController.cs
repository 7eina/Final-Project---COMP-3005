using GymApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Diagnostics;

namespace GymApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly GymDBContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, GymDBContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Member()
        {
            // Redirect to the All Member's landing page
            return RedirectToAction("Index", "Members");
        }
        public IActionResult NewMember()
        {
            // Redirect to new member registration landing page
            return RedirectToAction("Create", "Members");
        }

        [HttpPost]
        public async Task<IActionResult> FindMember(string email)
        {
            // Assuming you have a database context
            var member = await _context.Members.FirstOrDefaultAsync(m => m.Email == email);
            if (member != null)
            {
                // Redirect to the member's Dashboard page
                return RedirectToAction("Dashboard", "Members", new { id = member.Id });
            }
            else
            {
                // If the member does not exist go back to the index with an error message
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> FindTrainer(int trainerid)
        {
            var trainer= await _context.Trainers.FirstOrDefaultAsync(m => m.Id == trainerid);
            if (trainer != null)
            {
                // Redirect to the Trainer's Dashboard page
                return RedirectToAction("Dashboard", "Trainers", new { id = trainerid });
            }
            else
            {
                // If the trainer does not exist go back to the index with an error message
                return RedirectToAction("Index");
            }
        }
        public IActionResult Trainer()
        {
            // Redirect to the Trainer's landing page
            return RedirectToAction("Index", "Trainers");
        }

        public IActionResult AdminStaff()
        {
            // Redirect to the Admin Staff's landing page
            return RedirectToAction("Index", "AdminStaff");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
