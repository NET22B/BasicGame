internal class UI
{
    internal static ConsoleKey GetKey() => Console.ReadKey(intercept: true).Key;
    //{
    //    return Console.ReadKey(intercept: true).Key;
    //}
   
}