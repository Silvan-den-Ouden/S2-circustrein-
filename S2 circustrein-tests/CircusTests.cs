namespace S2_circustrein_tests
{
    [TestClass]
    public class CircusTests
    {
        readonly Wagon _wagon = new();
        readonly Station _station = new();
        readonly TestCases _tests = new();

        [TestMethod]
        public void Can_Add_Animal_To_Wagon()
        {
            //Arrange
            Wagon emptyWagon = new();

            //Act
            _wagon.AddAnimal(AnimalFactory.RandomAnimal());

            //Assert
            Assert.AreNotSame(emptyWagon, _wagon);
        }

        [TestMethod]
        public void Can_Add_Animal_To_Wagon_But_Better_Question_Mark()
        {
            //Arrange

            //Act
            bool result = _wagon.CanAddAnimal(AnimalFactory.RandomAnimal());

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Wont_Add_Animal_To_Full_Wagon()
        {
            //Arrange
            _wagon.AddAnimal(AnimalFactory.LargeHerbivore);
            _wagon.AddAnimal(AnimalFactory.LargeHerbivore);
            Animal animal = AnimalFactory.RandomAnimal();

            //Act
            bool result = _wagon.CanAddAnimal(animal); 
            
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Bigger_Carnivore_Can_Eat_Smaller_Or_Equal_Herbivore()
        {
            //Arrange
            Animal largeCarnivore = AnimalFactory.LargeCarnivore;
            Animal largeHerbivore = AnimalFactory.LargeHerbivore;
            Animal mediumHerbivore = AnimalFactory.MediumHerbivore;

            //Act
            bool result = largeCarnivore.CanEat(largeHerbivore);
            bool result2 = largeCarnivore.CanEat(mediumHerbivore);

            //Assert
            Assert.IsTrue(result);
            Assert.IsTrue(result2);
        }


        [TestMethod]
        public void Can_Complete_Test_Case_Optimally()
        {
            //Arrange
            List<Animal> test_case = _tests.GetCase(7);
            int amountOfLoops = 1000;
            int amountOfWagons = 0;
            int wagonGoal = 13 * amountOfLoops;

            //Act
            for (int i = 0; i < amountOfLoops; i++)
            {
                _station.MakeTrain(test_case);
                amountOfWagons += _station.wagons.Count;
            }

            //Assert
            Assert.AreEqual(amountOfWagons, wagonGoal);
        }

        [TestMethod]
        public void Wont_Make_Wagon_When_No_Animals()
        {
            //Arrange
            List<Animal> test_case = _tests.GetCase(0);
            List<Wagon> emptyList = new();

            //Act
            _station.MakeTrain(test_case);

            //Assert
            Assert.AreEqual(_station.wagons.Count, emptyList.Count);
        }

        [TestMethod]
        public void Can_Pass_All_Prewritten_Test_Cases()
        {
            //Arrange
            List<int> WagonLengths = new();
            List<int> TargetLengths = new(){ 0, 2, 2, 4, 5, 2, 3, 13 };

            //Act
            for(int i = 0; i <= 7; i++)
            {
                _station.MakeTrain(_tests.GetCase(i));
                WagonLengths.Add(_station.wagons.Count);
            }

            //Assert
            for(int i = 0; i < TargetLengths.Count; i++) {
                Assert.AreEqual(WagonLengths[i], TargetLengths[i]);
            }
        }

        [TestMethod]
        public void Performence_Test()
        {
            //Arrange

            //Act
            for(int i = 0; i < 100000; i++)
            {
                _wagon.AddAnimal(AnimalFactory.RandomAnimal());
            }

            //Assert
        }

        public void Performence_Test_2()
        {
            //Arrange

            //Act
            for(int i = 0; i < 1000; i++)
            {
                List<Animal> animals = AnimalFactory.RandomAnimals(5, 20);
                _station.MakeTrain(animals);
            }

            //Assert
        }
    }
}