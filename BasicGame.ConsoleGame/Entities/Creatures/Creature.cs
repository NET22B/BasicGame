internal class Creature : IDrawable
{
    private Cell cell;
    private int health;
    public string Symbol { get; }
    public ConsoleColor Color { get; protected set; } = ConsoleColor.Green;

    public int Health 
    { 
        get => health < 0 ? 0 : health; 
        set => health = value >= MaxHealth ? MaxHealth : value;
    }

    public int Damage { get; set; } = 50;
    public bool IsDead => health <= 0;

    public int MaxHealth { get; }
    public Cell Cell 
    { 
        get => cell;
        set
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            cell = value;
        }
    
    }

    public Creature(Cell cell, string symbol, int maxHealth)
    {
        ArgumentNullException.ThrowIfNull(nameof(cell));
        this.cell = cell;
        Symbol = symbol;
        MaxHealth = maxHealth;
        health = maxHealth;
    }


}