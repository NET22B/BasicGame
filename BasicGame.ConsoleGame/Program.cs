

var list = new List<string>();

var elemetn = list[0];
var elemetn2 = list[5];
var elemetn3 = list[10];
//var list2 = new List<Creature>();
//var list3 = new List<object>();
//var dict = new Dictionary<int, Cell>();


var limitedList = new LimitedList<Creature>(5);
var limitedList2 = new LimitedList<int>(-5);
var limel = limitedList[5];

var game = new Game();
game.Run();

Console.WriteLine("Thanks for playing");
Console.ReadLine();
