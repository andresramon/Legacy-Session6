using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class ExplorerRover 
    {
        private ICardinal currentOrientationState;
        private Map map;
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
            currentOrientationState = GetCardinal(iniOrientation);
            point = initialPoint;
            this.map = map;
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
            map = Map.CreateMapFromDimension(inputLines[0]);
            SetInitialPositionOrientation(inputLines[1]);
            ProcessMovement(inputLines[2]);
            
            return PrintPosition();
        }

        private void ProcessMovement(string movements)
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

        private void SetInitialPositionOrientation(string initialPositionOrientation)
        {
            string[] inputPositionOrientation = initialPositionOrientation.Split(' ');
            point = new Point(int.Parse(inputPositionOrientation[0]), int.Parse(inputPositionOrientation[1]));
            cardinalDictionary.TryGetValue(inputPositionOrientation[2], out CardinalPoint currentOrientation);
            currentOrientationState = GetCardinal(currentOrientation);
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