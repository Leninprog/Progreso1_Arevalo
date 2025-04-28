using Microsoft.AspNetCore.Mvc;
using Progreso1_ArevaloLenin.Models;
using Microsoft.EntityFrameworkCore;
using Progreso1_Arevalo.Data;

namespace Progreso1_ArevaloLenin.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClienteController
        public ActionResult Index()
        {
            var clientes = _context.Clientes.Include(item => item.PlanRecompensa).ToList();
            return View("List", clientes);
        }

        // GET: ClienteController/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var cliente = _context.Clientes
                .Include(m => m.Reservas)
                .FirstOrDefault(m => m.Id == id);

            if (cliente == null) return NotFound();

            return View(cliente);
        }

        // GET: ClienteController/Create
        public IActionResult Create()
        {
            ViewBag.PlanesRecompensa = _context.PlanRecompensas.ToList();
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));  
            }

            ViewBag.PlanesRecompensa = _context.PlanRecompensas.ToList();
            return View(cliente);  
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null) return NotFound();

            var cliente = _context.Clientes.Find(id);
            if (cliente == null) return NotFound();

            ViewBag.PlanesRecompensa = _context.PlanRecompensas.ToList();
            return View(cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Cliente cliente)
        {
            if (id != cliente.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(cliente);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));  
            }

            ViewBag.PlanesRecompensa = _context.PlanRecompensas.ToList();
            return View(cliente);
        }

        // GET: ClienteController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var cliente = _context.Clientes
                .Include(m => m.Reservas)
                .FirstOrDefault(m => m.Id == id);

            if (cliente == null) return NotFound();

            return View(cliente);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null) return NotFound();
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));  
        }
    }
}

