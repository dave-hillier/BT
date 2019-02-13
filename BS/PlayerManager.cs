namespace BS
{
    /// <summary>
    /// <see cref="Player" Manager/>
    /// </summary>
    public class PlayerManager // DH: Class named Manager is a smell particularly as its 
    {
        private readonly IBoard _board;
        private readonly IPlayerInput _userInput;

        public PlayerManager(string name, bool isComputer)
        {
            _userInput = isComputer ? new ComputerInput() : _userInput = new UserInput();
            _board = new Board(_userInput);
            Player = new Player(name, isComputer);
            _board.InstallShips();
        }

        public IPlayer Player { get; }

        public int Hits => _board?.Hits ?? 0;

        public object Misses => _board?.Misses ?? 0;

        internal bool Lost()
        {
            return !_board.IsLive();
        }

        internal void TakeHit(Coordinates loc)
        {
            _board.TakeHit(loc);
        }

        public Coordinates Hit()
        {
            return _userInput.ReadCoordinates();
        }

        /// <summary>
        /// Display the player board using the givin displayer adapter
        /// </summary>
        public void PrintStatus(IBoardWriter displayer)
        {
            Player.PrintDetails();
            displayer.WriteBoard(_board);
        }
    }
}