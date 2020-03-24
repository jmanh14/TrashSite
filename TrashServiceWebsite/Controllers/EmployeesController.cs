using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashServiceWebsite.Data;
using TrashServiceWebsite.Models;
using TrashServiceWebsite.ViewModels;

namespace TrashServiceWebsite.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var myEmployeeProfile = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            var customersDb = _context.Customers.Include(e => e.IdentityUser).ToList();
            if (myEmployeeProfile == null)
            {
                return RedirectToAction("Create");
            }
            else
            {
                EmployeeViewModel employeeViewModel = new EmployeeViewModel()
                {
                    Customers = customersDb,
                    Employee = myEmployeeProfile
                };

                employeeViewModel.DayToPickUp = new List<SelectListItem>();
                employeeViewModel.DayToPickUp.Add(new SelectListItem() { Text = "Monday", Value = "1", Selected = false });
                employeeViewModel.DayToPickUp.Add(new SelectListItem() { Text = "Tuesday", Value = "2", Selected = false });
                employeeViewModel.DayToPickUp.Add(new SelectListItem() { Text = "Wednesday", Value = "3", Selected = false });
                employeeViewModel.DayToPickUp.Add(new SelectListItem() { Text = "Thursday", Value = "4", Selected = false });
                employeeViewModel.DayToPickUp.Add(new SelectListItem() { Text = "Friday", Value = "5", Selected = false });
                
                return View(employeeViewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(EmployeeViewModel employeeViewModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var myEmployeeProfile = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            var customersDb = _context.Customers.Where(a => a.DayToPickUp == employeeViewModel.SelectedDay).ToList();
            employeeViewModel.Employee = myEmployeeProfile;
            employeeViewModel.Customers = customersDb;
            return View(employeeViewModel);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var myEmployeeProfile = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (myEmployeeProfile == null)
            {
                return NotFound();
            }
            return View(myEmployeeProfile);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ZipCode,IdentityUserId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var myEmployeeProfile = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (myEmployeeProfile == null)
            {
                return NotFound();
            }
            return View(myEmployeeProfile);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ZipCode,IdentityUserId")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var myEmployeeProfile = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (myEmployeeProfile == null)
            {
                return NotFound();
            }
            return View(myEmployeeProfile);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }

        public async Task<IActionResult> ConfirmPickup(int id)
        {
            var customerToPickup = _context.Customers.Where(a => a.Id == id).FirstOrDefault();
            customerToPickup.Budget += 25;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
