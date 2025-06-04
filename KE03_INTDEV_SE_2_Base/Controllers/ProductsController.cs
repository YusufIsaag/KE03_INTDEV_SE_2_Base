using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer;
using DataAccessLayer.Models;

namespace KE03_INTDEV_SE_2_Base.Controllers
{

    public class ProductsController : Controller
    {
        private readonly MatrixIncDbContext _context;

        public ProductsController(MatrixIncDbContext context)
        {
            _context = context;
        }
        // GET: ProductsController
        public async Task<IActionResult> Index()
        {
            var allProducts = _context.Products.ToList();
            return View(allProducts);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            var product = _context.Products
                .FirstOrDefault(product => product.Id == id);
            return View(product);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,Price,Image,Visible")]Product product)
        {
            if(ModelState.IsValid)
            {
             _context.Products.Add(product);
             _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
                return View(product);
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var product = _context.Products
                .FirstOrDefault(product => product.Id == id);
            
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, string Name, string Description, decimal Price, string Image, bool Visible)
        {
            if(ModelState.IsValid)
            {
                var product = _context.Products
                    .FirstOrDefault(product => product.Id == Id);
                
                if(product != null)
                {
                    product.Name = Name;
                    product.Description = Description;
                    product.Price = Price;
                    product.Image = Image;
                    product.Visible = Visible;
                    _context.Products.Update(product);
                    _context.SaveChanges();
                }
                else
                {
                    return NotFound();

                }
            }
                return RedirectToAction(nameof(Index));
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _context.Products
                .FirstOrDefault(product => product.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var product = _context.Products
                .FirstOrDefault(product => product.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
