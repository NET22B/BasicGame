internal class Creature : IDrawable
{
    private Cell cell;
    public string Symbol { get; }
    public ConsoleColor Color { get; protected set; } = ConsoleColor.Green;

    public int Health { get; internal set; }
    public Cell Cell 
    { 
        get => cell;
        set
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            cell = value;
        }
    
    }

    public Creature(Cell cell, string symbol)
    {
        ArgumentNullException.ThrowIfNull(nameof(cell));
        this.cell = cell;
        Symbol = symbol;
    }


}