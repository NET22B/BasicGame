

using System.Diagnostics.CodeAnalysis;

internal class Map
{
    private Cell[,] cells;
    public int Width { get; }
    public int Height { get; }

    public List<Creature> Creatures { get; set; } = new List<Creature>();

    public Map(int width, int height)
    {
        Width = width;
        Height = height;

        cells = new Cell[Height, Width];

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                cells[y, x] = new Cell();
            }
        }
    }

    [return: MaybeNull]
    internal Cell GetCell(int y, int x)
    {
        //ToDo: Fix!
        try
        {
            return cells[y, x];
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }

    }
}