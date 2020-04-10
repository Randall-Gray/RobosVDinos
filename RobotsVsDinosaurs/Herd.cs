using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Herd
    {
        // Member variables
        public List<Dinosaur> Dinosaurs;

        // Constructor
        public Herd()
        {
            Dinosaurs = new List<Dinosaur>();
        }

        // Member methods
        public void AddDinosaur(Dinosaur dinosaur)
        {
            Dinosaurs.Add(dinosaur);
        }
        public int HerdSize()
        {
            return Dinosaurs.Count;
        }
        public int HerdHealth()
        {
            int rtnHealth = 0;

            for (int i = 0; i < Dinosaurs.Count; i++)
            {
                rtnHealth += Dinosaurs[i].health;
            }

            return rtnHealth;
        }
    }
}
