using System;
using System.ComponentModel.DataAnnotations;
using userlogin.Models;

namespace userlogin.Models
{
    public class Bid
    {
        public int id {get; set; }
        public float amount { get; set; }
        public int auctionId {get; set;}
        public Auction auction { get; set; }
        public int creatorId { get; set; }
        public User creator { get; set; }
        public DateTime created_at { get; set; }

        public Bid() {
            created_at = DateTime.Now;
        }
    }
}