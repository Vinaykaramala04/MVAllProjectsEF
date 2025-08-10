using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodefirstSchoolManagement.Data;
using CodefirstSchoolManagement.Models;

namespace CodefirstSchoolManagement.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            try
            {
                var appDbContext = _context.Students.Include(s => s.Teacher);
                return View(await appDbContext.ToListAsync());
            }
            catch
            {
                return Problem("An error occurred while loading students.");
            }
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null) return NotFound();

                var student = await _context.Students
                    .Include(s => s.Teacher)
                    .FirstOrDefaultAsync(m => m.StudentId == id);
                if (student == null) return NotFound();

                return View(student);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            try
            {
                ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "Name");
                return View();
            }
            catch
            {
                return Problem("Unable to load create form.");
            }
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            try
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "Name", student.TeacherId);
                return View(student);
            }
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null) return NotFound();

                var student = await _context.Students.FindAsync(id);
                if (student == null) return NotFound();

                ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "Name", student.TeacherId);
                return View(student);
            }
            catch
            {
                return NotFound();
            }
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.StudentId) return NotFound();

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "Name", student.TeacherId);
                return View(student);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(student.StudentId))
                    return NotFound();
                else
                    throw;
            }
            catch
            {
                ViewData["TeacherId"] = new SelectList(_context.Teachers, "TeacherId", "Name", student.TeacherId);
                return View(student);
            }
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null) return NotFound();

                var student = await _context.Students
                    .Include(s => s.Teacher)
                    .FirstOrDefaultAsync(m => m.StudentId == id);
                if (student == null) return NotFound();

                return View(student);
            }
            catch
            {
                return NotFound();
            }
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student != null)
                {
                    _context.Students.Remove(student);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}
