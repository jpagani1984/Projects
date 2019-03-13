using System;
namespace toons
{
    public class Warlock : Human
    {
        public Warlock(string person) : base(person)
        {
            intelect = 150;
            crit = 0;
            hp = 50;
        }
        public void DrainLife(Human target)
        {
            this.hp = hp + 10;
            target.hp -= 5;
        } 
    }

}
