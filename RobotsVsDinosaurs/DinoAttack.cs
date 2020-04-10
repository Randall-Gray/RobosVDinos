using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class DinoAttack
    {
        // Member variables
        public string type;                // slash, stomp, bite, ...
        public int attackPower;            // amount of damage attack does

        // Constructor
        public DinoAttack(string type, int power)
        {
            this.type = type;
            attackPower = power;
        }
        // Member methods
    }
}
