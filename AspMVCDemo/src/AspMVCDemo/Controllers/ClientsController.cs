using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using AspMVCDemo.Models;
using AspMVCDemo.ViewModels;

namespace AspMVCDemo.Controllers
{
    public class ClientsController : Controller
    {
        private ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Clients
        public IActionResult Index()
        {
            return View(_context.Client.Include(a => a.Address));
        }

        // GET: Clients/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Client client = _context.Client.Where(m => m.ID == id).Include(a => a.Address).FirstOrDefault();
            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            ViewBag.Addresses = _context.Address.ToList();
            return View(new ClientViewModel());
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClientViewModel clientViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = clientViewModel.Client;
                client.Address = _context.Address.Single(a => a.ID.Equals(clientViewModel.addressId));
                _context.Client.Add(client);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Addresses = _context.Address.ToList();
            return View(clientViewModel);
        }

        // GET: Clients/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Client client = _context.Client.Where(m => m.ID == id).Include(a => a.Address).FirstOrDefault();
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.Addresses = _context.Address.ToList();
            return View(new ClientViewModel(client, client.Address.ID));
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClientViewModel clientViewModel)
        {

            var client = clientViewModel.Client;

            if (ModelState.IsValid)
            {
                client.Address = _context.Address.Single(a => a.ID.Equals(clientViewModel.addressId));
                _context.Update(client);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Addresses = _context.Address.ToList();
            return View(new ClientViewModel(client, client.Address.ID));
        }

        // GET: Clients/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Client client = _context.Client.Single(m => m.ID == id);
            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Client client = _context.Client.Single(m => m.ID == id);
            _context.Client.Remove(client);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
