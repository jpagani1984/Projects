using System;
using System.ComponentModel.DataAnnotations;
namespace portfolio2.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Number {get; set; }
    }
    public class Members
    {
        public string members {get; set; }
    }
    public class Choice
    {
        public string name {get; set; }
        public string board {get; set; }
        public string bike {get; set; }
    }
    public class Info
    {
        [Required]
        [MinLength(3)]
        public string fullname {get; set; }
        [Required]
        [EmailAddress]
        public string email {get; set; }
        [Required]
        [MinLength(3)]
        public string message {get; set; }
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
        public string username {get; set; }
        [Required]
        [EmailAddress]
        public string email1 {get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password {get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string confpassword {get; set; }
    }
    public class Stats
    {
        public string name;
        public int fullness {get; set; }
        public int happiness {get; set; }
        public int meals {get; set; }
        public int energy {get; set; }
        public Stats(string player)
        {
            
            fullness = 20;
            happiness = 20;
            meals = 3;
            energy = 50;
            
        }

        public Stats(string player, int happiness, int fullness, int meal, int energy)
        {
            name = player;
            this.fullness = fullness;
            this.happiness = happiness;
            this.meals = meals;
            this.energy = energy;
        }
        public void Feed()
        {
            Random food = new Random();
            int f = food.Next(5, 10);
            f = f + this.fullness;
            meals = meals -= 1; 
        }
        public void Play()
        {
            this.happiness = this.happiness + 5;
            this.fullness = this.fullness - 1;
            this.energy = this.energy - 2;
        }
        public void Work()
        {
          this.happiness = this.happiness - 2;
          this.energy = this.energy - 3;
          this.fullness = this.fullness - 2; 
        }
        public void Sleep()
        {
            this.happiness = this.happiness + 10;
            this.energy = this.energy + 5;
            this.fullness = this.fullness - 3;
        }
    }
}