﻿using System;
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

            foreach (Animal passanger in passangers)
            {
                if (potentialPassanger.CanEat(passanger) || passanger.CanEat(potentialPassanger))
                {
                    return false;
                }
            }
            return true;
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
            foreach(Animal Passanger in passangers)
            {
                wagonSize += (int)Passanger.Size;
            }
            return wagonSize;
        }

        public void AddAnimal(Animal animal)
        {
            passangers.Add(animal);
        }
    }
}