using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalSystemData;
using RentalSystemData.Entities;

namespace RentalSystem
{
    public class EmployeeController : Controller
    {
        private readonly RentalSystemDbContext _context;

        public EmployeeController(RentalSystemDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }
        public IActionResult AddOrEdit(Guid id)
        {
            if (id != null && id != Guid.Empty)
                return View(_context.Employees.Find(id));
            else
                return View(new Employee());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Name,FirstName,LastName,Age")] Employee Employee)
        {
            if (Employee != null)
            {
                //var empcategories = _context.EmployeeCategories.ToList();
                //SelectList list = new SelectList(empcategories, "Id", "Name");
                //ViewBag.empcategoryname = list;

                //var empcategories = _context.EmployeeCategories.ToList();  //get all countries you have (eg: from database)

                ViewBag.EmpCategories = new SelectList(GetEmployeeCategories(), "Id", "Name");

                if (Employee.Id != null && Employee.Id != Guid.Empty)
                {
                    _context.Update(Employee);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Employee.Id = Guid.NewGuid();
                    _context.Add(Employee);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(Employee);
        }
        public List<EmployeeCategory> GetEmployeeCategories()
        {
            var empcate = _context.EmployeeCategories.ToList();
            return empcate;
        }
    }
}
