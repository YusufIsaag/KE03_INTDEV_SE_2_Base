using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KE03_INTDEV_SE_2_Base.Controllers
{
    public class Dashboard2Controller : Controller
    {
        private readonly MatrixIncDbContext _context;

        public Dashboard2Controller(MatrixIncDbContext context)
        {
            _context = context;
        }
        // GET: Dashboard2Controller
        public ActionResult Index()
        {
            var model = new Dashboard2
            {
                TotalCustomers = _context.Customers.Count(),
                TotalProducts = _context.Products.Count()
            };

            return View(model);
        }

        // GET: Dashboard2Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dashboard2Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dashboard2Controller/Create
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

        // GET: Dashboard2Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dashboard2Controller/Edit/5
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

        // GET: Dashboard2Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dashboard2Controller/Delete/5
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
