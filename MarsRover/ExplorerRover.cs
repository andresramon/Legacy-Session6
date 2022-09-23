namespace MarsRover
{
    public class ExplorerRover
    {
        private readonly CardinalPoint _iniOrientation;
        private readonly Map _map;
        private Point point;

        public ExplorerRover(Point initialPoint, CardinalPoint iniOrientation, Map map)
        {
            _iniOrientation = iniOrientation;
            point = initialPoint;
            _map = map;
        }

        public string moveAhead()
        {
            switch (_iniOrientation)
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
            switch (_iniOrientation)
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
            if (IsNotLimitEast())
            {
                point.X++;
            }
        }

        private void TryMoveWest()
        {
            if (IsNotLimitWest())
            {
                point.X--;
            }
        }

        private void TryMoveNorth()
        {
            if (IsNotLimitNorth())
            {
                point.Y++;
            }
        }

        private void TryMoveSouth()
        {
            if (IsNotLimitSouth())
            {
                point.Y--;
            }
        }

        private bool IsNotLimitEast()
        {
            return point.X < _map._maxX;
        }

        private bool IsNotLimitWest()
        {
            return point.X > 0;
        }

        private bool IsNotLimitNorth()
        {
            return point.Y < _map._maxY;
        }

        private bool IsNotLimitSouth()
        {
            return point.Y > 0;
        }

        private string PrintPosition()
        {
            return $"{point.X} {point.Y} {(char)_iniOrientation}";
        }
    }
}