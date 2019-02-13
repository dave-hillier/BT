using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace BS.UnitTest
{
    [TestFixture]
    public class BoardTest
    {
        private readonly IPlayerInput _userInput = new UserInput();
        private readonly Ship _destroyer = new Ship {Size = 4, Type = ShipType.Destroyer};

        [Test]
        public void GiveCoordinatesAndShip_BoardShouldAddShip()
        {
            var board = new Board(_userInput);

            var added = board.AddShip(_destroyer, new Coordinates(4, 3), Direction.Down);

            Assert.True(added);
            Assert.That(board.Ships, Has.Count.EqualTo(1));
            Assert.That(board.Ships.First().Type, Is.EqualTo(_destroyer.Type));
        }

        [Test]
        public void GiveCrossedCoordinatesAndShip_BoardShouldNotAddShip()
        {
            var board = new Board(_userInput);

            board.AddShip(_destroyer, new Coordinates(4, 3), Direction.Down);
            var added = board.AddShip(_destroyer, new Coordinates(4, 4), Direction.Down);

            Assert.False(added);
        }

        [Test]
        public void GiveInvalidCoordinatesAndShip_BoardShouldNotAddShip()
        {
            var board = new Board(_userInput);

            var added = board.AddShip(_destroyer, new Coordinates(14, 13), Direction.Down);

            Assert.False(added);
        }

        [Test]
        public void GivenInValidHit_BoardShouldIncreaseMisses()
        {
            var board = new Board(_userInput);
            board.AddShip(_destroyer, new Coordinates(1, 1), Direction.Down);

            board.TakeHit(new Coordinates(3, 3));

            Assert.That(board.Misses, Is.EqualTo(1));
            Assert.That(board.Hits, Is.EqualTo(0));
        }

        [Test]
        public void GivenValidHit_BoardShouldIncreaseHits()
        {
            var board = new Board(_userInput);
            board.AddShip(_destroyer, new Coordinates(1, 1), Direction.Down);

            board.TakeHit(new Coordinates(1, 1));

            Assert.That(board.Misses, Is.EqualTo(0));
            Assert.That(board.Hits, Is.EqualTo(1));
        }


        [Test]
        public void GivenValidHitsEqualToShip_BoardLive_ShouldBeFalse()
        {
            var board = new Board(_userInput);
            board.AddShip(_destroyer, new Coordinates(1, 1), Direction.Down);

            board.TakeHit(new Coordinates(1, 1));
            board.TakeHit(new Coordinates(1, 2));

            Assert.That(board.Hits, Is.EqualTo(2));
            Assert.IsFalse(board.IsLive());
        }

        [Test]
        public void GivenValidHitsTwice_BoardCell_ShouldShowHit()
        {
            var board = new Board(_userInput);
            board.AddShip(_destroyer, new Coordinates(1, 1), Direction.Down);

            board.TakeHit(new Coordinates(1, 1));
            board.TakeHit(new Coordinates(1, 1));

            Assert.That(board.Hits, Is.EqualTo(1));
            Assert.That(board.Coordinates[1, 1], Is.EqualTo(Cell.Hit));
        }

        [Test]
        public void GiveRepeatedCoordinatesAndShip_BoardShouldNotAddShip()
        {
            var board = new Board(_userInput);

            board.AddShip(_destroyer, new Coordinates(4, 3), Direction.Down);
            var added = board.AddShip(_destroyer, new Coordinates(4, 3), Direction.Down);

            Assert.False(added);
        }

        [Test]
        public void When_GenerateShips_ShouldCreateThreeShips()
        {
            var board = new Board(new ComputerInput());

            board.InstallShips();

            var expected = new List<Ship> {new Ship { Size= 5, Type = ShipType.Battleship }, _destroyer, _destroyer};
            CollectionAssert.AreEquivalent(expected.Select(s => s.Type), board.Ships.Select(s => s.Type));
        }
    }
}