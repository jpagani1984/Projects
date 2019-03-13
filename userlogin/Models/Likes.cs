using System;
using System.ComponentModel.DataAnnotations;
using userlogin.Models;

namespace userlogin.Models
{
    public class Likes
    {
        [Key]
        public int JoinerId{get; set; }
        public DateTime UpdatedAt {get; set; } = DateTime.Now;
        public int PostId {get; set; }
        public int UserId {get; set; }
        public User user {get; set; }
        public Likes likes{get; set; }

    }
}