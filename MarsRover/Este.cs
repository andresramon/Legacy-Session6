﻿namespace MarsRover
{
    public class Este : ICardinal
    {
        public CardinalPoint GetOrientation()
        {
            return CardinalPoint.Este;
        }

        public Point TryMoveAhead(Map map, Point point)
        {
            if (map.IsNotLimitEast(point.X))
            {
                point.X++;
            }

            return point;
        }

        public Point TryMoveRear(Map map, Point point)
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