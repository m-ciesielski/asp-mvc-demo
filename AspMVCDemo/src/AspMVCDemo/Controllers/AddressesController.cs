using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using AspMVCDemo.Models;
using Microsoft.AspNet.Authorization;

namespace AspMVCDemo.Controllers
{
    public class AddressesController : Controller
    {
        private ApplicationDbContext _context;

        public AddressesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Addresses
        [Authorize]
        public IActionResult Index()
        {
            return View(_context.Address.ToList());
        }

        // GET: Addresses/Details/5
        [Authorize]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Address address = _context.Address.Single(m => m.ID == id);
            if (address == null)
            {
                return HttpNotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        [Authorize(Roles = "Operator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Addresses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Operator")]
        public IActionResult Create(Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Address.Add(address);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(address);
        }

        // GET: Addresses/Edit/5
        [Authorize(Roles = "Operator")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Address address = _context.Address.Single(m => m.ID == id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Operator")]
        public IActionResult Edit(Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Update(address);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(address);
        }

        // GET: Addresses/Delete/5
        [ActionName("Delete")]
        [Authorize(Roles = "Operator")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Address address = _context.Address.Single(m => m.ID == id);
            if (address == null)
            {
                return HttpNotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Operator")]
        public IActionResult DeleteConfirmed(int id)
        {
            Address address = _context.Address.Single(m => m.ID == id);
            _context.Address.Remove(address);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
