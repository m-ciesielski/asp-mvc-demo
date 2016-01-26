using AspMVCDemo.Models;
using AspMVCDemo.ViewModels.Account;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMVCDemo.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationDbContext _context;
        public RoleController(ApplicationDbContext context) { this._context = context; }

        //
        // GET: /Role/Index
        public IActionResult Index()
        {
            ViewBag.Roles = _context.Roles.ToList();
            return View();
        }

        //
        // GET: /Role/Manage
        [Authorize(Roles = "Operator")]
        public IActionResult AddRole()
        {
            ViewBag.Roles = _context.Roles.ToList();
            return View();
        }

        //
        // Post: /Role/AddRole
        [HttpPost, ActionName("Add")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Operator")]
        public IActionResult AddRole(RoleViewModel roleViewModel)
        {
            if (!string.IsNullOrEmpty(roleViewModel.name))
            {
                _context.Roles.Add(new IdentityRole(roleViewModel.name));
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Role/Edit/name
        [Authorize(Roles = "Operator")]
        public IActionResult Edit(string name)
        {
            if (name == null)
            {
                return HttpNotFound();
            }

            IdentityRole role = _context.Roles.Single(m => m.Name == name);
            if (role == null)
            {
                return HttpNotFound();
            }

            ViewBag.Addresses = _context.Address.ToList();
            return View(new RoleViewModel(role.Name));
        }

        // POST: Role/Delete/name
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string name)
        {
            IdentityRole role = _context.Roles.Single(m => m.Name == name);
            _context.Roles.Remove(role);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
