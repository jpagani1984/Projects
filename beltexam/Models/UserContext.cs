using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace userlogin.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Auction> auctions { get; set; }
        public DbSet<Bid> bids { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
    }
}