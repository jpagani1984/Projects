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

        public DateTime CountDown { get; private set; }

        public HomeController(UserContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route ("/index")]
         public IActionResult Register(Register reg)
        {
            if(ModelState.IsValid)
            {
                var users = _context.users.Where(x => x.email == reg.email).ToList();
                if (users.Count == 0) 
                {
                    User NewUser = new User
                    {
                        first_name = reg.first_name,
                        last_name = reg.last_name,
                        username = reg.username,
                        email = reg.email,
                        password = reg.password,
                    };
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    NewUser.password = Hasher.HashPassword(NewUser,NewUser.password);
                    _context.Add(NewUser);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("UserId", NewUser.id);
                    return RedirectToAction("Home");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public IActionResult LoginMethod(string username, string password)
        {
            
            var user = _context.users.SingleOrDefault(x => x.username == username);
            if(user != null && password != null)
            {
                var Hasher = new PasswordHasher<User>();
                
                if(0 != Hasher.VerifyHashedPassword(user, user.password, password))
                {   
                    HttpContext.Session.SetInt32("UserId", user.id);
                    return RedirectToAction("Home");
                }
            }
            return View("Index");
        }
        [HttpGet]
        [Route ("/")]
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpGet]
        [Route("New")]
        public IActionResult New()
        {
            if ((HttpContext.Session.GetInt32("UserId") ?? 0) == 0) 
            {
                return RedirectToAction("Index");
            }
            return View("New");
        }
        [HttpGet]
        [Route("auctions/{auction_id}")]
        public IActionResult Auction(int auction_id)
        {
            var id = (HttpContext.Session.GetInt32("UserId") ?? 0);
            if ((HttpContext.Session.GetInt32("UserId") ?? 0) == 0) 
            {
                return RedirectToAction("Index");
            }
            var auction = _context.auctions.Where(x => x.id == auction_id).Include(x => x.creator).Include(x => x.bids).Single();
            ViewBag.creator = auction.creator;
            ViewBag.UserId = id;
            ViewBag.auction = auction;
            
            ViewBag.top_bid = _context.bids.Where(x => x.auctionId == auction_id).OrderByDescending(x => x.amount).FirstOrDefault();

            return View("auction");
        }
        [HttpGet]
        [Route("Home")]
        public IActionResult Home(DateTime enddate)
        {
            var id = (HttpContext.Session.GetInt32("UserId") ?? 0);
            if (id == 0) 
            {
                return RedirectToAction("Index");
            }
            DateTime startDate = DateTime.Now;
            TimeSpan CountDown = enddate - startDate;
            var user = _context.users.Where(x => x.id == id).First();
            var auction = _context.auctions.Include(c => c.creator).Include(x => x.bids).OrderByDescending(x => x.expiration).ToList();
            
            var user_bids = _context.bids.Where(x => x.creatorId == id).ToList();
            var sum = user.wallet;
            foreach(var bid in user_bids) {
                sum -= bid.amount;
            }

            ViewBag.balance = sum;
            ViewBag.auction = auction;
            ViewBag.user = user;
            ViewBag.UserId = id;
            return View("Home"); 
        
        }
        [HttpPost]
        public IActionResult Create(string title, float bid, string description, DateTime enddate, DateTime time)
        { 
            int createrid = (int)HttpContext.Session.GetInt32("UserId");
            Auction NewAuction = new Auction
            {
                creatorId = createrid,
                title = title,
                description = description,
                expiration = enddate,
            };
            _context.Add(NewAuction);
            _context.SaveChanges();
            return RedirectToAction("Home");
        }

        [HttpPost]
        [Route("auctions/{auction_id}/bids/new")]
        public IActionResult Bid(int auction_id, float deposit)
        {
            var id = HttpContext.Session.GetInt32("UserId") ?? 0;
            if (id != 0) 
            {
                var bid = new Bid 
                {
                    amount = deposit,
                    creatorId = id,
                    auctionId = auction_id
                };
                _context.bids.Add(bid);
                _context.SaveChanges();
            }
            return RedirectToAction("Home"); 
        }
        [HttpGet]
        [Route("delete/{AuctionId}")]
        public IActionResult Delete(int AuctionId)
        {
            var id = (HttpContext.Session.GetInt32("UserId") ?? 0);
            var remove = _context.auctions.SingleOrDefault(t => t.id == AuctionId);
            if(remove.creatorId == id)
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
