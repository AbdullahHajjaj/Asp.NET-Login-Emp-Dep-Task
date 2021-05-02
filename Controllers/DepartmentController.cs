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
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Department Department { get; set; }
        public DepartmentController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Upsert(int? id)
        {
            Department = new Department();

            if (id == null)
            {
                // Create
                return View(Department);
            }

            Department = _db.Departments.FirstOrDefault(u => u.id == id);

            if (Department == null)
            {
                return NotFound(Department);
            }

            return View(Department);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Department.id == 0)
                {
                    //create
                    _db.Departments.Add(Department);
                }
                else
                {
                    _db.Departments.Update(Department);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Department);
        }

        #region API Calls

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Departments.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var DepFromDb = await _db.Departments.FirstOrDefaultAsync(u => u.id == id);
            if (DepFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Departments.Remove(DepFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }

        #endregion
    }
}
