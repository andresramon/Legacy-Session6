using System.Runtime.ExceptionServices;

namespace MarsRover
{
    public class Norte : ICardinal
    {
        // public string moveAhead()
        // {
        //     if (_map.IsNotLimitNorth(point.Y))
        //     {
        //         point.Y++;
        //     }
        //     return "";
        // }
        //
        // public string moveRear()
        // {
        //     return "";
        // }
        public CardinalPoint GetOrientation()
        {
            return CardinalPoint.Norte;
        }

        public ICardinal RotateLeft()
        {
            return new Oeste();
        }

        public ICardinal RotateRight()
        {
            return new Este();
        }
    
    }
}