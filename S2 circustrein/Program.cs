// See https://aka.ms/new-console-template for more information
using System.Transactions;
using S2_circustrein;

AnimalClass Rabbit  = new(AnimalClass.SizeEnum.Small, false, "Rabbit");
AnimalClass Weasel  = new(AnimalClass.SizeEnum.Small, true, "Weasel");
AnimalClass Deer    = new(AnimalClass.SizeEnum.Medium, false, "Deer");
AnimalClass Coyote  = new(AnimalClass.SizeEnum.Medium, true, "Coyote");
AnimalClass Buffalo = new(AnimalClass.SizeEnum.Large, false, "Buffalo");
AnimalClass Lion    = new(AnimalClass.SizeEnum.Large, true, "Lion");

List<AnimalClass> test_case_1 = new() { Buffalo, Buffalo, Deer, Deer, Deer, Weasel };
List<AnimalClass> test_case_2 = new() { Buffalo, Deer, Deer, Rabbit, Rabbit, Rabbit, Rabbit, Rabbit, Weasel };
List<AnimalClass> test_case_3 = new() { Buffalo, Lion, Deer, Coyote, Rabbit, Weasel };
List<AnimalClass> test_case_4 = new() { Buffalo, Lion, Deer, Deer, Deer, Deer, Deer, Coyote, Rabbit, Weasel, Weasel };
List<AnimalClass> test_case_5 = new() { Buffalo, Buffalo, Deer, Rabbit, Weasel };
List<AnimalClass> test_case_6 = new() { Weasel, Deer, Deer, Buffalo, Buffalo, Buffalo, Weasel, Weasel };
List<AnimalClass> test_case_7 = new() { Buffalo, Buffalo, Buffalo, Buffalo, Buffalo, Buffalo, Lion, Lion, Lion, Deer, Deer, Deer, Deer, Deer, Coyote, Coyote, Coyote, Weasel, Weasel, Weasel, Weasel, Weasel, Weasel, Weasel };

List<AnimalClass> test_case_fr_fr = test_case_7;
StationClass station = new();


for(int i = 0; i < 10; i++) {
    test_case_fr_fr = Randomize(test_case_fr_fr);

    station.MakeTrain(test_case_fr_fr);

    Console.WriteLine($"Train {i+1}:");
    for(int j = 0; j < station.Train.Count; j++)
    {
        Console.WriteLine($"    Wagon {j+1}: ");
        foreach(AnimalClass animal in station.Train[j].Passangers)
        {
            Console.WriteLine("        " + animal.Name);
        }
    }
    Console.Write("\n");
}


List<AnimalClass> Randomize(List<AnimalClass> case_to_test)
{
    Random rand = new();
    return case_to_test.OrderBy(_ => rand.Next()).ToList();
}
