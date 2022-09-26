using System;
using System.Xml.Schema;
using MarsRover;
using NUnit.Framework;

namespace MarsRoverTester
{
    [TestFixture]
    public class MarsRoverTest
    {
        [TestCase(1,1,CardinalPoint.Norte, "1 2 N" )]
        [TestCase(1,1,CardinalPoint.Sur, "1 0 S")]
        [TestCase(1,1,CardinalPoint.Este, "2 1 E")]
        [TestCase(1,1,CardinalPoint.Oeste, "0 1 O")]
        public void MovementAhead(int iniX, int iniY, CardinalPoint iniOrientation, string expectedPosition)
        {
            ExplorerRover rover = InitializeExplorer(iniX, iniY, iniOrientation);
            Assert.AreEqual(expectedPosition, rover.moveAhead());
        }

        [TestCase(1,0,CardinalPoint.Sur, "1 0 S")]
        [TestCase(0,1,CardinalPoint.Oeste, "0 1 O")]
        [TestCase(0,3,CardinalPoint.Norte, "0 3 N")]
        [TestCase(2,0,CardinalPoint.Este, "2 0 E")]
        public void GivenTheRoverIsInTheLimitWhenMovingAheadWillStayAtSamePosition(int iniX, int iniY, CardinalPoint iniOrientation, string expectedPosition)
        {
            ExplorerRover rover = InitializeExplorer(iniX, iniY, iniOrientation);
            Assert.AreEqual(expectedPosition, rover.moveAhead());
        }

        [TestCase(1, 1, CardinalPoint.Norte, "1 0 N")]
        [TestCase(1, 1, CardinalPoint.Sur, "1 2 S")]
        [TestCase(1, 1, CardinalPoint.Este, "0 1 E")]
        [TestCase(1, 1, CardinalPoint.Oeste, "2 1 O")]
        public void MovementRear(int iniX, int iniY, CardinalPoint iniOrientation, string expectedPosition)
        {
            ExplorerRover rover = InitializeExplorer(iniX, iniY, iniOrientation);
            Assert.AreEqual(expectedPosition, rover.moveRear());
        }

        [TestCase(1, 0, CardinalPoint.Norte, "1 0 N")]
        [TestCase(0, 1, CardinalPoint.Este, "0 1 E")]
        [TestCase(0, 3, CardinalPoint.Sur, "0 3 S")]
        [TestCase(2, 0, CardinalPoint.Oeste, "2 0 O")]
        public void GivenTheRoverIsInTheLimitWhenMovingRearWillStayAtSamePosition(int iniX, int iniY, CardinalPoint iniOrientation, string expectedPosition)
        {
            ExplorerRover rover = InitializeExplorer(iniX, iniY, iniOrientation);
            Assert.AreEqual(expectedPosition, rover.moveRear());
        }

        [TestCase(CardinalPoint.Norte, "0 0 O")]
        [TestCase(CardinalPoint.Oeste, "0 0 S")]
        [TestCase(CardinalPoint.Sur, "0 0 E")]
        [TestCase(CardinalPoint.Este, "0 0 N")]
        public void RotateToLeft(CardinalPoint iniOrientation, string expectedPosition)
        {
            ExplorerRover rover = InitializeExplorer(0, 0, iniOrientation);

            Assert.AreEqual(expectedPosition, rover.RotateLeft());
        }

        [TestCase(CardinalPoint.Norte, "0 0 E")]
        [TestCase(CardinalPoint.Oeste, "0 0 N")]
        [TestCase(CardinalPoint.Sur, "0 0 O")]
        [TestCase(CardinalPoint.Este, "0 0 S")]
        public void RotateToRight(CardinalPoint iniOrientation, string expectedPosition)
        {
            ExplorerRover rover = InitializeExplorer(0, 0, iniOrientation);

            Assert.AreEqual(expectedPosition, rover.RotateRight());
        }


        private static ExplorerRover InitializeExplorer(int iniX, int iniY, CardinalPoint iniOrientation)
        {
            Point point = new Point(iniX, iniY);
            Map map = new Map(2, 3);
            ExplorerRover rover = new ExplorerRover(point, iniOrientation, map);
            return rover;
        }
    }
}