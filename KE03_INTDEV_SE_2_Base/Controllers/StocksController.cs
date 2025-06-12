using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace KE03_INTDEV_SE_2_Base.Controllers
{
    public class StocksController : Controller
    {
        private readonly MatrixIncDbContext _context;

        public StocksController(MatrixIncDbContext context)
        {
            _context = context;
        }

        // GET: StocksController
        public ActionResult Index()
        {
            var allStocks = _context.Parts.ToList();
            return View(allStocks);
        }

        // GET: StocksController/Edit/5 (Order Stock)
        public ActionResult Edit(int id)
        {
            var part = _context.Parts.FirstOrDefault(p => p.Id == id);
            if (part == null)
            {
                return NotFound();
            }

            return View(part); // Zorgt dat je @model in de View niet null is
        }

        // POST: StocksController/Edit/5 (Order Stock)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, int amountToAdd)
        {
            var part = _context.Parts.FirstOrDefault(p => p.Id == id);
            if (part == null)
            {
                return NotFound();
            }

            part.Stock += amountToAdd;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // Andere acties (optioneel)
        public ActionResult Details(int id)
        {
            var part = _context.Parts.FirstOrDefault(p => p.Id == id);
            if (part == null)
            {
                return NotFound();
            }

            return View(part);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Part newPart)
        {
            if (ModelState.IsValid)
            {
                _context.Parts.Add(newPart);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(newPart);
        }

        public ActionResult Delete(int id)
        {
            var part = _context.Parts.FirstOrDefault(p => p.Id == id);
            if (part == null)
            {
                return NotFound();
            }

            return View(part);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var part = _context.Parts.FirstOrDefault(p => p.Id == id);
            if (part != null)
            {
                _context.Parts.Remove(part);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

