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

        public Weapon weapon;
        Random randomGenerator;    // Decides if attack is successful or not.

        // Constructor - created without a weapon - Everything starts with same health and energy/powerLevel level.
        public Robot(string name)
        {
            this.name = name;
            health = 100;
            powerLevel = 100;

            randomGenerator = new Random();
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
            int successful = randomGenerator.Next(0, 1);

          //  if (successful != 0)
            {
                dinosaur.health -= weapon.attackPower;
            }
        }
    }
}
