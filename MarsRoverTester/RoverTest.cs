using System;
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
            MarsRover rover = new MarsRover(iniX, iniY, iniOrientation);
            Assert.AreEqual(expectedPosition, rover.moveAhead());
        }
        
        [TestCase(1,0,'S', "1 0 S")]
        [TestCase(0,1,'O', "0 1 O")]
        public void GivenTheRoverIsInTheLimitWhenMovingAheadWillStayAtSamePosition(int iniX, int iniY, char iniOrientation, string expectedPosition)
        {
            MarsRover rover = new MarsRover(iniX, iniY, iniOrientation);
            Assert.AreEqual(expectedPosition, rover.moveAhead());
        }
        
    }

    public class MarsRover
    {
        private int _iniX;
        private int _iniY;
        private readonly char _iniOrientation;

        public MarsRover(int iniX, int iniY, char iniOrientation)
        {
            _iniX = iniX;
            _iniY = iniY;
            _iniOrientation = iniOrientation;
        }

        public string moveAhead()
        {
            switch (_iniOrientation)
            {
                case 'N':
                    _iniY++;
                    break;
                case 'S':
                    if(_iniY > 0)
                        _iniY--;
                    break;
                case 'E':
                    _iniX++;
                    break;
                case 'O':
                    if(_iniX > 0)
                        _iniX--;
                    break;
            }
            return $"{_iniX} {_iniY} {_iniOrientation}";
        }
    }
}