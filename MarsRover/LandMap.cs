namespace MarsRover
{
    public class LandMap : IMap
    {
        private readonly int _maxX;
        private readonly int _maxY;

        public LandMap(int maxX, int maxY)
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

        public static IMap CreateMapFromDimension(string dimensionMap)
        {
            string[] inputDimensions = dimensionMap.Split(' ');
            return new LandMap(int.Parse(inputDimensions[0]), int.Parse(inputDimensions[1]));
        }
    }
}