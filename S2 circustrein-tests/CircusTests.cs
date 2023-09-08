namespace S2_circustrein_tests
{
    [TestClass]
    public class CircusTests
    {
        Animal Rabbit = new(Animal.SizeEnum.Small, false, "Rabbit");
        Animal Weasel = new(Animal.SizeEnum.Small, true, "Weasel");
        Animal Deer = new(Animal.SizeEnum.Medium, false, "Deer");
        Animal Coyote = new(Animal.SizeEnum.Medium, true, "Coyote");
        Animal Buffalo = new(Animal.SizeEnum.Large, false, "Buffalo");
        Animal Lion = new(Animal.SizeEnum.Large, true, "Lion");

        Station _station = new();

        List<Animal> Randomize(List<Animal> case_to_test)
        {
            Random rand = new();
            return case_to_test.OrderBy(_ => rand.Next()).ToList();
        }


        [TestMethod]
        public void Can_Add_Animal_To_Wagon()
        {
            //Arrange
            Wagon wagon = new();
            Wagon emptyWagon = new();

            //Act
            wagon.AddAnimal(AnimalFactory.RandomAnimal());

            //Assert
            Assert.AreNotSame(emptyWagon, wagon);
        }

        [TestMethod]
        public void Can_Add_Animal_To_Wagon_But_Better_Question_Mark()
        {
            //Arrange
            Wagon wagon = new();

            //Act
            bool result = wagon.CanAddAnimal(AnimalFactory.RandomAnimal());

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Wont_Add_Animal_To_Full_Wagon()
        {
            //Arrange
            Wagon wagon = new();
            wagon.AddAnimal(AnimalFactory.LargeHerbivore);
            wagon.AddAnimal(AnimalFactory.LargeHerbivore);
            Animal animal = AnimalFactory.RandomAnimal();

            //Act
            bool result = wagon.CanAddAnimal(animal); 
            
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Can_Complete_Test_Case_Optimally()
        {
            //Arrange
            List<Animal> test_case = new() { Buffalo, Buffalo, Buffalo, Buffalo, Buffalo, Buffalo, Lion, Lion, Lion, Deer, Deer, Deer, Deer, Deer, Coyote, Coyote, Coyote, Weasel, Weasel, Weasel, Weasel, Weasel, Weasel, Weasel };
            int amountOfLoops = 1000;
            int amountOfWagons = 0;
            int wagonGoal = 13 * amountOfLoops;

            //Act
            for (int i = 0; i < amountOfLoops; i++)
            {
                Randomize(test_case);
                _station.MakeTrain(test_case);
                amountOfWagons += _station.wagons.Count;
            }

            //Assert
            Assert.AreEqual(amountOfWagons, wagonGoal);
        }

        [TestMethod]
        public void Performence_Test()
        {
            //Arrange
            Wagon wagon = new();

            //Act
            for(int i = 0; i < 100000; i++)
            {
                wagon.AddAnimal(AnimalFactory.RandomAnimal());
            }

            //Assert
        }
    }
}