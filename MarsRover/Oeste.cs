namespace MarsRover
{
    public class Oeste : ICardinal
    {
        public CardinalPoint GetOrientation()
        {
            return CardinalPoint.Oeste;
        }
        public ICardinal RotateLeft()
        {
            return new Sur();
        }

        public ICardinal RotateRight()
        {
            return new Norte();
        }
    }
}