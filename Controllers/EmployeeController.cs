using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpDepTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpDepTask.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {

        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Employee Employee { get; set; }
        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Employee = new Employee();

            if(id == null)
            {
                // Create
                return View(Employee);
            }

            Employee = _db.Employees.FirstOrDefault(u => u.id == id);

            if(Employee == null)
            {
                return NotFound(Employee);
            }

            return View(Employee);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Employee.id == 0)
                {
                    //create
                    _db.Employees.Add(Employee);
                }
                else
                {
                    _db.Employees.Update(Employee);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Employee);
        }

        #region API Calls

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Employees.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var EmpFromDb = await _db.Employees.FirstOrDefaultAsync(u => u.id == id);
            if (EmpFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Employees.Remove(EmpFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }

        #endregion
    }
}
