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
        public Fleet Robots;
        public Herd Dinosaurs;

        Random randomGenerator;    // Decides which dinosaur/robot attacks which dinosaur/robot.

        // Constructor
        public Battlefield()
        {
            Robots = new Fleet();
            Dinosaurs = new Herd();

            randomGenerator = new Random();
        }

        // Member methods
        public void AddRobot(string name, Weapon weapon)
        {
            Robot robot = new Robot(name);
            robot.ChangeWeapon(weapon);

            Robots.AddRobot(robot);
        }
        public void AddDinosaur(string type, DinoAttack attack)
        {
            Dinosaur dinosaur = new Dinosaur(type);
            dinosaur.ChangeAttack(attack);
            Dinosaurs.AddDinosaur(dinosaur);
        }
        public void DoBattle()
        {
            int choosenRobot = 0;
            int choosenDinosaur = 0;

            while (Robots.FleetHealth() > 0 && Dinosaurs.HerdHealth() > 0)
            {
                choosenRobot = randomGenerator.Next(0, Robots.FleetSize()-1);
                choosenDinosaur = randomGenerator.Next(0, Dinosaurs.HerdSize() - 1);

                Robots.Robots[choosenRobot].RobotAttack(Dinosaurs.Dinosaurs[choosenDinosaur]);
                Dinosaurs.Dinosaurs[choosenDinosaur].DinosaurAttack(Robots.Robots[choosenRobot]);
            }
        }
        public void ConsoleWriteStatus()
        {
            if (RobotsWon())
                Console.WriteLine("Robots Won!");
            else if (DinosaursWon())
                Console.WriteLine("Dinosaurs Won!");
            else
                Console.WriteLine("Robot vs Dinosaur Battle has not started!");

            Console.WriteLine("\nRobots on Battlefield: (Total Health: " + Robots.FleetHealth() + " )");
            for (int i=0; i<Robots.FleetSize(); i++)
            {
                Console.WriteLine(Robots.Robots[i].name + "\t - Health: " + Robots.Robots[i].health + "\t PowerLevel: " + Robots.Robots[i].powerLevel + "\t Weapon: " + Robots.Robots[i].weapon.type);
            }
            Console.WriteLine("\nDinosaurs on Battlefield: (Total Health: " + Dinosaurs.HerdHealth() + " )");
            for (int i = 0; i < Dinosaurs.HerdSize(); i++)
            {
                Console.WriteLine(Dinosaurs.Dinosaurs[i].type + "\t - Health: " + Dinosaurs.Dinosaurs[i].health + "\t Energy: " + Dinosaurs.Dinosaurs[i].energy + "\t Attack: " + Dinosaurs.Dinosaurs[i].attack.type);
            }
            Console.ReadLine();
        }
        public bool RobotsWon()
        {
            return (Robots.FleetHealth() > 0 && Dinosaurs.HerdHealth() <= 0);
        }
        public bool DinosaursWon()
        {
            return (Dinosaurs.HerdHealth() > 0 && Robots.FleetHealth() <= 0);
        }
    }
}
