namespace MarsRover
{
    public class Oeste : ICardinal
    {
        public CardinalPointEnum GetOrientation()
        {
            return CardinalPointEnum.Oeste;
        }

        public Point TryMoveAhead(IMap map, Point point)
        {
            if (map.IsNotLimitWest(point.X))
            {
                point.X--;
            }

            return point;
        }

        public Point TryMoveRear(IMap map, Point point)
        {
            if (map.IsNotLimitEast(point.X))
            {
                point.X++;
            }

            return point;
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