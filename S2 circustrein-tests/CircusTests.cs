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
    }
}