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
            return $"{point.X} {point.Y} {(char)_iniOrientation}";
        }
    }
}