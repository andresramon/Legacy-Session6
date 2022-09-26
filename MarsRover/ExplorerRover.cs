using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class ExplorerRover
    {
        private CardinalPoint currentOrientation;
        private Map _map;
        private Point point;
        private Dictionary<string, CardinalPoint> cardinalDictionary= new Dictionary<string, CardinalPoint>() {
            {
                "N",CardinalPoint.Norte   
            },
            {
                "S",CardinalPoint.Sur   
            },
            {
                "O",CardinalPoint.Oeste   
            },
            {
                "E",CardinalPoint.Este   
            }
        };

        public ExplorerRover()
        {
            
        }
        public ExplorerRover(Point initialPoint, CardinalPoint iniOrientation, Map map)
        {
            currentOrientation = iniOrientation;
            point = initialPoint;
            _map = map;
        }

        public string processCommand(string command)
        {
            string[] inputLines = command.Split('\n');
            createMap(inputLines[0]);
            setInitialPositionOrientation(inputLines[1]);
            processMovement(inputLines[2]);
            
            return PrintPosition();
        }

        private void processMovement(string movements)
        {
            foreach (char singleMove in movements)
            {
                switch (singleMove)
                {
                    case 'A':
                        moveAhead();
                        break;
                    case 'D':
                        RotateRight();
                        break;
                    case 'R':
                        moveRear();
                        break;
                    case 'I':
                        RotateLeft();
                        break;
                }
            }
        }
        private void createMap(string dimensionMap)
        {
            string[] inputDimensions = dimensionMap.Split(' ');
            _map = new Map(int.Parse(inputDimensions[0]), int.Parse(inputDimensions[1]));
        }

        private void setInitialPositionOrientation(string initialPositionOrientation)
        {
            string[] inputPositionOrientation = initialPositionOrientation.Split(' ');
            point = new Point(int.Parse(inputPositionOrientation[0]), int.Parse(inputPositionOrientation[1]));
            cardinalDictionary.TryGetValue(inputPositionOrientation[2], out currentOrientation);
        }

        public string moveAhead()
        {
            switch (currentOrientation)
            {
                case CardinalPoint.Norte:
                    TryMoveNorth();
                    break;
                case CardinalPoint.Sur:
                    TryMoveSouth();
                    break;
                case CardinalPoint.Este:
                    TryMoveEast();
                    break;
                case CardinalPoint.Oeste:
                    TryMoveWest();
                    break;
            }
            return PrintPosition();
        }

        public string moveRear()
        {
            switch (currentOrientation)
            {
                case CardinalPoint.Norte:
                    TryMoveSouth();
                    break;
                case CardinalPoint.Sur:
                    TryMoveNorth();
                    break;
                case CardinalPoint.Este:
                    TryMoveWest();
                    break;
                case CardinalPoint.Oeste:
                    TryMoveEast();
                    break;
            }
            return PrintPosition();
        }

        private void TryMoveEast()
        {
            if (_map.IsNotLimitEast(point.X))
            {
                point.X++;
            }
        }

        private void TryMoveWest()
        {
            if (_map.IsNotLimitWest(point.X))
            {
                point.X--;
            }
        }


        private void TryMoveNorth()
        {
            if (_map.IsNotLimitNorth(point.Y))
            {
                point.Y++;
            }
        }

        private void TryMoveSouth()
        {
            if (_map.IsNotLimitSouth(point.Y))
            {
                point.Y--;
            }
        }

        private string PrintPosition()
        {
            return $"{point.X} {point.Y} {(char)currentOrientation}";
        }

        public string RotateLeft()
        {
            switch (currentOrientation)
            {
                case CardinalPoint.Norte:
                    currentOrientation = CardinalPoint.Oeste;
                    break;
                case CardinalPoint.Sur:
                    currentOrientation = CardinalPoint.Este;
                    break;
                case CardinalPoint.Este:
                    currentOrientation = CardinalPoint.Norte;
                    break;
                case CardinalPoint.Oeste:
                    currentOrientation = CardinalPoint.Sur;
                    break;
            }
            return PrintPosition();
        }

        public string RotateRight()
        {
            switch (currentOrientation)
            {
                case CardinalPoint.Norte:
                    currentOrientation = CardinalPoint.Este;
                    break;
                case CardinalPoint.Sur:
                    currentOrientation = CardinalPoint.Oeste;
                    break;
                case CardinalPoint.Este:
                    currentOrientation = CardinalPoint.Sur;
                    break;
                case CardinalPoint.Oeste:
                    currentOrientation = CardinalPoint.Norte;
                    break;
            }
            return PrintPosition();
        }
    }
}