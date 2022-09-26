using System;

namespace MarsRover
{
    public class ExplorerRover
    {
        private CardinalPoint currentOrientation;
        private readonly Map _map;
        private Point point;

        public ExplorerRover(Point initialPoint, CardinalPoint iniOrientation, Map map)
        {
            currentOrientation = iniOrientation;
            point = initialPoint;
            _map = map;
        }

        public string moveAhead()
        {
            switch (currentOrientation)
            {
                case CardinalPoint.Norte:
                    TryMoveNorth();
                    break;
                case CardinalPoint.Sur:
                    TryMoveSouth();
                    break;
                case CardinalPoint.Este:
                    TryMoveEast();
                    break;
                case CardinalPoint.Oeste:
                    TryMoveWest();
                    break;
            }
            return PrintPosition();
        }

        public string moveRear()
        {
            switch (currentOrientation)
            {
                case CardinalPoint.Norte:
                    TryMoveSouth();
                    break;
                case CardinalPoint.Sur:
                    TryMoveNorth();
                    break;
                case CardinalPoint.Este:
                    TryMoveWest();
                    break;
                case CardinalPoint.Oeste:
                    TryMoveEast();
                    break;
            }
            return PrintPosition();
        }

        private void TryMoveEast()
        {
            if (_map.IsNotLimitEast(point.X))
            {
                point.X++;
            }
        }

        private void TryMoveWest()
        {
            if (_map.IsNotLimitWest(point.X))
            {
                point.X--;
            }
        }


        private void TryMoveNorth()
        {
            if (_map.IsNotLimitNorth(point.Y))
            {
                point.Y++;
            }
        }

        private void TryMoveSouth()
        {
            if (_map.IsNotLimitSouth(point.Y))
            {
                point.Y--;
            }
        }

        private string PrintPosition()
        {
            return $"{point.X} {point.Y} {(char)currentOrientation}";
        }

        public string RotateLeft()
        {
            switch (currentOrientation)
            {
                case CardinalPoint.Norte:
                    currentOrientation = CardinalPoint.Oeste;
                    break;
                case CardinalPoint.Sur:
                    currentOrientation = CardinalPoint.Este;
                    break;
                case CardinalPoint.Este:
                    currentOrientation = CardinalPoint.Norte;
                    break;
                case CardinalPoint.Oeste:
                    currentOrientation = CardinalPoint.Sur;
                    break;
            }
            return PrintPosition();
        }

        public string RotateRight()
        {
            switch (currentOrientation)
            {
                case CardinalPoint.Norte:
                    currentOrientation = CardinalPoint.Este;
                    break;
                case CardinalPoint.Sur:
                    currentOrientation = CardinalPoint.Oeste;
                    break;
                case CardinalPoint.Este:
                    currentOrientation = CardinalPoint.Sur;
                    break;
                case CardinalPoint.Oeste:
                    currentOrientation = CardinalPoint.Norte;
                    break;
            }
            return PrintPosition();
        }
    }
}