using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Robot
    {
        // Member variables
        public string name;
        public int health;
        public int powerLevel;
        public int powerExpenditure;        // power spent for each attack

        public Weapon weapon;

        // Constructor - created without a weapon - Everything starts with same health and energy/powerLevel level.
        public Robot(string name)
        {
            this.name = name;
            health = 100;
            powerLevel = 100;
            powerExpenditure = 5;       // robot can do about 20 attacks before it must rest.
        }

        // Member methods
        // Give Robot a new (or first) weapon.
        public void ChangeWeapon(Weapon weapon)
        {
            this.weapon = weapon;
        }
        // Robot attacks passed in dinosaur.
        public void RobotAttack(Dinosaur dinosaur)
        {
            // Dead robot can't atack.
            if (health <= 0)
                return;
            // Robot must rest this round.
            if (powerLevel < powerExpenditure)
            {
                powerLevel = 100;       // Robot is fully recovered
                Console.WriteLine(name + " must rest.");
            }
            else    // Robot attacks dinosaur.
            {
                dinosaur.health -= weapon.attackPower;
                Console.WriteLine(name + " (" + weapon.type + ") attacked " + dinosaur.type + " (" + dinosaur.attack.type + ")");
                // Can't be more than dead.
                if (dinosaur.health <= 0)
                {
                    dinosaur.health = 0;
                    Console.WriteLine(dinosaur.type + " is dead.");
                }
                powerLevel -= powerExpenditure;
            }
        }
    }
}
