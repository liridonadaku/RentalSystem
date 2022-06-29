using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalSystemData;
using RentalSystemData.Entities;

namespace RentalSystem
{
    public class CertificationController : Controller
    {
        private readonly RentalSystemDbContext _context;

        public CertificationController(RentalSystemDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Certifications.ToListAsync());
        }
        public IActionResult AddCertification(Guid studentId)
        {
            Certification certification = new Certification();
            certification.StudentId = studentId;
            //_context.Add(certification);
            //_context.SaveChanges();
            return View(certification);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCertification([Bind("Id,Name,StudentId")] Certification cert)
        {
            if (cert != null)
            {
                if (cert.Id != null && cert.Id != Guid.Empty)
                {
                    _context.Update(cert);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Student", new { id = cert.StudentId });
                }
                else
                {
                    cert.Id = Guid.NewGuid();https://localhost:7018/Home/Privacy
                    _context.Add(cert);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Student", new {id = cert.StudentId});
                }
            }
            return View(cert);
        }
        public IActionResult AddOrEdit(Guid?id)
        {
            if (id != null && id != Guid.Empty)
                return View(_context.Certifications.Find(id));
            else
                return View(new Certification());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Name,StudentId")] Certification Certification)
        {
            if (Certification != null)
            {
                if (Certification.Id != null && Certification.Id != Guid.Empty)
                {
                    _context.Update(Certification);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Certification.Id = Guid.NewGuid();
                    _context.Add(Certification);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(Certification);
        }
    }
}
