using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_circustrein
{
    public class AnimalFactory
    {
        public static List<Animal> RandomAnimals(int min, int max)
        {
            Random r = new();
            List<Animal> animals = new();

            for (int i = 0; i < r.Next(min, max); i++)
            {
                animals.Add(RandomAnimal());
            }

            return animals;
        }

        public static Animal RandomAnimal()
        {
            Random r = new();
            Animal animal = new("randomAnimal");

            int i = r.Next(0, 2);
            switch (i)
            {
                case 0:
                    animal.Carnivorous = false;
                    break;
                case 1:
                    animal.Carnivorous = true;
                    break;
            }

            int j = r.Next(0, 3);
            switch (j)
            {
                case 0:
                    animal.Size = Animal.SizeEnum.Small; break;
                case 1:
                    animal.Size = Animal.SizeEnum.Medium; break;
                case 2:
                    animal.Size = Animal.SizeEnum.Large; break;
            }

            return animal;
        }

        public static Animal SmallHerbivore { get { return new Animal(Animal.SizeEnum.Small, false, "smallHerbivore"); } }
        public static Animal MediumHerbivore { get { return new Animal(Animal.SizeEnum.Medium, false, "mediumHerbivore"); } }
        public static Animal LargeHerbivore { get { return new Animal(Animal.SizeEnum.Large, false, "LargeHerbivore"); } }

        public static Animal SmallCarnivore { get { return new Animal(Animal.SizeEnum.Small, true, "smallCarnivore"); } }
        public static Animal MediumCarnivore { get { return new Animal(Animal.SizeEnum.Medium, true, "smallCarn"); } }
        public static Animal LargeCarnivore { get { return new Animal(Animal.SizeEnum.Large, true, "smallCarn"); } }
    }
}
