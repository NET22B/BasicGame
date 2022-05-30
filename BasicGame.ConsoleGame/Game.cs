using BasicGame.ConsoleGame.Entities.Items;
using BasicGame.ConsoleGame.GameWorld;

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
            GetCommand();

            //Act

            //DrawMap

            //EnemyAction

            //DrawMap
            //Console.ReadKey();

        } while (gameInProgress);
    }

    private void GetCommand()
    {
        var keyPressed = UI.GetKey();

        switch (keyPressed)
        {
           
            case ConsoleKey.LeftArrow:
                Move(Direction.West);
                break;
            case ConsoleKey.RightArrow:
                Move(Direction.East);
                break;
            case ConsoleKey.UpArrow:
                Move(Direction.North);
                break;
            case ConsoleKey.DownArrow:
                Move(Direction.South);
                break; 
            case ConsoleKey.P:
                PickUp();
                break;
           
            default:
                break;
        }
    }

    private void PickUp()
    {
        if (hero.BackPack.IsFull)
        {
            Console.WriteLine("BackPack is full");
            return;
        }

        var items = hero.Cell.Items;
        var item = items.FirstOrDefault();
        if (item is null) return;

        if (hero.BackPack.Add(item))
        {
            Console.WriteLine($"Hero pick up {item}");
            items.Remove(item);
        }
    }

    private void Move(Position movement)
    {
        Position newPosition = hero.Cell.Position + movement;
        Cell? newCell = map.GetCell(newPosition);
        if(newCell != null) hero.Cell = newCell;

    }

    private void DrawMap()
    {
        UI.Clear();
        UI.Draw(map);
    }

    private void Initialize()
    {
        //ToDo: Read from config
        map = new Map(width: 10,height: 10);
        var heroCell = map.GetCell(0, 0);
        ArgumentNullException.ThrowIfNull(heroCell);
        hero = new Hero(heroCell);
        map.Creatures.Add(hero);

        map.GetCell(2, 4)?.Items.Add(Item.Coin());
        map.GetCell(4, 8)?.Items.Add(Item.Stone());
    }
}