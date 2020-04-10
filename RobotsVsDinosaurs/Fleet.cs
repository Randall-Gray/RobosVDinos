using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Fleet
    {
        // Member variables
        public List<Robot> Robots;

        // Constructor
        public Fleet()
        {
            Robots = new List<Robot>();
        }

        // Member methods
        public void AddRobot(Robot robot)
        {
            Robots.Add(robot);
        }
        public int FleetSize()
        {
            return Robots.Count;
        }
        public int FleetHealth()
        {
            int rtnHealth = 0;

            for (int i = 0; i<Robots.Count; i++)
            {
                rtnHealth += Robots[i].health;
            }

            return rtnHealth;
        }
    }
}
