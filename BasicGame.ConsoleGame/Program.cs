

//var list = new List<Creature>();
//var arr = new Creature[5];

////var elemetn = list[0];
////var elemetn2 = list[5];
////var elemetn3 = list[10];
////var list2 = new List<Creature>();
////var list3 = new List<object>();
////var dict = new Dictionary<int, Cell>();


//var limitedList = new LimitedList<Creature>(10);
//limitedList.Add(new Hero(new Cell(new Position(5,5))));

//var limitedList2 = new LimitedList<int>(10);
//var limel = limitedList[0];
////limitedList[2] = new Hero(new Cell(new Position(5,5)));

//foreach (var item in limitedList)
//{
//    Console.WriteLine(item);
//}

var game = new Game(new ConsoleUI());
game.Run();

Console.WriteLine("Thanks for playing");
Console.ReadLine();
