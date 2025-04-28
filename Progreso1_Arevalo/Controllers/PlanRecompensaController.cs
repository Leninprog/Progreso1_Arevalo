using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Progreso1_Arevalo.Controllers
{
    public class PlanRecompensaController : Controller
    {
        // GET: PlanRecompensaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PlanRecompensaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlanRecompensaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlanRecompensaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlanRecompensaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlanRecompensaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlanRecompensaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlanRecompensaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
