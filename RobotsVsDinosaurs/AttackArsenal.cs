using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class AttackArsenal
    {
        // Member variables
        public List<DinoAttack> availableAttacks;

        Random randomGenerator;     // Chooses a random attack from the arsenal.

        // Constructor
        public AttackArsenal()
        {
            availableAttacks = new List<DinoAttack>();

            AddDinoAttack("tail swipe", 20);
            AddDinoAttack("slash", 25);
            AddDinoAttack("stomp", 50);
            AddDinoAttack("bite", 80);
            AddDinoAttack("puke", 5);
            AddDinoAttack("laugh", 0);

            randomGenerator = new Random();
        }

        // Member methods
        // Add a new dinosaur attack to the Arsenal.
        public void AddDinoAttack(string type, int power)
        {
            DinoAttack attack = new DinoAttack(type, power);

            availableAttacks.Add(attack);
        }
        // Get an attack from the Arsenal.  Request by type.  If requested attack doesn't exist, get a NULL attack.
        public DinoAttack GetDinoAttack(string type)
        {
            DinoAttack rtnAttack = new DinoAttack("", 0);

            for (int i = 0; i < availableAttacks.Count; i++)
            {
                if (availableAttacks[i].type == type)
                    rtnAttack = availableAttacks[i];
            }
            return rtnAttack;
        }
        // Get a random attack from the Arsenal.
        public DinoAttack GetRandomAttack()
        {
            int choosenAttack = randomGenerator.Next(0, availableAttacks.Count - 1);

            return availableAttacks[choosenAttack];
        }
    }
}
