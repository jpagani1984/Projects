using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using userlogin.Models;

namespace userlogin.Models
{
    public class User 
    {
        public int UserId {get; set; }
        
        public string firstname {get; set; }
        public string lastname {get; set; }
        public string alias {get; set; }
        public string email {get; set; }
        public List<Likes> Creater {get; set; }
        public List<Posts> AllPosts {get; set; }
        public string password {get; set; }
        public User()
        {
            Creater = new List<Likes>();
            AllPosts = new List<Posts>();
        }

    }
    public class Register
    {
        [Required]
        [MinLength(3)]
        public string firstname {get; set; }
        [Required]
        [MinLength(3)]
        public string lastname {get; set; }
        [Required]
        [MinLength(3)]
        public string alias {get; set; }
        [Required]
        [EmailAddress]
        public string email {get; set; }
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password {get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string confpassword {get; set; }
    }
    public class Login
    {
        [Required]
        [MinLength(3)]
        public string username {get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password {get; set; }

    }
}
