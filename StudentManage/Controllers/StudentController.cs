using Microsoft.AspNetCore.Mvc;
using StudentManage.Data;
using StudentManage.Models;

namespace StudentManage.Controllers
{
    [Route("Student")]
    public class StudentController : Controller
    {
        private readonly StudentManageContext _context;

        public StudentController(StudentManageContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(S_Student student)
        {
            if (ModelState.IsValid)
            {
                _context.S_Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _context.S_Students.SingleOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(S_Student student)
        {
            if (ModelState.IsValid)
            {
                _context.S_Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _context.S_Students.SingleOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.S_Students.SingleOrDefault(s => s.Id == id);
            if (student != null)
            {
                _context.S_Students.Remove(student);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
