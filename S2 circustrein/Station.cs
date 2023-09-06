using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace S2_circustrein
{
    public class Station
    {
        public List<Wagon> wagons { get; private set; }

        public Station() { 
            wagons = new List<Wagon>();
        }

        public List<Wagon> MakeTrain(List<Animal> animals)
        {
            wagons = new List<Wagon>();
            List<Animal> sortedAnimals = Sort(animals);
            
            foreach (Animal animal in sortedAnimals)
            {
                bool IsNotAdded = true;
                foreach (Wagon wagon in wagons) { 
                    if (wagon.CanAddAnimal(animal) && IsNotAdded)
                    {
                        IsNotAdded = false;
                        wagon.AddAnimal(animal);
                    }
                }
                if (IsNotAdded)
                {
                    CreateWagonWithAnimalInIt(animal);
                }
            }
            return wagons;
        }

        public void CreateWagonWithAnimalInIt(Animal animal)
        {
            Wagon newWagon = new();
            newWagon.AddAnimal(animal);
            wagons.Add(newWagon);
        }

        private List<Animal> Sort(List<Animal> animals)
        {
            List<Animal> animalsSorted = animals.OrderByDescending(animal => animal.Size).ToList();
            animalsSorted = animalsSorted.OrderByDescending(animal => animal.Carnivorous).ToList();

            return animalsSorted;
        }
    }
}
