namespace MarsRover
{
    public class Sur : ICardinal
    {
        public CardinalPointEnum GetOrientation()
        {
            return CardinalPointEnum.Sur;
        }

        public Point TryMoveAhead(IMap map, Point point)
        {
            if (map.IsNotLimitSouth(point.Y))
            {
                point.Y--;
            }

            return point;
        }

        public Point TryMoveRear(IMap map, Point point)
        {
            if (map.IsNotLimitNorth(point.Y))
            {
                point.Y++;
            }

            return point;
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