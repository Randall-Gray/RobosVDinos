using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Dinosaur
    {
        // Member variables
        public string type;
        public int health;
        public int energy;

        public DinoAttack attack;
        Random randomGenerator;     // Decides if attack is successful or not.

        // Constructor - created without an attack - Everything starts with same health and energy/powerLevel level.
        public Dinosaur(string type)
        {
            this.type = type;
            health = 100;
            energy = 100;

            randomGenerator = new Random();
        }

        // Member methods
        // Give Dinosaur a new (or first) attack.
        public void ChangeAttack(DinoAttack attack)
        {
            this.attack = attack;
        }
        // Dinosaur attacks passed in robot.
        public void DinosaurAttack(Robot robot)
        {
            int successful = randomGenerator.Next(0, 1);

         //   if (successful != 0)
            {
                robot.health -= attack.attackPower;
            }
        }

    }
}
