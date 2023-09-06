//using S2_circustrein;

//List<AnimalClass> Sort(List<AnimalClass> Animals)
//{
//    List<AnimalClass> Carnivores = new();
//    List<AnimalClass> BigHerbs = new();
//    List<AnimalClass> MedHerbs = new();
//    List<AnimalClass> SmlHerbs = new();

//    foreach (var Animal in Animals)
//    {
//        if (Animal.Carnivorous)
//        {
//            Carnivores.Add(Animal);
//        } else
//        {
//            switch ((int)Animal.Size)
//            {
//                case 1:
//                    SmlHerbs.Add(Animal);
//                    break;
//                case 3:
//                    MedHerbs.Add(Animal);
//                    break;
//                case 5:
//                    BigHerbs.Add(Animal);
//                    break;
//            }
//        }
//    }

//    List<AnimalClass> AnimalsSorted = new();
//    AnimalsSorted.AddRange(Carnivores);
//    AnimalsSorted.AddRange(BigHerbs);
//    AnimalsSorted.AddRange(MedHerbs);
//    AnimalsSorted.AddRange(SmlHerbs);


//    return AnimalsSorted;
//}