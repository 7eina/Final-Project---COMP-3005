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
    public class HealthMetricsController : Controller
    {
        private readonly GymDBContext _context;

        public HealthMetricsController(GymDBContext context)
        {
            _context = context;
        }

        // GET: HealthMetrics
        public async Task<IActionResult> Index(int? member_id)
        {
            var gymDBContext = _context.HealthMetrics.Where(hm => hm.MemberId == member_id).Include(h => h.Member);
            return View(await gymDBContext.ToListAsync());
        }

        // GET: HealthMetrics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthMetric = await _context.HealthMetrics
                .Include(h => h.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthMetric == null)
            {
                return NotFound();
            }

            return View(healthMetric);
        }

        // GET: HealthMetrics/Create
        public IActionResult Create()
        {
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Email");
            return View();
        }

        // POST: HealthMetrics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HeartRate,BloodPressUp,BloodPressDown,CholesterolLevel,WeightKg,Date,MemberId")] HealthMetric healthMetric)
        {
            if (ModelState.IsValid)
            {
                _context.Add(healthMetric);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Email", healthMetric.MemberId);
            return View(healthMetric);
        }

        // GET: HealthMetrics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthMetric = await _context.HealthMetrics.FindAsync(id);
            if (healthMetric == null)
            {
                return NotFound();
            }
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Email", healthMetric.MemberId);
            return View(healthMetric);
        }

        // POST: HealthMetrics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HeartRate,BloodPressUp,BloodPressDown,CholesterolLevel,WeightKg,Date,MemberId")] HealthMetric healthMetric)
        {
            if (id != healthMetric.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(healthMetric);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HealthMetricExists(healthMetric.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Dashboard", "Members", new { id = healthMetric.MemberId });

            }
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Email", healthMetric.MemberId);
            return RedirectToAction("Dashboard", "Members", new { id = healthMetric.MemberId });

            //return View(healthMetric);
        }

        // GET: HealthMetrics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthMetric = await _context.HealthMetrics
                .Include(h => h.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthMetric == null)
            {
                return NotFound();
            }

            return View(healthMetric);
        }

        // POST: HealthMetrics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var healthMetric = await _context.HealthMetrics.FindAsync(id);
            if (healthMetric != null)
            {
                _context.HealthMetrics.Remove(healthMetric);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Dashboard", "Members", new { id = healthMetric.MemberId });
        }

        private bool HealthMetricExists(int id)
        {
            return _context.HealthMetrics.Any(e => e.Id == id);
        }
    }
}
