using Microsoft.AspNetCore.Mvc;

using WebApplication3.model;
using WebApplication3.Models;



namespace WebApplication3.Controllers
{
    public class LoginController : Controller
    {
        private readonly Mydbcontext Mydbcontext;
        public LoginController(Mydbcontext mydbcontext)
        {
            Mydbcontext = mydbcontext;


        }
        [HttpGet]
        public IActionResult Login()

        {
            if (HttpContext.Request.Cookies["cook"] != null)
            {
                string email = HttpContext.Request.Cookies["cook"];

                return RedirectToAction("Dashboard", "Dashboard", new { data =email});
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            var obj1 = Mydbcontext.RegTables.FirstOrDefault(x => x.email == login.email);
            var obj2 = Mydbcontext.RegTables.FirstOrDefault(x => x.CPassword == login.Password);
            if (obj1 != null && obj2 != null)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTimeOffset.Now.AddHours(1);
                HttpContext.Response.Cookies.Append("cook",obj1.email , options);
                return RedirectToAction("Dashboard", "Dashboard", new { data = login.email });
            }
            else
            {
                ViewBag.errormsg = "Email and Password doest match";
                return View();
            }
           
        }
    }
}
