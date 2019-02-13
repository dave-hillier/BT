using NUnit.Framework;

namespace BS.UnitTest
{
    [TestFixture]
    public class ShipExtensionTests
    {
        [Test] // DH: missing Test?
        public void GivenDestroyer_ShouldGetDestroyerCell() 
        {
            Assert.That(new Ship { Size = 4, Type = ShipType.Destroyer }.ToCell(), Is.EqualTo(Cell.Destroyer));
        }

        [Test]
        public void GivenBattelship_ShouldGetBattelshipCell()
        {
            Assert.That(new Ship { Size = 5, Type = ShipType.Battleship }.ToCell(), Is.EqualTo(Cell.Battleship));
        }
    }
}