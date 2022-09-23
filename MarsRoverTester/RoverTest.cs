using System;
using System.Xml.Schema;
using NUnit.Framework;

namespace MarsRoverTester
{
    [TestFixture]
    public class Tests
    {
        

        [TestCase(1,1,'N', "1 2 N" )]
        [TestCase(1,1,'S', "1 0 S")]
        [TestCase(1,1,'E', "2 1 E")]
        [TestCase(1,1,'O', "0 1 O")]
        public void MovementAhead(int iniX, int iniY, char iniOrientation, string expectedPosition)
        {
            Map map = new Map(2, 3);
            MarsRover rover = new MarsRover(iniX, iniY, iniOrientation, map);
            Assert.AreEqual(expectedPosition, rover.moveAhead());
        }
        
        [TestCase(1,0,'S', "1 0 S")]
        [TestCase(0,1,'O', "0 1 O")]
        [TestCase(0,3,'N', "0 3 N")]
        [TestCase(2,0,'E', "2 0 E")]
        public void GivenTheRoverIsInTheLimitWhenMovingAheadWillStayAtSamePosition(int iniX, int iniY, char iniOrientation, string expectedPosition)
        {
            
            Map map = new Map(2, 3);
            MarsRover rover = new MarsRover(iniX, iniY, iniOrientation, map);
            Assert.AreEqual(expectedPosition, rover.moveAhead());
        }

        [TestCase(1, 1, 'N', "1 0 N")]
        [TestCase(1, 1, 'S', "1 2 S")]
        [TestCase(1, 1, 'E', "0 1 E")]
        [TestCase(1, 1, 'O', "2 1 O")]
        public void MovementRear(int iniX, int iniY, char iniOrientation, string expectedPosition)
        {
            Map map = new Map(2, 3);
            MarsRover rover = new MarsRover(iniX, iniY, iniOrientation, map);
            Assert.AreEqual(expectedPosition, rover.moveRear());
        }

        [TestCase(1, 0, 'N', "1 0 N")]
        [TestCase(0, 1, 'E', "0 1 E")]
        [TestCase(0, 3, 'S', "0 3 S")]
        [TestCase(2, 0, 'O', "2 0 O")]
        public void GivenTheRoverIsInTheLimitWhenMovingRearWillStayAtSamePosition(int iniX, int iniY, char iniOrientation, string expectedPosition)
        {
            Map map = new Map(2, 3);
            MarsRover rover = new MarsRover(iniX, iniY, iniOrientation, map);
            Assert.AreEqual(expectedPosition, rover.moveRear());
        }
    }

    public class Map
    {
        public readonly int _maxX;
        public readonly int _maxY;

        public Map(int maxX, int maxY)
        {
            _maxX = maxX;
            _maxY = maxY;
            
        }
    }


    public class MarsRover
    {
        private int _iniX;
        private int _iniY;
        private readonly char _iniOrientation;
        private readonly Map _map;

        public MarsRover(int iniX, int iniY, char iniOrientation, Map map)
        {
            _iniX = iniX;
            _iniY = iniY;
            _iniOrientation = iniOrientation;
            _map = map;
        }

        public string moveAhead()
        {
            switch (_iniOrientation)
            {
                case 'N':
                    if(_iniY<_map._maxY)
                        _iniY++;
                    break;
                case 'S':
                    if(_iniY > 0)
                        _iniY--;
                    break;
                case 'E':
                    if(_iniX<_map._maxX)
                        _iniX++;
                    break;
                case 'O':
                    if(_iniX > 0)
                        _iniX--;
                    break;
            }
            return $"{_iniX} {_iniY} {_iniOrientation}";
        }

        public string moveRear()
        {
            switch (_iniOrientation)
            {
                case 'N':
                    if (_iniY > 0)
                        _iniY--;
                    break;
                case 'S':
                    if (_iniY < _map._maxY)
                        _iniY++;
                    break;
                case 'E':
                    if (_iniX > 0 )
                        _iniX--;
                    break;
                case 'O':
                    if (_iniX < _map._maxX)
                        _iniX++;
                    break;
            }
            return $"{_iniX} {_iniY} {_iniOrientation}";
        }
    }
}