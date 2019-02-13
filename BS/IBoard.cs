namespace BS
{
    // DH: Does this interface meet ISP?
    public interface IBoard
    {
        // DH: Should this be encapsultated?
        Cell[,] Coordinates { get; }
        int Hits { get; }
        int Misses { get; }

        // DH: is this a construction step?
        /// <summary>
        /// Generate Ships in random position for Computer player 
        /// </summary>
        void InstallShips();

        bool IsLive();

        /// <summary>
        /// Process the hit toward the current <see cref="Board"/>
        /// </summary>
        bool? TakeHit(Coordinates loc);

        // DH: Never used outside of test code and internal
        bool AddShip(Ship ship, Coordinates loc, Direction direction);
    }
}