using System.Runtime.ExceptionServices;

namespace MarsRover
{
    public class Norte : ICardinal
    {
        
        public CardinalPoint GetOrientation()
        {
            return CardinalPoint.Norte;
        }

        public Point TryMoveAhead(Map map, Point point)
        {
            if (map.IsNotLimitNorth(point.Y))
            {
                point.Y++;
            }

            return point;
        }

        public Point TryMoveRear(Map map, Point point)
        {
            if (map.IsNotLimitSouth(point.Y))
            {
                point.Y--;
            }

            return point;
        }

        public ICardinal RotateLeft()
        {
            return new Oeste();
        }

        public ICardinal RotateRight()
        {
            return new Este();
        }
    
    }
}