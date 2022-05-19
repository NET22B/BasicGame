internal class Cell : IDrawable
{
    public string Symbol => ". ";
    public ConsoleColor Color { get; protected set; }

    public Cell()
    {
        Color = ConsoleColor.Red;
    }
}