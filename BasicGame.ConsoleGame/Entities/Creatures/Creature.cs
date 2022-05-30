internal class Creature : IDrawable
{
    private Cell cell;
    private int health;
    private string name => this.GetType().Name;
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

    public Action<string> AddToLog { get; set; } = null!;

    public Creature(Cell cell, string symbol, int maxHealth)
    {
        ArgumentNullException.ThrowIfNull(nameof(cell));
        this.cell = cell;
        Symbol = symbol;
        MaxHealth = maxHealth;
        health = maxHealth;
    }

    public void Attack(Creature target)
    {
        if (target.IsDead) return; 

        var thisName = this.name;
        var targetName = target.name;

        target.Health -= Damage;

        AddToLog?.Invoke($"The {thisName} attacks the {targetName} for {this.Damage}");

        if (target.IsDead)
        {
            AddToLog?.Invoke($"The {targetName} is IsDead");
            return;
        } 

        Health -= target.Damage;

        AddToLog?.Invoke($"The {targetName} attacks the {thisName} for {target.Damage}");

        if (IsDead)
        {
            AddToLog?.Invoke($"The {thisName} is IsDead");
            return;
        }

    }
}