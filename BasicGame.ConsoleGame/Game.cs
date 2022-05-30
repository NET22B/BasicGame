using BasicGame.ConsoleGame.Entities.Creatures;
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
            //case ConsoleKey.P:
            //    PickUp();
            //    break;
            //case ConsoleKey.I:
            //    Inventory();
            //    break;

            default:
                break;
        }


        var actionMeny = new Dictionary<ConsoleKey, Action>
                    {
                        {ConsoleKey.P, PickUp},
                        {ConsoleKey.I, Inventory}
                    };

        if (actionMeny.ContainsKey(keyPressed))
            actionMeny[keyPressed]?.Invoke();

    }

    private void Inventory()
    {
        for (int i = 0; i < hero.BackPack.Count; i++)
        {
            UI.AddMessage($"{i + 1}: \t{hero.BackPack[i]}");
        }
    }

    private void PickUp()
    {
        if (hero.BackPack.IsFull)
        {
            UI.AddMessage("BackPack is full");
            return;
        }

        var items = hero.Cell.Items;
        var item = items.FirstOrDefault();
        if (item is null) return;

        if (hero.BackPack.Add(item))
        {
            UI.AddMessage($"Hero pick up {item}");
            items.Remove(item);
        }
    }

    private void Move(Position movement)
    {
        Position newPosition = hero.Cell.Position + movement;
        Cell? newCell = map.GetCell(newPosition);
        if (newCell != null) hero.Cell = newCell;

    }

    private void DrawMap()
    {
        UI.Clear();
        UI.Draw(map);
        UI.PrintStats($"Health: {hero.Health}");
        UI.PrintLog();
    }

    private void Initialize()
    {
        //ToDo: Read from config
        map = new Map(width: 10, height: 10);
        var heroCell = map.GetCell(0, 0);
        ArgumentNullException.ThrowIfNull(heroCell);
        hero = new Hero(heroCell);
        map.Creatures.Add(hero);

        var r = new Random();

        map.GetCell(RH(r), RW(r))?.Items.Add(Item.Coin());
        map.GetCell(RH(r), RW(r))?.Items.Add(Item.Coin());
        map.GetCell(RH(r), RW(r))?.Items.Add(Item.Stone());
        map.GetCell(RH(r), RW(r))?.Items.Add(Item.Stone());
        
        var defaultCreatureCell = map.GetCell(5, 5);
        ArgumentNullException.ThrowIfNull(defaultCreatureCell);

        map.Place(new Orc(map.GetCell(RH(r), RW(r)) ?? defaultCreatureCell, 120));
        map.Place(new Orc(map.GetCell(RH(r), RW(r)) ?? defaultCreatureCell, 120));
        map.Place(new Troll(map.GetCell(RH(r), RW(r)) ?? defaultCreatureCell, 160));
        map.Place(new Troll(map.GetCell(RH(r), RW(r)) ?? defaultCreatureCell, 160));
        map.Place(new Goblin(map.GetCell(RH(r), RW(r)) ?? defaultCreatureCell, 200));
        map.Place(new Goblin(map.GetCell(RH(r), RW(r)) ?? defaultCreatureCell, 200));

        int RW(Random r)
        {
            return r.Next(0, map.Width);
        }

        int RH(Random r)
        {
            return r.Next(0, map.Height);
        }



    }
}