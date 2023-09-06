using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_circustrein
{
    public class Wagon
    {
        private readonly int MaxSize = 10;
        public List<Animal> Passangers { get; private set; }

        public Wagon()
        {
            Passangers = new List<Animal>();
        }

        public bool CanAddAnimal(Animal PotentialPassanger)
        {
            if (!AnimalFits(PotentialPassanger))
            {
                return false;
            }

            foreach (Animal Passanger in Passangers)
            {
                if (PotentialPassanger.CanEat(Passanger) || Passanger.CanEat(PotentialPassanger))
                {
                    return false;
                }
            }
            return true;
        }

        private bool AnimalFits(Animal PotentialMatchAnimal)
        {
            if ((int)PotentialMatchAnimal.Size + GetCurrentSize() > MaxSize)
            {
                return false;
            }
            return true;
        }

        private int GetCurrentSize()
        {
            int wagonSize = 0;
            foreach(Animal Passanger in Passangers)
            {
                wagonSize += (int)Passanger.Size;
            }
            return wagonSize;
        }

        public void AddAnimal(Animal Animal)
        {
            Passangers.Add(Animal);
        }
    }
}
