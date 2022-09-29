namespace MarsRover
{
    public class FlightMap : IMap
    {

        public bool IsNotLimitEast(int x)
        {
            return true;
        }

        public bool IsNotLimitNorth(int y)
        {
            return true;
        }

        public bool IsNotLimitSouth(int y)
        {
            return true;
        }

        public bool IsNotLimitWest(int x)
        {
            return true;
        }
    }
}