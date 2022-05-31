
using BasicGame.ConsoleGame.Entities.Items;
using BasicGame.ConsoleGame.GameWorld;

public class Cell : IDrawable
{
    public Position Position { get; set; }
    public string Symbol => ". ";
    public ConsoleColor Color { get; protected set; }
    public List<Item> Items { get; } = new List<Item>();

    public Cell(Position position)
    {
        Color = ConsoleColor.Red;
        Position = position;
    }
}