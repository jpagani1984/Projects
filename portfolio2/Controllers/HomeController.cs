using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using portfolio2.Models;

namespace portfolio2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route ("/")]
        public IActionResult LogIn()
        {
            ViewData["Title"] = "Log In";
            return View("reg");
        }
        [HttpPost]
        [Route ("home")]
         public IActionResult Register(Register reg)
        {
            if(ModelState.IsValid)
            {
                Register user = new Register
                {
                    firstname = reg.firstname,
                    lastname = reg.lastname,
                    username = reg.username,
                    email1 = reg.email1,
                    password = reg.password,
                    confpassword = reg.confpassword
                    
                };
                return View("Index", user);
            }
            else
            {
                
                return View("reg");
            }
           
        }
        [HttpGet]
        [Route ("index")]
        public IActionResult Index()
        {
            ViewData["Title"] = "About Me";
            return View("Index");
        }
        [HttpGet]
        [Route ("Projects")]
        public IActionResult Projects()
        {
            var DateTime = new DateTime();
            ViewBag.time = DateTime.Now;
            ViewData["Message"] = "Here are some Product Manufacturers";

            return View("Projects");
        }
        [HttpGet]
        [Route ("contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View("contact");
        }
        [HttpGet]
        [Route ("user")]
        public IActionResult User()
        {
            User user = new User
            {
                FirstName = "Joseph",
                LastName = "Pagani",
                Number = 123456789
            };
            
            return View("user", user);
        }
        [HttpGet]
        [Route ("members")]
        public IActionResult Members()
        {
            string[] members = new string[]
            {
                "Joseph Pagani", "Ozzy Osbourne", "James Hettfield", "Tony Iomi"
            };
            
            return View("members", members);
        }
        [HttpGet]
        [Route ("error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        [Route("method")]
        public IActionResult Method(string name, string location, string language, string comment)
        {
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comment = comment;
            return View("success");
        }
        [HttpPost]
        [Route ("survey")]
        public IActionResult Survey(string name, string board, string bike)
        {

            Choice choice = new Choice
            {
                name = name,
                board = board,
                bike = bike
            };
            return View("survey", choice);
        }
        [HttpPost]
        [Route("zebra/thanks")]
        public IActionResult Zebra(Info info)
        {
            if(ModelState.IsValid)
            {
                Info user = new Info
                {
                    fullname = info.fullname,
                    email = info.email,
                    message = info.message
                    
                };
                return View("thanks", user);
            }
            else
            {
                return View("contact");
            }
           
        }
        [HttpGet]
        [Route ("success")]
        public IActionResult Sucess()
        {
            return View("success");
        }
        [HttpGet]
        [Route ("thanks")]
        public IActionResult Thanks()
        {
            return View("thanks");
        }
        [HttpGet]
        [Route ("dochi")]
         public IActionResult Dochi(int fullness, int happiness, int meals, int energy)
        {
           
            HttpContext.Session.SetInt32("fullness", 20);
            HttpContext.Session.SetInt32("happiness", 20);
            HttpContext.Session.SetInt32("meals", 3);
            HttpContext.Session.SetInt32("energy", 50);
            ViewBag.fullness = HttpContext.Session.GetInt32("fullness");
            ViewBag.happiness = HttpContext.Session.GetInt32("happiness");
            ViewBag.meals =  HttpContext.Session.GetInt32("meals");
            ViewBag.energy =  HttpContext.Session.GetInt32("energy");
            return View("dochi");
        }
        [HttpPost]
        [Route ("dochi/feed")]
         public IActionResult Feed()
        {
            int Fullness = (int)HttpContext.Session.GetInt32("fullness") + 5;
            HttpContext.Session.SetInt32("fullness", Fullness);
            int Happiness = (int)HttpContext.Session.GetInt32("happiness") +2;
            HttpContext.Session.SetInt32("happiness", Happiness);
            int Meals = (int)HttpContext.Session.GetInt32("meals") - 1;
            HttpContext.Session.SetInt32("meals", Meals);
            int Energy =  (int)HttpContext.Session.GetInt32("energy") +1;
            HttpContext.Session.SetInt32("energy", Energy);
            ViewBag.fullness = HttpContext.Session.GetInt32("fullness");
            ViewBag.happiness = HttpContext.Session.GetInt32("happiness");
            ViewBag.meals =  HttpContext.Session.GetInt32("meals");
            ViewBag.energy =  HttpContext.Session.GetInt32("energy");
            return View("dochi");
        }
        [HttpPost]
        [Route ("dochi/play")]
         public IActionResult Play()
        {
            int Fullness = (int)HttpContext.Session.GetInt32("fullness") - 2;
            HttpContext.Session.SetInt32("fullness", Fullness);
            int Happiness = (int)HttpContext.Session.GetInt32("happiness") +3;
            HttpContext.Session.SetInt32("happiness", Happiness);
            int Energy =  (int)HttpContext.Session.GetInt32("energy") - 1;
            HttpContext.Session.SetInt32("energy", Energy);
            ViewBag.fullness = HttpContext.Session.GetInt32("fullness");
            ViewBag.happiness = HttpContext.Session.GetInt32("happiness");
            ViewBag.meals =  HttpContext.Session.GetInt32("meals");
            ViewBag.energy =  HttpContext.Session.GetInt32("energy");
            return View("dochi");
        }
         [HttpPost]
        [Route ("dochi/work")]
         public IActionResult Work()
        {
            int Fullness = (int)HttpContext.Session.GetInt32("fullness") - 3;
            HttpContext.Session.SetInt32("fullness", Fullness);
            int Happiness = (int)HttpContext.Session.GetInt32("happiness") - 1;
            HttpContext.Session.SetInt32("happiness", Happiness);
            int Meals = (int)HttpContext.Session.GetInt32("meals") + 1;
            HttpContext.Session.SetInt32("meals", Meals);
            int Energy =  (int)HttpContext.Session.GetInt32("energy") - 2;
            HttpContext.Session.SetInt32("energy", Energy);
            ViewBag.fullness = HttpContext.Session.GetInt32("fullness");
            ViewBag.happiness = HttpContext.Session.GetInt32("happiness");
            ViewBag.meals =  HttpContext.Session.GetInt32("meals");
            ViewBag.energy =  HttpContext.Session.GetInt32("energy");
            return View("dochi");
        }
         [HttpPost]
        [Route ("dochi/sleep")]
         public IActionResult Sleep()
        {
            int Fullness = (int)HttpContext.Session.GetInt32("fullness") - 3;
            HttpContext.Session.SetInt32("fullness", Fullness);
            int Happiness = (int)HttpContext.Session.GetInt32("happiness") + 5;
            HttpContext.Session.SetInt32("happiness", Happiness);
            int Energy =  (int)HttpContext.Session.GetInt32("energy") + 3;
            HttpContext.Session.SetInt32("energy", Energy);
            ViewBag.fullness = HttpContext.Session.GetInt32("fullness");
            ViewBag.happiness = HttpContext.Session.GetInt32("happiness");
            ViewBag.meals =  HttpContext.Session.GetInt32("meals");
            ViewBag.energy =  HttpContext.Session.GetInt32("energy");
            return View("dochi");
        }
    }
}
