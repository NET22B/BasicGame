internal class UI
{
    internal static ConsoleKey GetKey() => Console.ReadKey(intercept: true).Key;

    internal static void Clear()
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0,0);
    }
    //{
    //    return Console.ReadKey(intercept: true).Key;
    //}

}