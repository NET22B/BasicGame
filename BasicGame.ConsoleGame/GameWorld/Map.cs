
using BasicGame.ConsoleGame.Extensions;
using BasicGame.ConsoleGame.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

public class Map : IMap
{
    private Cell[,] cells;
    public int Width { get; }
    public int Height { get; }

    public List<Creature> Creatures { get; set; } = new List<Creature>();

    //public Map(IConfiguration config, IMapSettings settings, IMapService mapService)
   // public Map(IConfiguration config, IOptions<MapSettings> options)
    public Map(IMapService mapService)
    {
        var (width, height) = mapService.GetMap();

        //var width = config.GetMapSizeFor("x");
        //var height = config.GetMapSizeFor("y");

        Width = width;
        Height = height;

        cells = new Cell[Height, Width];

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                cells[y, x] = new Cell(new Position(y, x));
            }
        }
    }

    [return: MaybeNull]
    public Cell GetCell(int y, int x)
    {

        if (x < 0 || x >= Width || y < 0 || y >= Height)
        {
            //ToDo Dont return null!
            return null;
        }

        return cells[y, x];
    }

    [return: MaybeNull]
    public Cell GetCell(Position newPosition)
    {
        return GetCell(newPosition.Y, newPosition.X);
    }

    public void Place(Creature creature)
    {
        // if (Creatures.Where(c => c.Cell == creature.Cell).Count() >= 1) return;
        if (Creatures.FirstOrDefault(c => c.Cell == creature.Cell) != null) return;
        Creatures.Add(creature);
    }

    public Creature? CreatureAt(Cell? newCell)
    {
        return Creatures.FirstOrDefault(c => c.Cell == newCell);
    }
}