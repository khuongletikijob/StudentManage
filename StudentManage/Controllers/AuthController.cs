using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManage.Data;
using StudentManage.Models;
using StudentManage.Services;

namespace StudentManage.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserService _userService;
        private readonly StudentManageContext _context;

        public AuthController(UserService userService, StudentManageContext context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpGet]
        public IActionResult Login() => View();


        [HttpPost]
        public async Task<IActionResult> Register(S_User user)
        {
            if (ModelState.IsValid)
            {
                await _userService.RegisterUser(user);
                return RedirectToAction("Login");
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.S_Users.SingleOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetString("UserEmail", user.Email);
                return RedirectToAction("Index", "Student");
            }

            ViewBag.ErrorMessage = "Invalid login attempt.";
            return View();
        }
    }
}
