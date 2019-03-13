using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using userlogin.Models;

namespace userlogin.Models
{
    public class Posts
    {
        [Key]
        public int PostId {get; set; }
        public int UserId {get; set; }
        [Required]
        public DateTime time {get; set; }
        [Required]
        [MinLength(10)]
        public string posts {get; set; }
        public User createdby {get; set; }
        public List<Likes> Likers {get; set; }
        public int numlikers {get; set; } = 0;
        public DateTime date {get; set; }
        public Posts() 
        {
            Likers = new List<Likes>();
        }
    }
}