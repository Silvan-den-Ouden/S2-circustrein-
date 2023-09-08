using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_circustrein
{
    public class Animal
    {
        public enum SizeEnum
        {
            Small = 1, Medium = 3, Large = 5
        }

        public SizeEnum Size { get;  set; }
        public bool Carnivorous { get;  set; }
        public string Name { get;  set; }

        public Animal(string _name) {
            Name = _name;
        }

        public Animal(SizeEnum _size, bool _carnivorous, string _name)
        {
            Size = _size;
            Carnivorous = _carnivorous;
            Name = _name;
        }

        public bool CanEat(Animal victim) {
            Animal aggressor = new(Size, Carnivorous, Name); 
            if (aggressor.Carnivorous && aggressor.Size >= victim.Size)
            {
                return true;
            }
            return false;
        }
    }
}