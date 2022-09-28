using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class ExplorerRover 
    {
        private ICardinal currentOrientationState;
        private Map map;
        private Point point;
        private CommandFactory factory;

        public ExplorerRover():this(CommandFactory.Instance)
        {
            
        }
        public ExplorerRover(CommandFactory factory)
        {
            this.factory = factory;
        }
        public ExplorerRover(Point initialPoint, CardinalPointEnum iniOrientation, Map map)
        {
            currentOrientationState = CardinalPoint.GetCardinal(iniOrientation);
            point = initialPoint;
            this.map = map;
        }

        public string ProcessCommand(string command)
        {
            string[] inputLines = command.Split('\n');
            map = Map.CreateMapFromDimension(inputLines[0]);
            SetInitialPositionOrientation(inputLines[1]);
            ProcessMovement(inputLines[2]);
            
            return PrintPosition();
        }

        private void ProcessMovement(string movements)
        {
            foreach (char singleMove in movements)
            {
                ICommand command = factory.GetCommand(singleMove.ToString(),this);
                command.Execute();
            }
        }

        private void SetInitialPositionOrientation(string initialPositionOrientation)
        {
            string[] inputPositionOrientation = initialPositionOrientation.Split(' ');
            point = new Point(int.Parse(inputPositionOrientation[0]), int.Parse(inputPositionOrientation[1]));
            currentOrientationState = CardinalPoint.GetCardinalFromString(inputPositionOrientation[2]);
        }

        public string MoveAhead()
        {
            currentOrientationState.TryMoveAhead(map,point);
            return PrintPosition();
        }

        public string MoveRear()
        {
            point = currentOrientationState.TryMoveRear(map,point);
            return PrintPosition();
        }
        
        private string PrintPosition()
        {
            return $"{point.X} {point.Y} {(char)currentOrientationState.GetOrientation()}";
        }

        public string RotateLeft()
        {
            currentOrientationState = currentOrientationState.RotateLeft();
            return PrintPosition();
        }

        public string RotateRight()
        {
            currentOrientationState = currentOrientationState.RotateRight();
            return PrintPosition();
        }
    }
}