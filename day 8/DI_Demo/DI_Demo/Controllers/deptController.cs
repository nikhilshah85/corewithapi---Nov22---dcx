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
    public class deptController : Controller
    {
        private readonly EmployeeDBContext _context;

        public deptController(EmployeeDBContext context)
        {
            _context = context;
        }

        // GET: dept
        public async Task<IActionResult> Index()
        {
              return View(await _context.DeptInfos.ToListAsync());
        }

        // GET: dept/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DeptInfos == null)
            {
                return NotFound();
            }

            var deptInfo = await _context.DeptInfos
                .FirstOrDefaultAsync(m => m.DId == id);
            if (deptInfo == null)
            {
                return NotFound();
            }

            return View(deptInfo);
        }

        // GET: dept/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: dept/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DId,DName,DLocation")] DeptInfo deptInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deptInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deptInfo);
        }

        // GET: dept/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DeptInfos == null)
            {
                return NotFound();
            }

            var deptInfo = await _context.DeptInfos.FindAsync(id);
            if (deptInfo == null)
            {
                return NotFound();
            }
            return View(deptInfo);
        }

        // POST: dept/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DId,DName,DLocation")] DeptInfo deptInfo)
        {
            if (id != deptInfo.DId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deptInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeptInfoExists(deptInfo.DId))
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
            return View(deptInfo);
        }

        // GET: dept/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DeptInfos == null)
            {
                return NotFound();
            }

            var deptInfo = await _context.DeptInfos
                .FirstOrDefaultAsync(m => m.DId == id);
            if (deptInfo == null)
            {
                return NotFound();
            }

            return View(deptInfo);
        }

        // POST: dept/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DeptInfos == null)
            {
                return Problem("Entity set 'EmployeeDBContext.DeptInfos'  is null.");
            }
            var deptInfo = await _context.DeptInfos.FindAsync(id);
            if (deptInfo != null)
            {
                _context.DeptInfos.Remove(deptInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeptInfoExists(int id)
        {
          return _context.DeptInfos.Any(e => e.DId == id);
        }
    }
}
