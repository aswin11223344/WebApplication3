using Microsoft.AspNetCore.Mvc;
using WebApplication3.model;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class RegController : Controller
    {
        private readonly Mydbcontext Mydbcontext;
        public RegController(Mydbcontext mydbcontext)
        {
            Mydbcontext = mydbcontext;


        }
        [HttpGet]
        public IActionResult Reg()
        {
            return View();
        }
   

        [HttpPost]
        public IActionResult Reg(Reg objr, IFormFile myfile)
        {
           
           
                var table = new  RegTable
                {
                    Id = Guid.NewGuid(),
                    Name = objr.Name,
                    Age = objr.Age,
                    Country = objr.Country,
                    State = objr.State,
                    City = objr.City,
                    PhoneNumber = objr.PhoneNumber,
                    email = objr.email,
                    CPassword=objr.CPassword,
                  

                };
                Mydbcontext.RegTables.Add(table);
                Mydbcontext.SaveChanges();
                try
                {
                    string file_name = myfile.FileName;
                    file_name = objr.email + Path.GetExtension(file_name);
                    string upload_folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//uploads");

                    if (!Directory.Exists(upload_folder))
                    {
                        Directory.CreateDirectory(upload_folder);
                    }

                    string upload_path = Path.Combine(upload_folder, file_name);

                    if (System.IO.File.Exists(upload_path))
                    {
                        ViewBag.UploadStatus += file_name + "-Already Exists";


                        upload_path = Path.Combine(upload_folder, file_name);
                    }
                    else
                    {
                        ViewBag.UploadStatus += myfile.FileName + " Uploaded successfully\n";
                    }
                    // File upload using FileStream
                    var uploadsteam = new FileStream(upload_path, FileMode.Create);
                    myfile.CopyToAsync(uploadsteam);


                }
                catch (Exception ex)
                {
                    ViewBag.UploadStatus += $"Unable to upload files {ex.Message}";
                }


                return View();
            }
        

        }
    }

