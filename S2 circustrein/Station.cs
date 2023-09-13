using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_circustrein
{
    public class Station
    {
        public List<Wagon> wagons { get; private set; }

        public Station() { 
            wagons = new List<Wagon>();
        }

        public void MakeTrain(List<Animal> animals)
        {
            List<Animal> sortedAnimalsDesc = Sort(animals, false);
            List<Animal> sortedAnimalsAsc = Sort(animals, true);
            if (AddAnimalsToTrain(sortedAnimalsDesc) <= AddAnimalsToTrain(sortedAnimalsAsc))
            {
                AddAnimalsToTrain(sortedAnimalsDesc);
            }
            //else
            //{
            //    AddAnimalsToTrain(sortedAnimalsAsc);
            //}
        }

        private int AddAnimalsToTrain(List<Animal> animals)
        {
            wagons.Clear();
            foreach (Animal animal in animals)
            {
                bool IsNotAdded = true;
                foreach (Wagon wagon in wagons)
                {
                    if (wagon.CanAddAnimal(animal) && IsNotAdded)
                    {
                        wagon.AddAnimal(animal);
                        IsNotAdded = false;
                    }
                }
                if (IsNotAdded)
                {
                    CreateWagonWithAnimalInIt(animal);
                }
            }
            return wagons.Count;
        }

        private void CreateWagonWithAnimalInIt(Animal animal)
        {
            Wagon newWagon = new();
            newWagon.AddAnimal(animal);
            wagons.Add(newWagon);
        }

        private List<Animal> Sort(List<Animal> animals, bool Ascending)
        {
            List<Animal> animalsSorted = new();
            if (Ascending)
            {
                animalsSorted = animals.OrderBy(animal => animal.Size).ToList();
            } else
            {
                animalsSorted = animals.OrderByDescending(animal => animal.Size).ToList();
            }
            animalsSorted = animalsSorted.OrderByDescending(animal => animal.Carnivorous).ToList();
            return animalsSorted;
        }
    }
}
