using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Program
    {
        static void Main(string[] args)
        {
            Battlefield battlefield = new Battlefield();
            WeaponArsenal weaponArsenal = new WeaponArsenal();
            AttackArsenal attackArsenal = new AttackArsenal();
            
            // Add the fighters!!
            battlefield.AddRobot("Tom", weaponArsenal.GetRandomWeapon());
            battlefield.AddRobot("Dick", weaponArsenal.GetRandomWeapon());
            battlefield.AddRobot("Harry", weaponArsenal.GetRandomWeapon());

            battlefield.AddDinosaur("Tyrannosaurus Rex", attackArsenal.GetRandomAttack());
            battlefield.AddDinosaur("Triceratops", attackArsenal.GetRandomAttack());
            battlefield.AddDinosaur("Stegosaurus", attackArsenal.GetRandomAttack());

            battlefield.ConsoleWriteStatus();

            battlefield.DoBattle();

            battlefield.ConsoleWriteStatus();
        }
    }
}
