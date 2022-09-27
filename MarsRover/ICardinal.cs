namespace MarsRover
{
    public interface ICardinal
    {
        Point TryMoveAhead(Map map, Point point);
        Point TryMoveRear(Map map, Point point);
        ICardinal RotateLeft();
        ICardinal RotateRight();

        CardinalPoint GetOrientation();
        
        
    }
}