using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Diagnostics;
using DAL.EF.EntityFrameworkContext;
using DAL.EF.Models;


namespace WebApplication1.Controllers
{
    
    public class HomeController : Controller
    {
        public ContextManager _contextManager = new ContextManager();


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About( )
        {
            

        //    ContextManager m = new ContextManager();

            return View();
        }

        public IActionResult Contact()
        {
            using (var db = new AteraDevServerForInterviewsContext())
            {
                return View(db.Devices.ToList());
            } 
        }

        public IActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Login(Users user)
        {

            //trying here
            Console.WriteLine("sending to _context : ");
            Console.WriteLine(user.Username + " " + user.HashPassword);

            DAL.EF.Models.Hash verifyPassword = new DAL.EF.Models.Hash();

            var account = _contextManager._context.Users.Where(u => u.Username == user.Username && verifyPassword.very(user.HashPassword, u.HashPassword)).FirstOrDefault();
            if (account != null)
            {
                HttpContext.Session.SetString("UserID", account.ContactId.ToString());
                HttpContext.Session.SetString("UserName", account.Username);

                return RedirectToAction("App");
            }
            else
            {
                ModelState.AddModelError("", "Login failed UserName or Password is worng plz try again");
            }
            
            return View();
        }
      
        public IActionResult App()
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                ViewBag.UserName = HttpContext.Session.GetString("UserName");
                ViewData["Devices"] = "shit";
                return View();
            }
            else
            {
                ViewData["Devices"] = "shit";
                return View("App");
            }
        }

        [Route("/api/device")]
        public JsonResult GetAllDevices()
        {
            var db1 = new ContextManager();

            
            return Json(db1.GetAllDevices());
          
        }
       
        [Route("~/api/DeviceByOwnerName/{name}")]
        [HttpGet]
        public JsonResult DeviceByOwnerName(string name)
        {
            var db1 = new ContextManager();
  
            return Json(db1.GetDevicesByOwnerName(name));
          
        }
        
        [Route("/api/DeviceList")]
        public JsonResult DeviceList()
        {
            var db1 = new ContextManager();
            var db = db1._context;

            var query = (from Devices in db.Devices
                         join Owners in db.Owners on Devices.DeviceId equals Owners.OwnerId

                         select new { Devices.DeviceId, Devices.Name, Devices.Created, Devices.OwnerId, Owners.FullName }).ToList();

               return Json(query);

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }



        public IActionResult Error()
        {
            return View();
        }
    }
}
