namespace BS
{
    // DH: pure data don't need this
    public class Battleship : Ship
    {
        public override int Size => 5;
        public override ShipType Type => ShipType.Battleship;
    }
}