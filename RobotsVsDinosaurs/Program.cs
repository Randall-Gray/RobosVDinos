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
            
            // Add the fighters!!
            battlefield.AddRobot("Tom");
            battlefield.AddRobot("Dick");
            battlefield.AddRobot("Harry");

            battlefield.AddDinosaur("Tyrannosaurus Rex");
            battlefield.AddDinosaur("Triceratops");
            battlefield.AddDinosaur("Stegosaurus");

            battlefield.ConsoleWriteStatus();       // Pre-battle status

            battlefield.DoBattle();

            battlefield.ConsoleWriteStatus();       // Post-battle status
        }
    }
}
