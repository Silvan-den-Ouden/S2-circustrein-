// See https://aka.ms/new-console-template for more information
using System.Transactions;
using S2_circustrein;

Animal Rabbit  = new(Animal.SizeEnum.Small, false, "Rabbit");
Animal Weasel  = new(Animal.SizeEnum.Small, true, "Weasel");
Animal Deer    = new(Animal.SizeEnum.Medium, false, "Deer");
Animal Coyote  = new(Animal.SizeEnum.Medium, true, "Coyote");
Animal Buffalo = new(Animal.SizeEnum.Large, false, "Buffalo");
Animal Lion    = new(Animal.SizeEnum.Large, true, "Lion");

List<Animal> test_case_1 = new() { Buffalo, Buffalo, Deer, Deer, Deer, Weasel };
List<Animal> test_case_2 = new() { Buffalo, Deer, Deer, Rabbit, Rabbit, Rabbit, Rabbit, Rabbit, Weasel };
List<Animal> test_case_3 = new() { Buffalo, Lion, Deer, Coyote, Rabbit, Weasel };
List<Animal> test_case_4 = new() { Buffalo, Lion, Deer, Deer, Deer, Deer, Deer, Coyote, Rabbit, Weasel, Weasel };
List<Animal> test_case_5 = new() { Buffalo, Buffalo, Deer, Rabbit, Weasel };
List<Animal> test_case_6 = new() { Weasel, Deer, Deer, Buffalo, Buffalo, Buffalo, Weasel, Weasel };
List<Animal> test_case_7 = new() { Buffalo, Buffalo, Buffalo, Buffalo, Buffalo, Buffalo, Lion, Lion, Lion, Deer, Deer, Deer, Deer, Deer, Coyote, Coyote, Coyote, Weasel, Weasel, Weasel, Weasel, Weasel, Weasel, Weasel };

List<Animal> test_case_fr_fr = test_case_7;
Station station = new();


for(int i = 0; i < 10; i++) {
    test_case_fr_fr = Randomize(test_case_fr_fr);

    station.MakeTrain(test_case_fr_fr);

    Console.WriteLine($"Train {i+1}:");
    for(int j = 0; j < station.wagons.Count; j++)
    {
        Console.WriteLine($"    Wagon {j+1}: ");
        foreach(Animal animal in station.wagons[j].passangers)
        {
            Console.WriteLine("        " + animal.Name);
        }
    }
    Console.Write("\n");
}


List<Animal> Randomize(List<Animal> case_to_test)
{
    Random rand = new();
    return case_to_test.OrderBy(_ => rand.Next()).ToList();
}
