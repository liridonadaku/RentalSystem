using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalSystemData;
using RentalSystemData.Entities;

namespace RentalSystem
{
    public class StudentController : Controller
    {
        private readonly RentalSystemDbContext _context;

        public StudentController(RentalSystemDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Students = _context.Students.Include(e => e.Department);
            return View(Students);
        }
        //StudentApi
        public JsonResult ListApi()
        {
            var Students = _context.Students.Include(e => e.Department);
            return Json(Students);
        }
        public IActionResult AddOrEdit(Guid id)
        {
            ViewBag.DepartmentID = new SelectList(_context.Departments, "Id", "Name");

            if (id != null && id != Guid.Empty)
                return View(_context.Students.Find(id));
            else
                return View(new Student());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Name,FirstName,LastName,Age,DepartmentId")] Student Student)
        {
            if (Student != null)
            {
                if (Student.Id != null && Student.Id != Guid.Empty)
                {
                    _context.Update(Student);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Student.Id = Guid.NewGuid();
                    _context.Add(Student);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(Student);
        }
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            if (id != null && id != Guid.Empty)
            {
                //var ReadMovie = context.Movies.Include(t => t.Genres).FirstOrDefaultAsync(t => t.MovieId == id).ToList();
                var stus = _context.Students.Include(t => t.Certifications).Include(t=>t.Enrollments).ToList();

                //var Students = _context.Students.Include(e => e.Department);
                return View(stus.FirstOrDefault(x=>x.Id==id));
            }
            return View();
        }      
    }
}
