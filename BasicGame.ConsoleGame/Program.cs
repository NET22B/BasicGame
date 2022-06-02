
using Microsoft.Extensions.Configuration;

var position = new Position(10, 20);
var position2 = new Position(10, 20);



//Console.WriteLine(position.ToString());

var eq  = position.Equals(position2);

var pos2 = position with { Y = 5 };


var demo = new Demo(10, "10", new[] {"Nisse"});
//demo.items = null;
demo.items[0] = "Kalle";
//var demo2 = new Demo(10, "10");

var (y, x, map) = demo;


//var areEqual = demo.Equals(demo2);


var startup = new Startup();
startup.SetUp();

Console.WriteLine("Thanks for playing");
Console.ReadLine();
