namespace MarsRover
{
    public class Este : ICardinal
    {
        public CardinalPointEnum GetOrientation()
        {
            return CardinalPointEnum.Este;
        }

        public Point TryMoveAhead(IMap map, Point point)
        {
            if (map.IsNotLimitEast(point.X))
            {
                point.X++; 
            }

            return point;
        }

        public Point TryMoveRear(IMap map, Point point)
        {
            if (map.IsNotLimitWest(point.X))
            {
                point.X--;
            }

            return point;
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