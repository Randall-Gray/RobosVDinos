using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Weapon
    {
        // Member variables
        public string type;                // sword, gun, grenade, ...
        public int attackPower;            // amount of damage weapon does

        // Constructor
        public Weapon(string name, int power)
        {
            type = name;
            attackPower = power;
        }
        // Member methods
    }
}
