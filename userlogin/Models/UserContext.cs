using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

 
namespace userlogin.Models
{
    public class UserContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<User> users { get; set; }
         public DbSet<Posts> posts {get; set; }
         public DbSet<Likes> likers {get; set; }
        public object HttpContext { get; internal set; }
    }
}