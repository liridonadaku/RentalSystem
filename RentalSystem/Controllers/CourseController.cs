using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalSystemData;
using RentalSystemData.Entities;

namespace RentalSystem
{
    public class CourseController : Controller
    {
        private readonly RentalSystemDbContext _context;

        public CourseController(RentalSystemDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> CourseList(Guid? studentId)
        {
            Enrollment enrollment = new Enrollment();
            enrollment.StudentId = studentId;
            var courses = _context.Courses.ToList();
            return View(await _context.Courses.ToListAsync());
        }      
        public async Task<IActionResult> Index()
        {
            return View(await _context.Courses.ToListAsync());
        }
        public IActionResult AddCourse(Guid studentId)
        {
            Course Course = new Course();
            //  Course.StudentId = studentId;
            //_context.Add(Course);
            //_context.SaveChanges();
            return View(Course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCourse([Bind("Id,Name,StudentId")] Course cert)
        {
            if (cert != null)
            {
                if (cert.Id != null && cert.Id != Guid.Empty)
                {
                    _context.Update(cert);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Student", new { id = cert.Id });
                }
                else
                {
                    cert.Id = Guid.NewGuid(); https://localhost:7018/Home/Privacy
                    _context.Add(cert);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Student", new { id = cert.Id });
                }
            }
            return View(cert);
        }
        public IActionResult AddOrEdit(Guid? id)
        {
            if (id != null && id != Guid.Empty)
                return View(_context.Courses.Find(id));
            else
                return View(new Course());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Name")] Course Course)
        {
            if (Course != null)
            {
                if (Course.Id != null && Course.Id != Guid.Empty)
                {
                    _context.Update(Course);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Course.Id = Guid.NewGuid();
                    _context.Add(Course);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(Course);
        }
    }
}
