namespace MarsRover
{
    public class Sur : ICardinal
    {
        public CardinalPoint GetOrientation()
        {
            return CardinalPoint.Sur;
        }
        public ICardinal RotateLeft()
        {
            return new Este();
        }

        public ICardinal RotateRight()
        {
            return new Oeste();
        }
    }
}