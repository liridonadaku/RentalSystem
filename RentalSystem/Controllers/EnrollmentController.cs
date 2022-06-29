using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalSystemData;
using RentalSystemData.Entities;

namespace RentalSystem
{
    public class EnrollmentController : Controller
    {
        private readonly RentalSystemDbContext _context;

        public EnrollmentController(RentalSystemDbContext context)
        {
            _context = context;
        }
        
        public IActionResult CourseList(Guid? studentId)
        {
            ViewBag.CourseID = new SelectList(_context.Courses, "Id", "Name");
            Enrollment enrollment = new Enrollment();
            enrollment.StudentId = studentId;
            //  Course.StudentId = studentId;
            //_context.Add(Course);
            //_context.SaveChanges();
            return View(enrollment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CourseList([Bind("Id,Name,EnrollmentNumber,StudentId,CourseId")] Enrollment Enrollment)
        {
            if (Enrollment != null)
            {
                if (Enrollment.Id != null && Enrollment.Id != Guid.Empty)
                {
                    _context.Update(Enrollment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Enrollment.Id = Guid.NewGuid();
                    _context.Add(Enrollment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(Enrollment);
        }
        public IActionResult StudentToCourse(Guid? studentId, Guid? courseId)
        {
            Enrollment enrollment = new Enrollment();
            enrollment.StudentId = studentId;
            enrollment.CourseId = courseId;
            //  Course.StudentId = studentId;
            //_context.Add(Course);
            //_context.SaveChanges();
            return View(enrollment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StudentToCourse([Bind("Id,Name,StudentId,CourseId")] Enrollment enrollment)
        {
            if (enrollment != null)
            {
                if (enrollment.Id != null && enrollment.Id != Guid.Empty)
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Student", new { id = enrollment.StudentId });
                }
                else
                {
                    enrollment.Id = Guid.NewGuid(); https://localhost:7018/Home/Privacy
                    _context.Add(enrollment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Student", new { id = enrollment.StudentId });
                }
            }
            return View(enrollment);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Enrollments.ToListAsync());
        }
        public IActionResult AddOrEdit(Guid id)
        {
            if (id != null && id != Guid.Empty)
                return View(_context.Enrollments.Find(id));
            else
                return View(new Enrollment());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Name")] Enrollment Enrollment)
        {
            if (Enrollment != null)
            {
                if (Enrollment.Id != null && Enrollment.Id != Guid.Empty)
                {
                    _context.Update(Enrollment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Enrollment.Id = Guid.NewGuid();
                    _context.Add(Enrollment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(Enrollment);
        }
    }
}
