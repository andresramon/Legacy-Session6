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
                    if (IsNotLimitNorth())
                    {
                        point.Y++;
                    }
                    break;
                case CardinalPoint.Sur:
                    if (IsNotLimitSouth())
                    {
                        point.Y--;
                    }
                    break;
                case CardinalPoint.Este:
                    if (IsNotLimitEast())
                    {
                        point.X++;
                    }
                    break;
                case CardinalPoint.Oeste:
                    if (IsNotLimitWest())
                    {
                        point.X--;
                    }
                    break;
            }
            return PrintPosition();
        }

        public string moveRear()
        {
            switch (_iniOrientation)
            {
                case CardinalPoint.Norte:
                    if (IsNotLimitSouth())
                    {
                        point.Y--;
                    }
                    break;
                case CardinalPoint.Sur:
                    if (IsNotLimitNorth())
                    {
                        point.Y++;
                    }
                    break;
                case CardinalPoint.Este:
                    if (IsNotLimitWest())
                    {
                        point.X--;
                    }
                    break;
                case CardinalPoint.Oeste:
                    if (IsNotLimitEast())
                    {
                        point.X++;
                    }
                    break;
            }
            return PrintPosition();
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