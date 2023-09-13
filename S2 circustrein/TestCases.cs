using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_circustrein
{
    public class TestCases
    {
        readonly Animal Rabbit = new(Animal.SizeEnum.Small, false, "Rabbit");
        readonly Animal Weasel = new(Animal.SizeEnum.Small, true, "Weasel");
        readonly Animal Deer = new(Animal.SizeEnum.Medium, false, "Deer");
        readonly Animal Coyote = new(Animal.SizeEnum.Medium, true, "Coyote");
        readonly Animal Buffalo = new(Animal.SizeEnum.Large, false, "Buffalo");
        readonly Animal Lion = new(Animal.SizeEnum.Large, true, "Lion");

        private List<Animal> Randomize(List<Animal> case_to_test)
        {
            Random rand = new();
            return case_to_test.OrderBy(_ => rand.Next()).ToList();
        }

        public List<Animal> GetCase(int testCaseNumber)
        {
            List<Animal> selectedTestCase = testCaseNumber switch
            {
                0 => new List<Animal>(),
                1 => new List<Animal> { Buffalo, Buffalo, Deer, Deer, Deer, Weasel },
                2 => new List<Animal> { Buffalo, Deer, Deer, Rabbit, Rabbit, Rabbit, Rabbit, Rabbit, Weasel },
                3 => new List<Animal> { Buffalo, Lion, Deer, Coyote, Rabbit, Weasel },
                4 => new List<Animal> { Buffalo, Lion, Deer, Deer, Deer, Deer, Deer, Coyote, Rabbit, Weasel, Weasel },
                5 => new List<Animal> { Buffalo, Buffalo, Deer, Rabbit, Weasel },
                6 => new List<Animal> { Weasel, Deer, Deer, Buffalo, Buffalo, Buffalo, Weasel, Weasel },
                7 => new List<Animal> { Buffalo, Buffalo, Buffalo, Buffalo, Buffalo, Buffalo, Lion, Lion, Lion, Deer, Deer, Deer, Deer, Deer, Coyote, Coyote, Coyote, Weasel, Weasel, Weasel, Weasel, Weasel, Weasel, Weasel },
                _ => throw new ArgumentException("Invalid test case number"),
            };
            
            return Randomize(selectedTestCase);
        }

    }
}
