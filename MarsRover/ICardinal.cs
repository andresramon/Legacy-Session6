namespace MarsRover
{
    public interface ICardinal
    {
        Point TryMoveAhead(IMap map, Point point);
        Point TryMoveRear(IMap map, Point point);
        ICardinal RotateLeft();
        ICardinal RotateRight();
        CardinalPointEnum GetOrientation();
    }
}