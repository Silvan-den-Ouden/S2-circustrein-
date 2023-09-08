// See https://aka.ms/new-console-template for more information
using System.Transactions;
using S2_circustrein;

TestCases _tests = new();

List<Animal> testCase = _tests.GetCase(7);
Station station = new();


for(int i = 0; i < 10; i++) {
    station.MakeTrain(testCase);

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