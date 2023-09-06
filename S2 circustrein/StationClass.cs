using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace S2_circustrein
{
    public class StationClass
    {
        public List<WagonClass> Train { get; private set; }

        public StationClass() { 
            Train = new List<WagonClass>();
        }

        public List<WagonClass> MakeTrain(List<AnimalClass> Animals)
        {
            Train = new List<WagonClass>();

            List<AnimalClass> SortedAnimals = Sort(Animals);
            foreach (AnimalClass Animal in SortedAnimals)
            {
                bool IsNotAdded = true;
                foreach (WagonClass Wagon in Train) { 
                    if (Wagon.CanAddAnimal(Animal) && IsNotAdded)
                    {
                        IsNotAdded = false;
                        Wagon.AddAnimal(Animal);
                    }
                }
                if (IsNotAdded)
                {
                    WagonClass NewWagon = new();
                    NewWagon.AddAnimal(Animal);
                    Train.Add(NewWagon);
                }
            }
            return Train;
        }

        private List<AnimalClass> Sort(List<AnimalClass> Animals)
        {
            List<AnimalClass> AnimalsSorted = Animals.OrderByDescending(animal => animal.Size).ToList();
            AnimalsSorted = AnimalsSorted.OrderByDescending(animal => animal.Carnivorous).ToList();

            return AnimalsSorted;
        }
    }
}
