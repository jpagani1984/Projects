using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using userlogin.Models;

namespace userlogin.Controllers
{
    public class HomeController : Controller
    {
        private UserContext _context;
 
        public HomeController(UserContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route ("Index")]
         public IActionResult Register(Register reg)
        {
            if(ModelState.IsValid)
            {
                var users = _context.users.Where(x => x.email == reg.email).ToList();
                if (users.Count == 0) 
                {
                    User NewUser = new User
                    {
                        firstname = reg.firstname,
                        lastname = reg.lastname,
                        alias = reg.alias,
                        email = reg.email,
                        password = reg.password,
                    };
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    NewUser.password = Hasher.HashPassword(NewUser,NewUser.password);
                    _context.Add(NewUser);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("UserId", NewUser.UserId);
                    return RedirectToAction("Home");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public IActionResult LoginMethod(string email, string password)
        {
            
            var user = _context.users.SingleOrDefault(x => x.email == email);
            if(user != null && password != null)
            {
                var Hasher = new PasswordHasher<User>();
                
                if(0 != Hasher.VerifyHashedPassword(user, user.password, password))
                {   
                    HttpContext.Session.SetInt32("UserId", user.UserId);
                    return RedirectToAction("Home");
                }
            }
            return View("Index");
        }
        [HttpGet]
        [Route ("Index")]
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpGet]
        [Route("Home")]
        public IActionResult Home()
        {
            var id = (HttpContext.Session.GetInt32("UserId") ?? 0);
            if (id == 0) 
            {
                return RedirectToAction("Index");
            }
            var user = _context.users.Where(x => x.UserId == id).First();
            var posts = _context.posts.Include(c => c.createdby).Include(x => x.Likers).ThenInclude(u => u.user).OrderByDescending(d => d.date).ToList();
            ViewBag.posts = posts;
            ViewBag.user = user;
            ViewBag.UserId = id;
            return View("Home"); 
        }
        [HttpPost]
        public IActionResult Create(string posts, int PostId)
        { 
            var sum = 0;
            int createrid = (int)HttpContext.Session.GetInt32("UserId");
            Posts NewPost = new Posts
            {
                UserId = createrid,
                posts = posts,
                date = DateTime.Now
            };
        ViewBag.sum = sum ++;
        var says = _context.posts.SingleOrDefault(t => t.PostId == PostId);
        _context.Add(NewPost);
        _context.SaveChanges();
        return RedirectToAction("Home");
        }

        [HttpGet]
        [Route("like/{PostId}")]
        public IActionResult Like(int PostId)
        {
            var id = (HttpContext.Session.GetInt32("UserId") ?? 0);
            {
                Likes likers = new Likes
                {
                    UserId = id,
                    PostId = PostId
                };
            _context.Add(likers);
            _context.SaveChanges();
            return RedirectToAction("Home");
            } 
        
        }
        [HttpGet]
        [Route("unlike/{PostId}")]
        public IActionResult Unlike(int PostId)
        {
            var id = (HttpContext.Session.GetInt32("UserId") ?? 0);
            {
            var remove = _context.likers.SingleOrDefault(t => t.PostId == PostId && t.UserId == id);    
            _context.Remove(remove);
            _context.SaveChanges();
            return RedirectToAction("Home");
            } 
        
        }
        [HttpGet]
        [Route("delete/{PostId}")]
        public IActionResult Delete(int PostId)
        {
            var id = (HttpContext.Session.GetInt32("UserId") ?? 0);
            var remove = _context.posts.SingleOrDefault(t => t.PostId == PostId);
            if(remove.UserId == id)
            {
                _context.Remove(remove);
                _context.SaveChanges();

                return RedirectToAction("Home"); 
            }
            else
            {
                return RedirectToAction("Home");
            }
        }
        [HttpGet]
        [Route("userinfo/{UserId}")]
        public IActionResult Userinfo(int UserId)
        {
            var id = (HttpContext.Session.GetInt32("UserId") ?? 0);
            if ((HttpContext.Session.GetInt32("UserId") ?? 0) == 0) 
            {
                return RedirectToAction("Index");
            } 
            var user = _context.users.Include(c => c.Creater).Include(a => a.AllPosts).SingleOrDefault(x => x.UserId == UserId);
            ViewBag.user = user;
            ViewBag.UserId = id;
            return View("userinfo");
        }
        [HttpGet]
        [Route("postinfo/{UserId}")]
        public IActionResult PostInfo(int UserId)
        {
            var id = (HttpContext.Session.GetInt32("UserId") ?? 0);
            if ((HttpContext.Session.GetInt32("UserId") ?? 0) == 0) 
            {
                return RedirectToAction("Index");
            }
            Posts user = _context.posts.Include(c => c.createdby).Include(a => a.Likers).ThenInclude(u => u.user).SingleOrDefault(x => x.PostId == UserId);
            ViewBag.user = user;
            ViewBag.UserId = id;
            return View("postinfo");
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
           
        }
               public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
