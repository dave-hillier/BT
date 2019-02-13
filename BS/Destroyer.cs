namespace BS
{
    // DH: This is pure data. Do we really need this class?
    public class Destroyer : Ship
    {
        public override int Size => 2;
        public override ShipType Type => ShipType.Destroyer;
    }
}