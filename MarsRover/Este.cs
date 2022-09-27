namespace MarsRover
{
    public class Este : ICardinal
    {
        public CardinalPoint GetOrientation()
        {
            return CardinalPoint.Este;
        }
        public ICardinal RotateLeft()
        {
            return new Norte();
        }

        public ICardinal RotateRight()
        {
            return new Sur();
        }
        
    }
}