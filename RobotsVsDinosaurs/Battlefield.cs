using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Battlefield
    {
        // Member variables
        public Fleet robotFleet;
        public Herd dinosaurHerd;
        public WeaponArsenal weaponArsenal;        // Robot weapons
        public AttackArsenal attackArsenal;        // Dinosaur attacks

        Random randomGenerator;    // Decides which dinosaur/robot attacks which dinosaur/robot. And which attacks first.

        // Constructor
        public Battlefield()
        {
            robotFleet = new Fleet();
            dinosaurHerd = new Herd();
            weaponArsenal = new WeaponArsenal();        // Fully stocked
            attackArsenal = new AttackArsenal();        // Fully stocked

            randomGenerator = new Random();
        }

        // Member methods
        public void AddRobot(string name)
        {
            Robot robot = new Robot(name);
            robot.ChangeWeapon(weaponArsenal.GetRandomWeapon());

            robotFleet.AddRobot(robot);
        }
        public void AddDinosaur(string type)
        {
            Dinosaur dinosaur = new Dinosaur(type);
            dinosaur.ChangeAttack(attackArsenal.GetRandomAttack());

            dinosaurHerd.AddDinosaur(dinosaur);
        }
        public void DoBattle()
        {
            int choosenRobot = 0;
            int choosenDinosaur = 0;
            int whoAttacksFirst = 0;

            while (robotFleet.FleetHealth() > 0 && dinosaurHerd.HerdHealth() > 0)
            {
                whoAttacksFirst = randomGenerator.Next(0, 100) % 2;
                choosenRobot = randomGenerator.Next(0, robotFleet.FleetSize() - 1);
                choosenDinosaur = randomGenerator.Next(0, dinosaurHerd.HerdSize() - 1);

//                Console.WriteLine(robotFleet.Robots[choosenRobot].name + " (" + robotFleet.Robots[choosenRobot].weapon.type + ") vs " + dinosaurHerd.Dinosaurs[choosenDinosaur].type + " (" + dinosaurHerd.Dinosaurs[choosenDinosaur].attack.type + ")");

                if (whoAttacksFirst == 0)         // Robot attacks first
                {
                    robotFleet.Robots[choosenRobot].RobotAttack(dinosaurHerd.Dinosaurs[choosenDinosaur]);
                    dinosaurHerd.Dinosaurs[choosenDinosaur].DinosaurAttack(robotFleet.Robots[choosenRobot]);
                }
                else         // Dinosaur attacks first
                {
                    dinosaurHerd.Dinosaurs[choosenDinosaur].DinosaurAttack(robotFleet.Robots[choosenRobot]);
                    robotFleet.Robots[choosenRobot].RobotAttack(dinosaurHerd.Dinosaurs[choosenDinosaur]);
                }
                // Remove the dead dinosaur from the battlefield.
                if (dinosaurHerd.Dinosaurs[choosenDinosaur].health <= 0)
                {
                    dinosaurHerd.RemoveDinosaur(choosenDinosaur);
                }
                else        // Dinosaur changes weapon.
                {
                    dinosaurHerd.Dinosaurs[choosenDinosaur].ChangeAttack(attackArsenal.GetRandomAttack());
                }
                // Remove the dead robot from the battlefield.
                if (robotFleet.Robots[choosenRobot].health <= 0)
                {
                    robotFleet.RemoveRobot(choosenRobot);
                }
                else        // Robot changes weapon.
                {
                    robotFleet.Robots[choosenRobot].ChangeWeapon(weaponArsenal.GetRandomWeapon());
                }
            }
        }
        public void ConsoleWriteStatus()
        {
            if (RobotsWon())
                Console.WriteLine("\nRobots Won!");
            else if (DinosaursWon())
                Console.WriteLine("\nDinosaurs Won!");
            else
                Console.WriteLine("\nRobot vs Dinosaur Battle is in progress!");

            Console.WriteLine("\nRobots on Battlefield: (Total Health: " + robotFleet.FleetHealth() + " )");
            if (robotFleet.FleetSize() == 0)
            {
                Console.WriteLine("All robots are dead!");
            }
            else
            {
                for (int i = 0; i < robotFleet.FleetSize(); i++)
                {
                    Console.WriteLine(robotFleet.Robots[i].name + "\t - Health: " + robotFleet.Robots[i].health + "\t PowerLevel: " + robotFleet.Robots[i].powerLevel + "\t Weapon: " + robotFleet.Robots[i].weapon.type);
                }
            }
            Console.WriteLine("\nDinosaurs on Battlefield: (Total Health: " + dinosaurHerd.HerdHealth() + " )");
            if (dinosaurHerd.HerdSize() == 0)
            {
                Console.WriteLine("All dinosaurs are dead!");
            }
            else
            {
                for (int i = 0; i < dinosaurHerd.HerdSize(); i++)
                {
                    Console.WriteLine(dinosaurHerd.Dinosaurs[i].type + "\t - Health: " + dinosaurHerd.Dinosaurs[i].health + "\t Energy: " + dinosaurHerd.Dinosaurs[i].energy + "\t Attack: " + dinosaurHerd.Dinosaurs[i].attack.type);
                }
            }
            Console.ReadLine();
        }
        public bool RobotsWon()
        {
            return (robotFleet.FleetHealth() > 0 && dinosaurHerd.HerdHealth() <= 0);
        }
        public bool DinosaursWon()
        {
            return (dinosaurHerd.HerdHealth() > 0 && robotFleet.FleetHealth() <= 0);
        }
    }
}
