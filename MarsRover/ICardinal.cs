namespace MarsRover
{
    public interface ICardinal
    {
        //string moveAhead();
        //string moveRear();
        ICardinal RotateLeft();
        ICardinal RotateRight();

        CardinalPoint GetOrientation();
    }
}