namespace MarsRover
{
    public class ExplorerRover
    {
        private int _iniX;
        private int _iniY;
        private readonly char _iniOrientation;
        private readonly Map _map;

        public ExplorerRover(int iniX, int iniY, char iniOrientation, Map map)
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
                case 'N':
                    if(_iniY<_map._maxY)
                        _iniY++;
                    break;
                case 'S':
                    if(_iniY > 0)
                        _iniY--;
                    break;
                case 'E':
                    if(_iniX<_map._maxX)
                        _iniX++;
                    break;
                case 'O':
                    if(_iniX > 0)
                        _iniX--;
                    break;
            }
            return $"{_iniX} {_iniY} {_iniOrientation}";
        }

        public string moveRear()
        {
            switch (_iniOrientation)
            {
                case 'N':
                    if (_iniY > 0)
                        _iniY--;
                    break;
                case 'S':
                    if (_iniY < _map._maxY)
                        _iniY++;
                    break;
                case 'E':
                    if (_iniX > 0 )
                        _iniX--;
                    break;
                case 'O':
                    if (_iniX < _map._maxX)
                        _iniX++;
                    break;
            }
            return $"{_iniX} {_iniY} {_iniOrientation}";
        }
    }
}