namespace BS
{
    /// <summary>
    /// <see cref="Game" IPlayer/>
    /// </summary>
    public interface IPlayer // DH - looks a lot like a wrapper for string?
    {
        string Name { get; }

        // DH: is this used?
        /// <summary>
        /// Identify if it's a normal player or computer one.
        /// </summary>
        bool IsComputer { get; }

        /// <summary>
        /// Display the player board using the givin displayer adapter
        /// </summary>
        void PrintDetails();
    }
}