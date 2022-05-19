internal class Hero : Creature
{
    public Hero(Cell heroCell) : base(heroCell, "H ")
    {
        Color = ConsoleColor.Blue;
    }
}