using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymApp;
using GymApp.Models;

namespace GymApp.Controllers
{
    public class BookingsController : Controller
    {
        private readonly GymDBContext _context;

        public BookingsController(GymDBContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var gymDBContext = _context.Bookings.Include(b => b.AdminStaff).Include(b => b.Class).Include(b => b.Member).Include(b => b.Room).Include(b => b.Session).Include(b => b.Trainer);
            return View(await gymDBContext.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.AdminStaff)
                .Include(b => b.Class)
                .Include(b => b.Member)
                .Include(b => b.Room)
                .Include(b => b.Session)
                .Include(b => b.Trainer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["AdminStaffId"] = new SelectList(_context.AdminStaffs, "Id", "Id");
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id");
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Email");
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id");
            ViewData["SessionId"] = new SelectList(_context.Sessions, "Id", "Id");
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "Id", "Id");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,Method,Date,IsClass,IsSession,StartTime,EndTime,MemberId,AdminStaffId,RoomId,SessionId,ClassId,TrainerId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminStaffId"] = new SelectList(_context.AdminStaffs, "Id", "Id", booking.AdminStaffId);
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", booking.ClassId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Email", booking.MemberId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id", booking.RoomId);
            ViewData["SessionId"] = new SelectList(_context.Sessions, "Id", "Id", booking.SessionId);
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "Id", "Id", booking.TrainerId);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["AdminStaffId"] = new SelectList(_context.AdminStaffs, "Id", "Id", booking.AdminStaffId);
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", booking.ClassId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Email", booking.MemberId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id", booking.RoomId);
            ViewData["SessionId"] = new SelectList(_context.Sessions, "Id", "Id", booking.SessionId);
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "Id", "Id", booking.TrainerId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,Method,Date,IsClass,IsSession,StartTime,EndTime,MemberId,AdminStaffId,RoomId,SessionId,ClassId,TrainerId")] Booking booking)
        {
            if (id != booking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminStaffId"] = new SelectList(_context.AdminStaffs, "Id", "Id", booking.AdminStaffId);
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", booking.ClassId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Email", booking.MemberId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id", booking.RoomId);
            ViewData["SessionId"] = new SelectList(_context.Sessions, "Id", "Id", booking.SessionId);
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "Id", "Id", booking.TrainerId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.AdminStaff)
                .Include(b => b.Class)
                .Include(b => b.Member)
                .Include(b => b.Room)
                .Include(b => b.Session)
                .Include(b => b.Trainer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }
    }
}
