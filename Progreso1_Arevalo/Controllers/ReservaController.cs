using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Progreso1_Arevalo.Data;
using Progreso1_ArevaloLenin.Models;

namespace Progreso1_Arevalo.Controllers
{
    public class ReservaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reserva
        public IActionResult Index()
        {
            var reservas = _context.Reservas.Include(r => r.Cliente).ToList();
            return View(reservas);
        }

        // GET: Reserva/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var reserva = _context.Reservas
                .Include(r => r.Cliente)
                .FirstOrDefault(r => r.Id == id);

            if (reserva == null) return NotFound();

            return View(reserva);
        }

        // GET: Reserva/Create
        public IActionResult Create()
        {
            ViewBag.Clientes = _context.Clientes.ToList(); // Para seleccionar el cliente
            return View();
        }

        // POST: Reserva/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                reserva.FechaReserva = DateTime.Now;
                _context.Reservas.Add(reserva);

                // Obtener cliente y su plan de recompensa
                var cliente = _context.Clientes
                    .Include(c => c.PlanRecompensa)
                    .FirstOrDefault(c => c.Id == reserva.ClienteId);

                if (cliente != null && cliente.PlanRecompensa != null)
                {
                    // Sumar puntos
                    cliente.PlanRecompensa.PuntosAcumulados += 100;

                    // Tipo de recompensa: false = Silver, true = Gold
                    cliente.PlanRecompensa.TipoRecompensa = cliente.PlanRecompensa.PuntosAcumulados >= 500;
                }

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Clientes = _context.Clientes.ToList();
            return View(reserva);
        }

        // GET: Reserva/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var reserva = _context.Reservas.Find(id);
            if (reserva == null) return NotFound();

            ViewBag.Clientes = _context.Clientes.ToList();
            return View(reserva);
        }

        // POST: Reserva/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Reserva reserva)
        {
            if (id != reserva.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(reserva);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Clientes = _context.Clientes.ToList();
            return View(reserva);
        }

        // GET: Reserva/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var reserva = _context.Reservas
                .Include(r => r.Cliente)
                .FirstOrDefault(r => r.Id == id);

            if (reserva == null) return NotFound();

            return View(reserva);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var reserva = _context.Reservas.Find(id);
            _context.Reservas.Remove(reserva);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
