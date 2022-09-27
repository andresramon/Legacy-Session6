using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class ExplorerRover 
    {
        private ICardinal currentOrientationState;
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
            currentOrientationState = GetCardinal(iniOrientation);
            point = initialPoint;
            _map = map;
        }

        private ICardinal GetCardinal(CardinalPoint cardinalPoint)
        {
            switch (cardinalPoint)
            {
                case CardinalPoint.Norte:
                    return new Norte();
                case CardinalPoint.Oeste:
                    return new Oeste();
                case CardinalPoint.Sur:
                    return new Sur();
                case CardinalPoint.Este:
                    return new Este();
                default:
                    throw new ArgumentOutOfRangeException(nameof(cardinalPoint), cardinalPoint, null);
            }
        }
        public string ProcessCommand(string command)
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
                        MoveAhead();
                        break;
                    case 'D':
                        RotateRight();
                        break;
                    case 'R':
                        MoveRear();
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
            currentOrientationState = GetCardinal(currentOrientation);
        }

        public string MoveAhead()
        {
            
            switch (currentOrientationState.GetOrientation())
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

        public string MoveRear()
        {
            switch (currentOrientationState.GetOrientation())
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