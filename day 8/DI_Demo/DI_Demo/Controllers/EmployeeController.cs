using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DI_Demo.Models.EF;

namespace DI_Demo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDBContext _context;

        public EmployeeController(EmployeeDBContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            var employeeDBContext = _context.EmployeeInfos.Include(e => e.EmpDeptNavigation);
            return View(await employeeDBContext.ToListAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmployeeInfos == null)
            {
                return NotFound();
            }

            var employeeInfo = await _context.EmployeeInfos
                .Include(e => e.EmpDeptNavigation)
                .FirstOrDefaultAsync(m => m.EmpNo == id);
            if (employeeInfo == null)
            {
                return NotFound();
            }

            return View(employeeInfo);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            ViewData["EmpDept"] = new SelectList(_context.DeptInfos, "DId", "DId");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpNo,EmpName,EmpDesignation,EmpSalary,EmpDept,EmpIsPermenant")] EmployeeInfo employeeInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpDept"] = new SelectList(_context.DeptInfos, "DId", "DId", employeeInfo.EmpDept);
            return View(employeeInfo);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null || _context.EmployeeInfos == null)
            {
                return NotFound();
            }

            var employeeInfo = await _context.EmployeeInfos.FindAsync(id);
            if (employeeInfo == null)
            {
                return NotFound();
            }

            DeptInfo d = new DeptInfo();
            ViewBag.dept = d.GetDeptByLocation("New York");
            ViewData["EmpDept"] = new SelectList(_context.DeptInfos, "DId", "DId", employeeInfo.EmpDept);
            return View(employeeInfo);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpNo,EmpName,EmpDesignation,EmpSalary,EmpDept,EmpIsPermenant")] EmployeeInfo employeeInfo)
        {
            if (id != employeeInfo.EmpNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeInfoExists(employeeInfo.EmpNo))
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
            ViewData["EmpDept"] = new SelectList(_context.DeptInfos, "DId", "DId", employeeInfo.EmpDept);
            return View(employeeInfo);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmployeeInfos == null)
            {
                return NotFound();
            }

            var employeeInfo = await _context.EmployeeInfos
                .Include(e => e.EmpDeptNavigation)
                .FirstOrDefaultAsync(m => m.EmpNo == id);
            if (employeeInfo == null)
            {
                return NotFound();
            }

            return View(employeeInfo);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmployeeInfos == null)
            {
                return Problem("Entity set 'EmployeeDBContext.EmployeeInfos'  is null.");
            }
            var employeeInfo = await _context.EmployeeInfos.FindAsync(id);
            if (employeeInfo != null)
            {
                _context.EmployeeInfos.Remove(employeeInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeInfoExists(int id)
        {
          return _context.EmployeeInfos.Any(e => e.EmpNo == id);
        }
    }
}
