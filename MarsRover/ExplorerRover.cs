namespace MarsRover
{
    public class ExplorerRover
    {
        private int _iniX;
        private int _iniY;
        private readonly CardinalPoint _iniOrientation;
        private readonly Map _map;

        public ExplorerRover(int iniX, int iniY, CardinalPoint iniOrientation, Map map)
        {
            _iniX = iniX;
            _iniY = iniY;
            _iniOrientation = iniOrientation;
            _map = map;
        }

        public string moveAhead()
        {
            switch (_iniOrientation)
            {
                case CardinalPoint.Norte:
                    if(_iniY<_map._maxY)
                        _iniY++;
                    break;
                case CardinalPoint.Sur:
                    if(_iniY > 0)
                        _iniY--;
                    break;
                case CardinalPoint.Este:
                    if(_iniX<_map._maxX)
                        _iniX++;
                    break;
                case CardinalPoint.Oeste:
                    if(_iniX > 0)
                        _iniX--;
                    break;
            }
            return $"{_iniX} {_iniY} {(char)_iniOrientation}";
        }

        public string moveRear()
        {
            switch (_iniOrientation)
            {
                case CardinalPoint.Norte:
                    if (_iniY > 0)
                        _iniY--;
                    break;
                case CardinalPoint.Sur:
                    if (_iniY < _map._maxY)
                        _iniY++;
                    break;
                case CardinalPoint.Este:
                    if (_iniX > 0 )
                        _iniX--;
                    break;
                case CardinalPoint.Oeste:
                    if (_iniX < _map._maxX)
                        _iniX++;
                    break;
            }
            return $"{_iniX} {_iniY} {(char)_iniOrientation}";
        }
    }
}