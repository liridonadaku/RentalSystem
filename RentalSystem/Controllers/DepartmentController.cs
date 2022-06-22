using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalSystemData;
using RentalSystemData.Entities;

namespace RentalSystem
{
    public class DepartmentController : Controller
    {
        private readonly RentalSystemDbContext _context;

        public DepartmentController(RentalSystemDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Departments.ToListAsync());
        }
        public IActionResult AddOrEdit(Guid id)
        {
            if (id != null && id != Guid.Empty)
                return View(_context.Departments.Find(id));
            else
                return View(new Department());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Name")] Department Department)
        {
            if (Department != null)
            {
                if (Department.Id != null && Department.Id != Guid.Empty)
                {
                    _context.Update(Department);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Department.Id = Guid.NewGuid();
                    _context.Add(Department);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(Department);
        }
    }
}
