using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class WeaponArsenal
    {
        // Member variables
        public List<Weapon> availableWeapons;

        Random randomGenerator;         // Chooses a random weapon from the arsenal.

        // Constructor
        public WeaponArsenal()
        {
            availableWeapons = new List<Weapon>();

            AddWeapon("sword", 10);
            AddWeapon("gun", 20);
            AddWeapon("grenade launcher", 70);
            AddWeapon("flamethrower", 50);
            AddWeapon("knife", 4);
            AddWeapon("punch", 1);

            randomGenerator = new Random();
        }

        // Member methods
        // Add a new weapon to the Arsenal.
        public void AddWeapon(string name, int power)
        {
            Weapon weapon = new Weapon(name, power);

            availableWeapons.Add(weapon);
        }
        // Get a weapon from the Arsenal.  Request by name.  If requested weapon doesn't exist, get a NULL weapon.
        public Weapon GetWeapon(string type)
        {
            Weapon rtnWeapon = new Weapon("", 0);

            for (int i = 0; i < availableWeapons.Count; i++)
            {
                if (availableWeapons[i].type == type)
                    rtnWeapon = availableWeapons[i];
            }
            return rtnWeapon;
        }
        // Get a random weapon from the Arsenal.
        public Weapon GetRandomWeapon()
        {
            int choosenWeapon = randomGenerator.Next(0, availableWeapons.Count - 1);

            return availableWeapons[choosenWeapon];
        }
    }
}
