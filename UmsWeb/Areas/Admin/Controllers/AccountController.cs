using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UmsWeb.DataAccess;
using UmsWeb.DataAccess.Repository.IRepository;
using UmsWeb.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using UmsWeb.Models;

namespace UmsWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _context;
        public AccountController(IUnitOfWork context)
        {
            _context = context;
        }
       
        [Authorize(Roles = "user")]
        public IActionResult StudentDetail(int id)
        {
            var obj = _context.Students.GetFirstOrDefault(u => u.Id == id, includeProperties: "Course,Department,User");
            return View(obj);
        }
        
        /*public IActionResult Logout()
        {
            
        }*/

        [Area("Admin")]
        //get
        public IActionResult Login()
        {
            return View();
        }
        [Area("Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Users user)
        {
            if (ModelState.IsValid)
            {
                ClaimsIdentity identity = null;
                bool isAuthenticate = false;
                if (user.Username == "admin" && user.Password == "admin@123")
                {
                    identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name,user.Username),
                        new Claim(ClaimTypes.Role,"admin" )
                    },
                    CookieAuthenticationDefaults.AuthenticationScheme);
                    isAuthenticate = true;
                    var principal = new ClaimsPrincipal(identity);
                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("Index", "Home", new { Area = "Student" });
                }
                var student = _context.Students.GetFirstOrDefault(s => s.User.Username == user.Username && s.User.Password==user.Password);
                if (student != null)
                {

                        identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name,user.Username),
                        new Claim(ClaimTypes.Role,"user" )

                    },
                    CookieAuthenticationDefaults.AuthenticationScheme);
                        isAuthenticate = true;
                        var principal = new ClaimsPrincipal(identity);
                        var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        return RedirectToAction("StudentDetail", "Account", new {id=student.Id, Area = "Admin" });
                    
                    
                }

                /*if (isAuthenticate)
                {
                    var principal = new ClaimsPrincipal(identity);
                    if (principal.IsInRole("admin"))
                    {
                        var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        return RedirectToAction("Index", "Course", new { Area = "Admin" });
                    }
                    if (principal.IsInRole("user"))
                    {
                        var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        return RedirectToAction("StudentDetail", "Account", new { Area = "Admin", id = student.Id });
                    }
*//*
                }
                if(!isAuthenticate)
                {
                    return RedirectToAction("Login", "Account", new { Area = "Admin" });
                }
                */
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
