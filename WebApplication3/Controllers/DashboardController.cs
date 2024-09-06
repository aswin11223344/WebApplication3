using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WebApplication3.model;

namespace WebApplication3.Controllers
{
    public class DashboardController : Controller
    {
        private readonly Mydbcontext Mydbcontext;
        public DashboardController(Mydbcontext mydbcontext)
        {
            Mydbcontext = mydbcontext;


        }
       
        public IActionResult Dashboard(string data)
        {
            var obj = Mydbcontext.RegTables.FirstOrDefault(x => x.email == data);
            if (obj != null)
            {
                ViewBag.Name = obj.Name;
                ViewBag.Email = obj.email;
                ViewBag.Age = obj.Age;
                ViewBag.Country = obj.Country;
                ViewBag.State = obj.State;
                ViewBag.City = obj.City;
                ViewBag.PhoneNumber = obj.PhoneNumber;
              
     
          
                string imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

           
                var imageFiles = Directory.GetFiles(imageDirectory, data + ".*");

            
                if (imageFiles.Length > 0)
                {
                    string imageName = Path.GetFileName(imageFiles[0]);
                    ViewBag.imagename = imageName;
                }
             

                return View();





            }
            return View();
          
        }
    }
}
