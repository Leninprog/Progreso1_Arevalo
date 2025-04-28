using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Progreso1_Arevalo.Data;
using Progreso1_ArevaloLenin.Models;

namespace Progreso1_Arevalo.Controllers
{
    public class PlanRecompensaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlanRecompensaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlanRecompensa
        public IActionResult Index()
        {
            return View(_context.PlanRecompensas.ToList());
        }

        // GET: PlanRecompensa/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var plan = _context.PlanRecompensas.FirstOrDefault(p => p.Id == id);
            if (plan == null) return NotFound();

            return View(plan);
        }

        // GET: PlanRecompensa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlanRecompensa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PlanRecompensa plan)
        {
            if (ModelState.IsValid)
            {
                _context.PlanRecompensas.Add(plan);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(plan);
        }

        // GET: PlanRecompensa/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var plan = _context.PlanRecompensas.Find(id);
            if (plan == null) return NotFound();

            return View(plan);
        }

        // POST: PlanRecompensa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PlanRecompensa plan)
        {
            if (id != plan.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(plan);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(plan);
        }

        // GET: PlanRecompensa/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var plan = _context.PlanRecompensas.FirstOrDefault(p => p.Id == id);
            if (plan == null) return NotFound();

            return View(plan);
        }

        // POST: PlanRecompensa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var plan = _context.PlanRecompensas.Find(id);
            _context.PlanRecompensas.Remove(plan);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
