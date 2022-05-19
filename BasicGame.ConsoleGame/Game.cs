internal class Game
{
    private Map map = null!;
    private Hero hero = null!;


    public Game()
    {

    }

    internal void Run()
    {
        Initialize();
        Play();
    }

    private void Play()
    {
        bool gameInProgress = true;
        do
        {
            //DrawMap
            DrawMap();

            //GetCommand

            //Act

            //DrawMap

            //EnemyAction

            //DrawMap
            Console.ReadKey();

        } while (gameInProgress);
    }

    private void DrawMap()
    {
        Console.Clear();

        for (int y = 0; y < map.Height; y++)
        {
            for (int x = 0; x < map.Width; x++)
            {
                Cell? cell = map.GetCell(y, x);
                Console.ForegroundColor = cell?.Color ?? ConsoleColor.White;
                Console.Write(cell.Symbol);
            }
            Console.WriteLine();
        }

        Console.ForegroundColor = ConsoleColor.White;
    }

    private void Initialize()
    {
        //ToDo: Read from config
        map = new Map(width: 10,height: 10);
        hero = new Hero();
    }
}