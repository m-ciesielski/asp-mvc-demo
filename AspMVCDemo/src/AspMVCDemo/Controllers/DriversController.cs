using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using AspMVCDemo.Models;
using System.Collections.Generic;
using System;

namespace AspMVCDemo.Controllers
{
    public class DriversController : Controller
    {
        private ApplicationDbContext _context;

        public DriversController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Drivers
        public IActionResult Index(string searchString)
        {
            var drivers = from d in _context.Driver select d;

            if (!string.IsNullOrEmpty(searchString))
                drivers = drivers.Where(d => d.lastName.Contains(searchString));
            return View(drivers);
        }

        // GET: Drivers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Driver driver = _context.Driver.Single(m => m.ID == id);
            if (driver == null)
            {
                return HttpNotFound();
            }

            return View(driver);
        }

        // GET: Drivers/Create
        public IActionResult Create()
        {
            ViewBag.Addresses = new SelectList(_context.Address.ToList().Select(a => new { value = a.ID, text = a.ToString() }), "value", "text");
            return View();
        }

        // POST: Drivers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Driver driver)
        {
            Console.WriteLine(driver);
            if (ModelState.IsValid)
            {
                _context.Driver.Add(driver);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Addresses = new SelectList(_context.Address.ToList().Select( a => new { value=a.ID, text=a.ToString() }), "value", "text");
            return View(driver);
        }

        // GET: Drivers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Driver driver = _context.Driver.Single(m => m.ID == id);
            if (driver == null)
            {
                return HttpNotFound();
            }

            return View(driver);
        }

        // POST: Drivers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Driver driver)
        {
            if (ModelState.IsValid)
            {
                _context.Update(driver);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(driver);
        }

        // GET: Drivers/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Driver driver = _context.Driver.Single(m => m.ID == id);
            if (driver == null)
            {
                return HttpNotFound();
            }

            return View(driver);
        }

        // POST: Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Driver driver = _context.Driver.Single(m => m.ID == id);
            _context.Driver.Remove(driver);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
