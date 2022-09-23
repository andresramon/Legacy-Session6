using System;
using System.Xml.Schema;
using MarsRover;
using NUnit.Framework;

namespace MarsRoverTester
{
    [TestFixture]
    public class MarsRoverTest
    {
        [TestCase(1,1,'N', "1 2 N" )]
        [TestCase(1,1,'S', "1 0 S")]
        [TestCase(1,1,'E', "2 1 E")]
        [TestCase(1,1,'O', "0 1 O")]
        public void MovementAhead(int iniX, int iniY, char iniOrientation, string expectedPosition)
        {
            Map map = new Map(2, 3);
            ExplorerRover rover = new ExplorerRover(iniX, iniY, iniOrientation, map);
            Assert.AreEqual(expectedPosition, rover.moveAhead());
        }
        
        [TestCase(1,0,'S', "1 0 S")]
        [TestCase(0,1,'O', "0 1 O")]
        [TestCase(0,3,'N', "0 3 N")]
        [TestCase(2,0,'E', "2 0 E")]
        public void GivenTheRoverIsInTheLimitWhenMovingAheadWillStayAtSamePosition(int iniX, int iniY, char iniOrientation, string expectedPosition)
        {
            
            Map map = new Map(2, 3);
            ExplorerRover rover = new ExplorerRover(iniX, iniY, iniOrientation, map);
            Assert.AreEqual(expectedPosition, rover.moveAhead());
        }

        [TestCase(1, 1, 'N', "1 0 N")]
        [TestCase(1, 1, 'S', "1 2 S")]
        [TestCase(1, 1, 'E', "0 1 E")]
        [TestCase(1, 1, 'O', "2 1 O")]
        public void MovementRear(int iniX, int iniY, char iniOrientation, string expectedPosition)
        {
            Map map = new Map(2, 3);


            ExplorerRover rover = new ExplorerRover(iniX, iniY, iniOrientation, map);
            Assert.AreEqual(expectedPosition, rover.moveRear());
        }

        [TestCase(1, 0, 'N', "1 0 N")]
        [TestCase(0, 1, 'E', "0 1 E")]
        [TestCase(0, 3, 'S', "0 3 S")]
        [TestCase(2, 0, 'O', "2 0 O")]
        public void GivenTheRoverIsInTheLimitWhenMovingRearWillStayAtSamePosition(int iniX, int iniY, char iniOrientation, string expectedPosition)
        {
            Map map = new Map(2, 3);
            ExplorerRover rover = new ExplorerRover(iniX, iniY, iniOrientation, map);
            Assert.AreEqual(expectedPosition, rover.moveRear());
        }
    }
}