using System.Runtime.ExceptionServices;

namespace MarsRover
{
    public class Norte : ICardinal
    {
        
        public CardinalPointEnum GetOrientation()
        {
            return CardinalPointEnum.Norte;
        }

        public Point TryMoveAhead(IMap map, Point point)
        {
            if (map.IsNotLimitNorth(point.Y))
            {
                point.Y++;
            }

            return point;
        }

        public Point TryMoveRear(IMap map, Point point)
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