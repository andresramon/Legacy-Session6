namespace MarsRover
{
    public class Map
    {
        private readonly int _maxX;
        private readonly int _maxY;

        public Map(int maxX, int maxY)
        {
            _maxX = maxX;
            _maxY = maxY;
        }

        public bool IsNotLimitEast(int x)
        {
            return x < _maxX;
        }

        public bool IsNotLimitWest(int x)
        {
            return x > 0;
        }

        public bool IsNotLimitNorth(int y)
        {
            return y < _maxY;
        }

        public bool IsNotLimitSouth(int y)
        {
            return y > 0;
        }
    }
}