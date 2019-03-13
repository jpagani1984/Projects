using System;
namespace toons
{
    public class Human
    {
        public string name;
        
        bool hit = false;
        bool attack = false;
        public int hp { get; set; }
        public int attackpower { get; set; }
        public int intelect { get; set; }
        public int agility { get; set; }
        public int crit { get; set; }
        public Human(string person)
        {
            name = person;
            attackpower = 3;
            intelect = 3;
            agility = 3;
            crit = 0;
            hp = 100;
        }
        public Human(string person, int attackpower, int intelect, int agility, int crit, int hp)
        {
            name = person;
            this.attackpower = attackpower;
            this.intelect = intelect;
            this.agility = agility;
            this.crit = crit;
            this.hp = hp;
        }
        public void Attack(Human name)
        {
            Crit();
            System.Console.WriteLine("Crit Roll - " + crit);
            if(crit > 50)
            {
                this.attackpower = this.attackpower * 10;
                hit = true;
                this.Hit(name);

            }
            else
            {
                this.attackpower = this.attackpower * 5;
                hit = true;
                this.Hit(name);
            }
        }
        public void Hit(Human target)
        {
            target.hp -= this.attackpower;
        }
        public void Crit()
        {
            Random roll = new Random();
            int c = roll.Next(1, 100);
            crit = c; 
        }
        
    }
}