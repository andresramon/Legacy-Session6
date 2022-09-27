namespace MarsRover
{
    public class Oeste : ICardinal
    {
        public CardinalPoint GetOrientation()
        {
            return CardinalPoint.Oeste;
        }

        public Point TryMoveAhead(Map map, Point point)
        {
            if (map.IsNotLimitWest(point.X))
            {
                point.X--;
            }

            return point;
        }

        public Point TryMoveRear(Map map, Point point)
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