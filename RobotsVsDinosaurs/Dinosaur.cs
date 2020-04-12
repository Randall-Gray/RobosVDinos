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
        public int energyExpenditure;

        public DinoAttack attack;

        // Constructor - created without an attack - Everything starts with same health and energy/powerLevel level.
        public Dinosaur(string type)
        {
            this.type = type;
            health = 100;
            energy = 100;
            energyExpenditure = 30;     // dinosaur can do about 3 attacks before it must rest.
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
            // Dead dinosaur can't atack.
            if (health <= 0)
                return;
            // Dinosaur must rest this round.
            if (energy < energyExpenditure)
            {
                energy = 100;       // Dinosuar is fully recovered
            }
            else    // Dinosaur attacks robot.
            {
                robot.health -= attack.attackPower;
                // Can't be more than dead.
                if (robot.health < 0)
                    robot.health = 0;
                energy -= energyExpenditure;
            }

        }

    }
}
