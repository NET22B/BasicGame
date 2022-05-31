
public interface IMap
{
    List<Creature> Creatures { get; set; }
    int Height { get; }
    int Width { get; }

    Creature? CreatureAt(Cell? newCell);
    Cell? GetCell(int y, int x);
    Cell? GetCell(Position newPosition);
    void Place(Creature creature);
}