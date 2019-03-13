using System;
namespace toons
{
    public class Rogue : Human
    {
        public Rogue(string person) : base(person)
        {
            agility = 200;
            crit = 0;
            hp = 100;
        }
        public void Disarm()
        {
            this.hp = hp + 5;
        }
    }

}
