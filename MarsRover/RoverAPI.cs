using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class RoverAPI
    {
        public string ProcessCommand(string command)
        {
            string[] inputLines = command.Split('\n');
            SetInitialPositionOrientation(inputLines[1], out Point point, out ICardinal currentOrientationState);

            ExplorerRover rover = new ExplorerRover(point, currentOrientationState.GetOrientation(), Map.CreateMapFromDimension(inputLines[0]));

            return rover.ProcessMovement(inputLines[2]);
        }

        private void SetInitialPositionOrientation(string initialPositionOrientation, out Point point, out ICardinal currentOrientationState)
        {
            string[] inputPositionOrientation = initialPositionOrientation.Split(' ');
            point = new Point(int.Parse(inputPositionOrientation[0]), int.Parse(inputPositionOrientation[1]));
            currentOrientationState = CardinalPoint.GetCardinalFromString(inputPositionOrientation[2]);
        }
    }
}
