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
    public class EquipmentsController : Controller
    {
        private readonly GymDBContext _context;

        public EquipmentsController(GymDBContext context)
        {
            _context = context;
        }

        // GET: Equipments
        public async Task<IActionResult> Index()
        {
            var gymDBContext = _context.Equipments.Include(e => e.AdminStaff).Include(e => e.Room);
            return View(await gymDBContext.ToListAsync());
        }

        // GET: Equipments/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipments
                .Include(e => e.AdminStaff)
                .Include(e => e.Room)
                .FirstOrDefaultAsync(m => m.Name == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // GET: Equipments/Create
        public IActionResult Create()
        {
            ViewData["AdminStaffId"] = new SelectList(_context.AdminStaffs, "Id", "Id");
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id");
            return View();
        }

        // POST: Equipments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,MaintenanceDuedate,LastMaintenanceDate,PurchaseDate,MaintenanceInfo,RoomId,AdminStaffId")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminStaffId"] = new SelectList(_context.AdminStaffs, "Id", "Id", equipment.AdminStaffId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id", equipment.RoomId);
            return View(equipment);
        }

        // GET: Equipments/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }
            ViewData["AdminStaffId"] = new SelectList(_context.AdminStaffs, "Id", "Id", equipment.AdminStaffId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id", equipment.RoomId);
            return View(equipment);
        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,MaintenanceDuedate,LastMaintenanceDate,PurchaseDate,MaintenanceInfo,RoomId,AdminStaffId")] Equipment equipment)
        {
            if (id != equipment.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentExists(equipment.Name))
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
            ViewData["AdminStaffId"] = new SelectList(_context.AdminStaffs, "Id", "Id", equipment.AdminStaffId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id", equipment.RoomId);
            return View(equipment);
        }

        // GET: Equipments/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipments
                .Include(e => e.AdminStaff)
                .Include(e => e.Room)
                .FirstOrDefaultAsync(m => m.Name == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment != null)
            {
                _context.Equipments.Remove(equipment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentExists(string id)
        {
            return _context.Equipments.Any(e => e.Name == id);
        }
    }
}
