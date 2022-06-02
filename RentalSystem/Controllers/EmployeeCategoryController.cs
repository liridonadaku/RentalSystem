using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalSystemData;
using RentalSystemData.Entities;

namespace RentalSystem
{
    public class EmployeeCategoryController : Controller
    {
        private readonly RentalSystemDbContext _context;

        public EmployeeCategoryController(RentalSystemDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeCategories.ToListAsync());
        }
        public IActionResult AddOrEdit(Guid id)
        {
            if (id != null && id != Guid.Empty)
                return View(_context.EmployeeCategories.Find(id));
            else
                return View(new EmployeeCategory());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Name")] EmployeeCategory EmployeeCategory)
        {
            if (EmployeeCategory != null)
            {
                if (EmployeeCategory.Id != null && EmployeeCategory.Id != Guid.Empty)
                {
                    _context.Update(EmployeeCategory);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    EmployeeCategory.Id = Guid.NewGuid();
                    _context.Add(EmployeeCategory);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(EmployeeCategory);
        }
    }
}
