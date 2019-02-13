namespace BS
{
    /// <summary>
    /// Ship names with it's size
    /// </summary>
    public abstract class Ship
    {
        public abstract ShipType Type { get; }
        public abstract int Size { get; }
    }
}