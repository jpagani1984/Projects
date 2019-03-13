using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using userlogin.Models;

namespace userlogin.Models
{
    public class User 
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public float wallet { get; set; }
        public List<Bid> bids { get; set; }
        public string password { get; set; }
        public User()
        {
            bids = new List<Bid>();
            wallet = 1000f;
        }

    }
    public class Register
    {
        [Required]
        [MinLength(3)]
        public string first_name {get; set; }
        [Required]
        [MinLength(3)]
        public string last_name {get; set; }
        [Required]
        [MinLength(3)]
        public string username {get; set; }
        [Required]
        [EmailAddress]
        public string email {get; set; }
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password {get; set; }
        [Required]
        [MinLength(8)]
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