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
        public void RemoveDinosaur(int indexDinosaur)           // Dead Dinosaurs are removed from the Herd.
        {
            if (indexDinosaur < Dinosaurs.Count)
                Dinosaurs.RemoveAt(indexDinosaur);
        }
        public int HerdSize()
        {
            return Dinosaurs.Count;
        }
        // Total health of all dinosaurs in Herd.
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
