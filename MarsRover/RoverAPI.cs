using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class RoverAPI
    {

        public string ProcessCommand(string command, bool isFlying = false)
        {
            string[] inputLines = command.Split('\n');
            SetInitialPositionOrientation(inputLines[1], out Point point, out ICardinal currentOrientationState);

            if (isFlying)
            {
                return GetFlyingRover(point, currentOrientationState).ProcessMovement(inputLines[2]);
            }
            return GetLandRover(inputLines[0], point, currentOrientationState).ProcessMovement(inputLines[2]);
        }

        private IRover GetLandRover(string command, Point point, ICardinal currentOrientationState)
        {
            return new ExplorerRover(point, currentOrientationState.GetOrientation(),LandMap.CreateMapFromDimension(command));
        }
        private IRover GetFlyingRover(Point point, ICardinal currentOrientationState)
        {
            return new FlyerRover(new ExplorerRover(point, currentOrientationState.GetOrientation(), new FlightMap()));
        }

        private void SetInitialPositionOrientation(string initialPositionOrientation, out Point point, out ICardinal currentOrientationState)
        {
            string[] inputPositionOrientation = initialPositionOrientation.Split(' ');
            point = new Point(int.Parse(inputPositionOrientation[0]), int.Parse(inputPositionOrientation[1]));
            currentOrientationState = CardinalPoint.GetCardinalFromString(inputPositionOrientation[2]);
        }
    }
}