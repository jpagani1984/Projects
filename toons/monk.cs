using System;
namespace toons
{
    public class Monk : Human
    {
        public Monk(string person) : base(person)
        {
            agility = 150;
            crit = 0;
            hp = 200;

        }
        public void TouchOfDeath(Human target)
        {
            if(target.hp < 50)
            {
                target.hp = 0;
                System.Console.WriteLine(name + "got executed by Touch of Death" );
            }
        }
        public void effuse()
        {
            this.hp = 200;
        }
    }

}

