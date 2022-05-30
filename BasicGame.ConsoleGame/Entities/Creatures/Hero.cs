using BasicGame.ConsoleGame.Entities.Items;

internal class Hero : Creature
{

    public LimitedList<Item> BackPack { get; }
    

    public Hero(Cell heroCell) : base(heroCell, "H ")
    {
        Color = ConsoleColor.Blue;
        BackPack = new LimitedList<Item>(3); //ToDo Read from config
    }
}