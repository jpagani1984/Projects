using System;
namespace toons
{
    class Program
    {
        static void Main(string[] args)
        {
            Warlock myWarlock = new Warlock("Warlock");
            Monk monk = new Monk("Monk");
            Rogue rogue = new Rogue("Rogue");
            myWarlock.Attack(monk);
            System.Console.WriteLine(myWarlock.name+ " - " +"Attack Power +" + myWarlock.attackpower + " - " +"Intelect +" + myWarlock.intelect + " - " +"Crit +" + myWarlock.crit + " - " +"Health +" + myWarlock.hp);
            System.Console.WriteLine("Your player was hit for " + myWarlock.attackpower + " Attack Power and now has " + monk.hp + " Health");
            myWarlock.Attack(monk);
            System.Console.WriteLine(myWarlock.name+ " - " +"Attack Power +" + myWarlock.attackpower + " - " +"Intelect +" + myWarlock.intelect + " - " +"Crit +" + myWarlock.crit + " - " +"Health +" + myWarlock.hp);
            System.Console.WriteLine("Your player was hit for " + myWarlock.attackpower + " Attack Power and now has " + monk.hp + " Health");
        }
    }
}
