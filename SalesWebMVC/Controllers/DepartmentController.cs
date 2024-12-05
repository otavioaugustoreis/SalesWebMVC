using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Data.Entity;

namespace SalesWebMVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Department
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departments.ToListAsync());
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentEntity = await _context.Departments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentEntity == null)
            {
                return NotFound();
            }

            return View(departmentEntity);
        }

        // GET: Department/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DsNome,Id,DhInclusao")] DepartmentEntity departmentEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departmentEntity);
        }

        // GET: Department/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentEntity = await _context.Departments.FindAsync(id);
            if (departmentEntity == null)
            {
                return NotFound();
            }
            return View(departmentEntity);
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("DsNome,Id,DhInclusao")] DepartmentEntity departmentEntity)
        {
            if (id != departmentEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentEntityExists(departmentEntity.Id))
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
            return View(departmentEntity);
        }

        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentEntity = await _context.Departments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentEntity == null)
            {
                return NotFound();
            }

            return View(departmentEntity);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var departmentEntity = await _context.Departments.FindAsync(id);
            if (departmentEntity != null)
            {
                _context.Departments.Remove(departmentEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentEntityExists(int? id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}
