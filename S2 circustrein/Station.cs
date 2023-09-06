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
        public List<Wagon> Train { get; private set; }

        public Station() { 
            Train = new List<Wagon>();
        }

        public List<Wagon> MakeTrain(List<Animal> Animals)
        {
            Train = new List<Wagon>();

            List<Animal> SortedAnimals = Sort(Animals);
            foreach (Animal Animal in SortedAnimals)
            {
                bool IsNotAdded = true;
                foreach (Wagon Wagon in Train) { 
                    if (Wagon.CanAddAnimal(Animal) && IsNotAdded)
                    {
                        IsNotAdded = false;
                        Wagon.AddAnimal(Animal);
                    }
                }
                if (IsNotAdded)
                {
                    Wagon NewWagon = new();
                    NewWagon.AddAnimal(Animal);
                    Train.Add(NewWagon);
                }
            }
            return Train;
        }

        private List<Animal> Sort(List<Animal> Animals)
        {
            List<Animal> AnimalsSorted = Animals.OrderByDescending(animal => animal.Size).ToList();
            AnimalsSorted = AnimalsSorted.OrderByDescending(animal => animal.Carnivorous).ToList();

            return AnimalsSorted;
        }
    }
}
