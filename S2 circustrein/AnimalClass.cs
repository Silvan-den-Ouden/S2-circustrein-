﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_circustrein
{
    public class AnimalClass
    {
        public enum SizeEnum
        {
            Small = 1, Medium = 3, Large = 5
        }

        public SizeEnum Size { get; private set; }
        public bool Carnivorous { get; private set; }
        public string Name { get; private set; }


        public AnimalClass(SizeEnum _size, bool _carnivorous, string _name)
        {
            Size = _size;
            Carnivorous = _carnivorous;
            Name = _name;
        }

        public bool CanEat(AnimalClass _victim) {
            AnimalClass _aggressor = new(Size, Carnivorous, Name); 
            if (_aggressor.Carnivorous && _aggressor.Size >= _victim.Size)
            {
                return true;
            }
            return false;
        }
    }
}