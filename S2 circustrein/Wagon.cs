using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_circustrein
{
    public class Wagon
    {
        private readonly int maxSize = 10;
        public List<Animal> passangers { get; private set; }

        public Wagon()
        {
            passangers = new List<Animal>();
        }

        public bool CanAddAnimal(Animal potentialPassanger)
        {
            if (!AnimalFits(potentialPassanger))
            {
                return false;
            }
            if(WillEatEachother(potentialPassanger))
            {
                return false;
            }
            return true;
        }
        public void AddAnimal(Animal animal)
        {
            if (CanAddAnimal(animal))
            {
                passangers.Add(animal);
            }
        }

        private bool WillEatEachother(Animal potentialPassanger)
        {
            foreach (Animal passanger in passangers)
            {
                if (potentialPassanger.CanEat(passanger) || passanger.CanEat(potentialPassanger))
                {
                    return true;
                }
            }
            return false;
        }

        private bool AnimalFits(Animal potentialMatchAnimal)
        {
            if ((int)potentialMatchAnimal.Size + GetCurrentSize() > maxSize)
            {
                return false;
            }
            return true;
        }

        private int GetCurrentSize()
        {
            int wagonSize = 0;
            foreach(Animal passanger in passangers)
            {
                wagonSize += (int)passanger.Size;
            }
            return wagonSize;
        }
    }
}