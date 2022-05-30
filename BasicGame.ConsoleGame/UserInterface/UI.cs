using BasicGame.ConsoleGame.Extensions;

internal class UI
{
    private static MessageLog<string> messageLog = new(6);

    internal static ConsoleKey GetKey() => Console.ReadKey(intercept: true).Key;

    internal static void Clear()
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0,0);
    }

    internal static void Draw(Map map)
    {
        for (int y = 0; y < map.Height; y++)
        {
            for (int x = 0; x < map.Width; x++)
            {
                Cell? cell = map.GetCell(y, x);
                ArgumentNullException.ThrowIfNull(cell);

                IDrawable drawable = map.Creatures.CreatureAtExtension2(cell) ?? cell.Items.FirstOrDefault() as IDrawable ?? cell;

                Console.ForegroundColor = drawable.Color;
                Console.Write(drawable.Symbol);
            }
            Console.WriteLine();
        }

        Console.ForegroundColor = ConsoleColor.White;
    }


    internal static void AddMessage(string message) => messageLog.Add(message);
    //{
    //    //ToDo: Check return value
    //    messageLog.Add(message);
    //}

    internal static void PrintLog()
    {
       // messageLog.Print(Console.WriteLine);
        messageLog.Print(m => Console.WriteLine(m + new string(' ', Console.WindowWidth -  m.Length)));
        //messageLog.Print(PrintToConsole);

    }

    //Används bara som demo ovan i PrintLog()
    private static void PrintToConsole(string message)
    {
        Console.WriteLine(message);
    }

    internal static void PrintStats(string stats)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(stats);
        Console.ForegroundColor = ConsoleColor.White;
    }
}