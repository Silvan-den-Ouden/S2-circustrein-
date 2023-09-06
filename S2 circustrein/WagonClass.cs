using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_circustrein
{
    public class WagonClass
    {
        private readonly int MaxSize = 10;
        public List<AnimalClass> Passangers { get; private set; }

        public WagonClass()
        {
            Passangers = new List<AnimalClass>();
        }

        public bool CanAddAnimal(AnimalClass PotentialPassanger)
        {
            if (!AnimalFits(PotentialPassanger))
            {
                return false;
            }

            foreach (AnimalClass Passanger in Passangers)
            {
                if (PotentialPassanger.CanEat(Passanger) || Passanger.CanEat(PotentialPassanger))
                {
                    return false;
                }
            }
            return true;
        }

        private bool AnimalFits(AnimalClass PotentialMatchAnimal)
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
            foreach(AnimalClass Passanger in Passangers)
            {
                wagonSize += (int)Passanger.Size;
            }
            return wagonSize;
        }

        public void AddAnimal(AnimalClass Animal)
        {
            Passangers.Add(Animal);
        }
    }
}
