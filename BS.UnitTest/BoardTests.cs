using BS;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class BoardTest
    {

        [Test]
        public void When_GenerateShips_ShouldCreateThreeShips()
        {
            var board = new Board();

            board.GenerateShips();

            var expected = new List<Ship> { new Battleship(), new Destroyer(), new Destroyer() };
            CollectionAssert.AreEquivalent(expected.Select(s => s.Name), board.Ships.Select(s => s.Name));
        }

        [Test]
        public void GiveCoordinatesAndShip_BoardShouldAddShip()
        {
            var board = new Board();

            var added = board.AddShip(new Destroyer(), new Coordinates(4, 3), Direction.Down);

            Assert.True(added);
            Assert.That(board.Ships, Has.Count.EqualTo(1));
            Assert.That(board.Ships.First().Name, Is.EqualTo(new Destroyer().Name));
        }

        [Test]
        public void GiveRepeatedCoordinatesAndShip_BoardShouldNotAddShip()
        {
            var board = new Board();

            board.AddShip(new Destroyer(), new Coordinates(4, 3), Direction.Down);
            var added = board.AddShip(new Destroyer(), new Coordinates(4, 3), Direction.Down);

            Assert.False(added);
        }

        [Test]
        public void GiveCrosedCoordinatesAndShip_BoardShouldNotAddShip()
        {
            var board = new Board();

            board.AddShip(new Destroyer(), new Coordinates(4, 3), Direction.Down);
            var added = board.AddShip(new Destroyer(), new Coordinates(4, 4), Direction.Down);

            Assert.False(added);
        }

        [Test]
        public void GiveInvalidCoordinatesAndShip_BoardShouldNotAddShip()
        {
            var board = new Board();

            var added = board.AddShip(new Destroyer(), new Coordinates(14, 13), Direction.Down);

            Assert.False(added);
        }

        [Test]
        public void GiveStringCoordinatesAndShip_BoardShouldNotAddShip()
        {
            var board = new Board();

            var added = board.AddShip(new Destroyer(), "A5", "D");
            Assert.True(added);
            Assert.That(board.Ships, Has.Count.EqualTo(1));
        }
    }
}