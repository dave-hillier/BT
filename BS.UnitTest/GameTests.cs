using System;
using Moq;
using NUnit.Framework;

namespace BS.UnitTest
{
    [TestFixture]
    public class GameTests
    {
        private Mock<IBoardWriter> _boardDisplayer;
        private Mock<IPlayerInput> _userInput;
        private readonly Random _rand = new Random();

        [OneTimeSetUp]
        public void Setup()
        {
            _boardDisplayer = new Mock<IBoardWriter>();
            _boardDisplayer.Setup(x => x.WriteBoard(It.IsAny<IBoard>()))
                .Callback((IBoard b) => DisplayCallBack(b));

            _userInput = new Mock<IPlayerInput>();
            _userInput.Setup(x => x.ReadDirection()).Returns(GenerateRandomDirection);
            _userInput.Setup(x => x.ReadCoordinates()).Returns(GenerateRandomCoords);
        }

        private Coordinates GenerateRandomCoords()
        {
            return new Coordinates(_rand.Next(Board.MaxRow), _rand.Next(Board.MaxColumn));
        }

        private Coordinates GenerateLimitedCoords()
        {
            return new Coordinates(_rand.Next(4), _rand.Next(4));
        }

        private Orientation GenerateRandomDirection()
        {
            return (Orientation) _rand.Next(1, 3);
        }

        private void DisplayCallBack(IBoard board)
        {
        }

        // [Test]
        public void GivenBadHits_ComputerShouldWin()
        {
            var userInput = new Mock<IPlayerInput>();
            userInput.Setup(x => x.ReadDirection()).Returns(Orientation.Vertical);
            // a Hack to limit hits 
            //( still there is a probability of having the computer's ship within this range)
            userInput.Setup(x => x.ReadCoordinates()).Returns(GenerateLimitedCoords);
            var game = new Game(_boardDisplayer.Object);
            var playerName = "Mohammad";

            game.New(playerName, true, "Test", true);
            game.Start();

            Assert.That(game.Winner, Is.Not.Null);
            Assert.That(game.Winner.Player.Name, Is.EqualTo(game.Computer.Player.Name));
        }

        [Test]
        public void GivenStartGame_PlayerName_ShouldAssignItToPlayer()
        {
            var game = new Game(_boardDisplayer.Object);
            var playerName = "Mohammad";

            game.New(playerName, true, "Test", true);
            game.Start();

            Assert.That(game.Player.Player.Name, Is.EqualTo(playerName));
        }

        [Test]
        public void WhenGameStart_ShouldStopOnlyIfPlayerWin()
        {
            var game = new Game(_boardDisplayer.Object);
            var playerName = "Mohammad";

            game.New(playerName, true, "Test", true);
            game.Start();

            Assert.That(game.Winner, Is.Not.Null);
        }
    }
}