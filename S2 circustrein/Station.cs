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

        public List<Wagon> MakeTrain(List<Animal> animals)
        {
            wagons = new List<Wagon>();
            List<Animal> sortedAnimals = Sort(animals);
            AddAnimalsToTrain(sortedAnimals);
           
            return wagons;
        }

        private void AddAnimalsToTrain(List<Animal> animals)
        {
            foreach (Animal animal in animals)
            {
                if ((int)animal.Size == 1 && animal.Carnivorous)
                {
                    animals = SmallCarnivoreAdded(animal, animals);
                }
                else
                {
                    bool IsNotAdded = true;
                    foreach (Wagon wagon in wagons)
                    {
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
            }
        }

        private List<Animal> SmallCarnivoreAdded(Animal animal, List<Animal> animals)
        {
            CreateWagonWithAnimalInIt(animal);
            Wagon wagon = wagons.Last();
            Animal Deer = new(Animal.SizeEnum.Medium, false, "Deer");
            Animal Buffalo = new(Animal.SizeEnum.Large, false, "Buffalo");


            if (CanFindThreeMedHerbs(animals))
            {
                for (int i = 0; i < 3; i++)
                {
                    wagon.AddAnimal(Deer);
                    animals.Remove(Deer);
                }
            } else if (CanFindLargeAndMedHerb(animals))
            {
                wagon.AddAnimal(Deer);
                animals.Remove(Deer);
                wagon.AddAnimal(Buffalo);
                animals.Remove(Buffalo);
            } 

            List<Animal> remainingAnimals = animals;
            return remainingAnimals;
        }

        private bool CanFindThreeMedHerbs(List<Animal> animals)
        {
            int mediumHerbCount = 0;
            foreach(Animal animal in animals)
            {
                if((int)animal.Size == 3 && animal.Carnivorous == false)
                {
                    mediumHerbCount++;
                }
            }

            if (mediumHerbCount >= 3)
            {
                return true;
            }

            return false;
        }

        private bool CanFindLargeAndMedHerb(List<Animal> animals)
        {
            bool foundMedHerb = false;
            bool foundLargeHerb = false;

            foreach (Animal animal in animals)
            {
                if (!animal.Carnivorous)
                {
                    if ((int)animal.Size == 3)
                    {
                        foundMedHerb = true;
                    }
                    if ((int)animal.Size == 5)
                    {
                        foundLargeHerb = true;
                    }
                }
            }

            if(foundMedHerb && foundLargeHerb)
            {
                return true;
            }

            return false;
        }

        private void CreateWagonWithAnimalInIt(Animal animal)
        {
            Wagon newWagon = new();
            newWagon.AddAnimal(animal);
            wagons.Add(newWagon);
        }

        private List<Animal> Sort(List<Animal> animals)
        {
            List<Animal> animalsSorted = animals.OrderBy(animal => animal.Size).ToList();
            animalsSorted = animalsSorted.OrderByDescending(animal => animal.Carnivorous).ToList();

            return animalsSorted;
        }
    }
}
