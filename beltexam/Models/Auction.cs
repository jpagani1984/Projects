using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using userlogin.Models;

namespace userlogin.Models
{
    public class Auction
    {
        public int id { get; set; }
        [Required]
        [MinLength(3)]
        public string title {get; set; }
        [Required]
        [MinLength(10)]
        public string description { get; set; }
        public int creatorId { get; set; }
        public User creator { get; set; }
        public List<Bid> bids { get; set; }
        public DateTime expiration { get; set; }
        public Auction() 
        {
            bids = new List<Bid>();
        }
    }
}
        