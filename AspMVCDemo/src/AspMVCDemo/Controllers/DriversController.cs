using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using AspMVCDemo.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNet.Authorization;
using AspMVCDemo.ViewModels;

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
        [Authorize]
        public IActionResult Index(string searchString)
        {
            var drivers = from d in _context.Driver select d;

            if (!string.IsNullOrEmpty(searchString))
                drivers = drivers.Where(d => d.lastName.Contains(searchString));
            return View(drivers);
        }

        // GET: Drivers/Details/5
        [Authorize]
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
        [Authorize(Roles = "Operator")]
        public IActionResult Create()
        {
            //ViewBag.Addresses = new SelectList(_context.Address.ToList().Select(a => new { value = a, text = a.ToString() }), "value", "text");
            ViewBag.Addresses = _context.Address.ToList();
            return View(new DriverViewModel());
        }

        // POST: Drivers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Operator")]
        public IActionResult Create(DriverViewModel driverViewModel)
        {
            if (ModelState.IsValid)
            {
                var driver = driverViewModel.driver;
                driver.address = (Address) _context.Address.Single(a => a.ID.Equals(driverViewModel.addressId));
                _context.Driver.Add(driver);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.Addresses = new SelectList(_context.Address.ToList().Select( a => new { value=a.ID, text=a.ToString() }), "value", "text");
            ViewBag.Addresses = _context.Address.ToList();
            return View(driverViewModel);
        }

        // GET: Drivers/Edit/5
        [Authorize(Roles = "Operator")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Driver driver = _context.Driver.Where(m => m.ID == id).Include(a => a.address).FirstOrDefault();
            if (driver == null)
            {
                return HttpNotFound();
            }

            ViewBag.Addresses = _context.Address.ToList();
            return View(new DriverViewModel(driver, driver.address.ID));
        }

        // POST: Drivers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Operator")]
        public IActionResult Edit(DriverViewModel driverViewModel)
        {
            var driver = driverViewModel.driver;
            if (ModelState.IsValid)
            {
                driver.address = (Address)_context.Address.Single(a => a.ID.Equals(driverViewModel.addressId));
                _context.Update(driver);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Addresses = _context.Address.ToList();
            return View(new DriverViewModel(driver, driver.address.ID));
        }

        // GET: Drivers/Delete/5
        [ActionName("Delete")]
        [Authorize(Roles = "Operator")]
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
        [Authorize(Roles = "Operator")]
        public IActionResult DeleteConfirmed(int id)
        {
            Driver driver = _context.Driver.Single(m => m.ID == id);
            _context.Driver.Remove(driver);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
