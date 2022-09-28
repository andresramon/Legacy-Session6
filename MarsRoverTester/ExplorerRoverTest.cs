using System;
using System.Xml.Schema;
using MarsRover;
using NUnit.Framework;

namespace MarsRoverTester
{
    [TestFixture]
    public class MarsRoverTest
    {
        [TestCase(1,1,CardinalPointEnum.Norte, "1 2 N" )]
        [TestCase(1,1,CardinalPointEnum.Sur, "1 0 S")]
        [TestCase(1,1,CardinalPointEnum.Este, "2 1 E")]
        [TestCase(1,1,CardinalPointEnum.Oeste, "0 1 O")]
        public void MovementAhead(int iniX, int iniY, CardinalPointEnum iniOrientation, string expectedPosition)
        {
            ExplorerRover rover = InitializeExplorer(iniX, iniY, iniOrientation);
            Assert.AreEqual(expectedPosition, rover.MoveAhead());
        }

        [TestCase(1,0,CardinalPointEnum.Sur, "1 0 S")]
        [TestCase(0,1,CardinalPointEnum.Oeste, "0 1 O")]
        [TestCase(0,3,CardinalPointEnum.Norte, "0 3 N")]
        [TestCase(2,0,CardinalPointEnum.Este, "2 0 E")]
        public void GivenTheRoverIsInTheLimitWhenMovingAheadWillStayAtSamePosition(int iniX, int iniY, CardinalPointEnum iniOrientation, string expectedPosition)
        {
            ExplorerRover rover = InitializeExplorer(iniX, iniY, iniOrientation);
            Assert.AreEqual(expectedPosition, rover.MoveAhead());
        }

        [TestCase(1, 1, CardinalPointEnum.Norte, "1 0 N")]
        [TestCase(1, 1, CardinalPointEnum.Sur, "1 2 S")]
        [TestCase(1, 1, CardinalPointEnum.Este, "0 1 E")]
        [TestCase(1, 1, CardinalPointEnum.Oeste, "2 1 O")]
        public void MovementRear(int iniX, int iniY, CardinalPointEnum iniOrientation, string expectedPosition)
        {
            ExplorerRover rover = InitializeExplorer(iniX, iniY, iniOrientation);
            Assert.AreEqual(expectedPosition, rover.MoveRear());
        }

        [TestCase(1, 0, CardinalPointEnum.Norte, "1 0 N")]
        [TestCase(0, 1, CardinalPointEnum.Este, "0 1 E")]
        [TestCase(0, 3, CardinalPointEnum.Sur, "0 3 S")]
        [TestCase(2, 0, CardinalPointEnum.Oeste, "2 0 O")]
        public void GivenTheRoverIsInTheLimitWhenMovingRearWillStayAtSamePosition(int iniX, int iniY, CardinalPointEnum iniOrientation, string expectedPosition)
        {
            ExplorerRover rover = InitializeExplorer(iniX, iniY, iniOrientation);
            Assert.AreEqual(expectedPosition, rover.MoveRear());
        }

        [TestCase(CardinalPointEnum.Norte, "0 0 O")]
        [TestCase(CardinalPointEnum.Oeste, "0 0 S")]
        [TestCase(CardinalPointEnum.Sur, "0 0 E")]
        [TestCase(CardinalPointEnum.Este, "0 0 N")]
        public void RotateToLeft(CardinalPointEnum iniOrientation, string expectedPosition)
        {
            ExplorerRover rover = InitializeExplorer(0, 0, iniOrientation);

            Assert.AreEqual(expectedPosition, rover.RotateLeft());
        }

        [TestCase(CardinalPointEnum.Norte, "0 0 E")]
        [TestCase(CardinalPointEnum.Oeste, "0 0 N")]
        [TestCase(CardinalPointEnum.Sur, "0 0 O")]
        [TestCase(CardinalPointEnum.Este, "0 0 S")]
        public void RotateToRight(CardinalPointEnum iniOrientation, string expectedPosition)
        {
            ExplorerRover rover = InitializeExplorer(0, 0, iniOrientation);

            Assert.AreEqual(expectedPosition, rover.RotateRight());
        }
        
        [TestCase("5 5\n0 1 N\nA\n", "0 2 N")]
        [TestCase("5 5\n0 1 N\nAADADRIA\n", "2 4 E")]
        public void OrderToRover(string order, string expectedPosition)
        {
            ExplorerRover rover = new ExplorerRover();
            Assert.AreEqual(expectedPosition, rover.ProcessCommand(order));
        }


        private static ExplorerRover InitializeExplorer(int iniX, int iniY, CardinalPointEnum iniOrientation)
        {
            Point point = new Point(iniX, iniY);
            Map map = new Map(2, 3);
            ExplorerRover rover = new ExplorerRover(point, iniOrientation, map);
            return rover;
        }
    }
}