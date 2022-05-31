using BasicGame.ConsoleGame.Entities.Creatures;
using BasicGame.ConsoleGame.Entities.Items;
using BasicGame.ConsoleGame.GameWorld;

internal class Game
{
    private IMap map = null!;
    private Hero hero = null!;
    private bool gameInProgress;
    private IUI ui;

    public Game(IUI consoleUI)
    {
        ui = consoleUI;
    }

    internal void Run()
    {
        Initialize();
        Play();
    }

    private void Play()
    {
        gameInProgress = true;
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
        var keyPressed = ui.GetKey();

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
                        {ConsoleKey.I, Inventory},
                        {ConsoleKey.D, Drop},
                        {ConsoleKey.Q, Quit}
                    };

        if (actionMeny.ContainsKey(keyPressed))
            actionMeny[keyPressed]?.Invoke();

    }

    private void Quit()
    {
        Environment.Exit(0);
    }

    private void Drop()
    {
        var item = hero.BackPack.FirstOrDefault();

        if (item != null && hero.BackPack.Remove(item))
        {
            hero.Cell.Items.Add(item);
            ui.AddMessage($"Hero dropped the {item}");
        }
        else
            ui.AddMessage("Backpack is empty");

    }

    private void Inventory()
    {
        ui.AddMessage(hero.BackPack.Count > 0 ? "Inventory:" : "No items in backpack");
        for (int i = 0; i < hero.BackPack.Count; i++)
        {
            ui.AddMessage($"{i + 1}: {hero.BackPack[i]}");
        }
    }

    private void PickUp()
    {
        if (hero.BackPack.IsFull)
        {
            ui.AddMessage("BackPack is full");
            return;
        }

        var items = hero.Cell.Items;
        var item = items.FirstOrDefault();
        if (item is null) return;

        if(item is IUsable usable)
        {
            usable.Use(hero);
            hero.Cell.Items.Remove(item);
            ui.AddMessage($"Hero use the {item}");
            return;
        }

        if (hero.BackPack.Add(item))
        {
            ui.AddMessage($"Hero pick up {item}");
            items.Remove(item);
        }
    }

    private void Move(Position movement)
    {
        Position newPosition = hero.Cell.Position + movement;
        Cell? newCell = map.GetCell(newPosition);

        var opponent = map.CreatureAt(newCell);
        if (opponent != null) hero.Attack(opponent);

        gameInProgress = !hero.IsDead;

        if (newCell != null)
        {
            hero.Cell = newCell;
            if (newCell.Items.Any())
                ui.AddMessage($"You see {string.Join(", ",newCell.Items.Select(i => i.ToString()))}");
        }

    }

    private void DrawMap()
    {
        ui.Clear();
        ui.Draw(map);
        ui.PrintStats($"Health: {hero.Health}, Enemys: {map.Creatures.Count -1} ");
        ui.PrintLog();
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

        map.GetCell(RH(r), RW(r))?.Items.Add(Potion.HealthPotion());
        map.GetCell(RH(r), RW(r))?.Items.Add(Potion.HealthPotion());
        map.GetCell(RH(r), RW(r))?.Items.Add(Potion.HealthPotion());
        
        var defaultCreatureCell = map.GetCell(5, 5);
        ArgumentNullException.ThrowIfNull(defaultCreatureCell);

        map.Place(new Orc(map.GetCell(RH(r), RW(r)) ?? defaultCreatureCell, 120));
        map.Place(new Orc(map.GetCell(RH(r), RW(r)) ?? defaultCreatureCell, 120));
        map.Place(new Troll(map.GetCell(RH(r), RW(r)) ?? defaultCreatureCell, 160));
        map.Place(new Troll(map.GetCell(RH(r), RW(r)) ?? defaultCreatureCell, 160));
        map.Place(new Goblin(map.GetCell(RH(r), RW(r)) ?? defaultCreatureCell, 200));
        map.Place(new Goblin(map.GetCell(RH(r), RW(r)) ?? defaultCreatureCell, 200));

        map.Creatures.ForEach(c => c.AddToLog = ui.AddMessage);
       //map.Creatures.ForEach(c => c.AddToLog += Console.WriteLine);

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