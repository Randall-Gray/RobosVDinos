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

        Random randomGenerator;    // Decides which dinosaur/robot attacks which dinosaur/robot. And which attacks first.

        // Constructor
        public Battlefield()
        {
            robotFleet = new Fleet();
            dinosaurHerd = new Herd();

            randomGenerator = new Random();
        }

        // Member methods
        public void AddRobot(string name, Weapon weapon)
        {
            Robot robot = new Robot(name);
            robot.ChangeWeapon(weapon);

            robotFleet.AddRobot(robot);
        }
        public void AddDinosaur(string type, DinoAttack attack)
        {
            Dinosaur dinosaur = new Dinosaur(type);
            dinosaur.ChangeAttack(attack);

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
                // Remove the dead dinosaur/robot from the battlefield.
                if (dinosaurHerd.Dinosaurs[choosenDinosaur].health <= 0)
                {
                    dinosaurHerd.RemoveDinosaur(choosenDinosaur);
                }
                if (robotFleet.Robots[choosenRobot].health <= 0)
                {
                    robotFleet.RemoveRobot(choosenRobot);
                }
            }
        }
        public void ConsoleWriteStatus()
        {
            if (RobotsWon())
                Console.WriteLine("Robots Won!");
            else if (DinosaursWon())
                Console.WriteLine("Dinosaurs Won!");
            else
                Console.WriteLine("Robot vs Dinosaur Battle is in progress!");

            Console.WriteLine("\nRobots on Battlefield: (Total Health: " + robotFleet.FleetHealth() + " )");
            for (int i=0; i<robotFleet.FleetSize(); i++)
            {
                Console.WriteLine(robotFleet.Robots[i].name + "\t - Health: " + robotFleet.Robots[i].health + "\t PowerLevel: " + robotFleet.Robots[i].powerLevel + "\t Weapon: " + robotFleet.Robots[i].weapon.type);
            }
            Console.WriteLine("\nDinosaurs on Battlefield: (Total Health: " + dinosaurHerd.HerdHealth() + " )");
            for (int i = 0; i < dinosaurHerd.HerdSize(); i++)
            {
                Console.WriteLine(dinosaurHerd.Dinosaurs[i].type + "\t - Health: " + dinosaurHerd.Dinosaurs[i].health + "\t Energy: " + dinosaurHerd.Dinosaurs[i].energy + "\t Attack: " + dinosaurHerd.Dinosaurs[i].attack.type);
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
