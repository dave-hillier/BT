﻿using System;

namespace BS
{
    /// <summary>
    /// <see cref="Player" Manager/>
    /// </summary>
    public class PlayerManager // DH: Class named Manager is a smell particularly as its 
    {
        private readonly IBoard _board;
        private Random _rand = new Random();
        private readonly IPlayerInput _userInput;

        public PlayerManager(string name, bool isComputer)
        {
            _userInput = isComputer ? new ComputerInput() : _userInput = new UserInput();
            _board = new Board(_userInput);
            Player = new Player(name, isComputer);
            AddShips();
        }

        public IPlayer Player { get; }

        public int Hits => _board != null ? _board.Hits : 0; // DH: consider using the newer ?. language feature

        public object Misses => _board != null ? _board.Misses : 0;

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
            return _userInput.GetCoordinates();
        }

        /// <summary>
        /// Display the player board using the givin displayer adapter
        /// </summary>
        public void PrintStatus(IDisplayBoard displayer)
        {
            Player.PrintDetails();
            displayer.DisplayBoard(_board);
        }


        private void AddShips() // DH: why not inline this?
        {
            _board.InstallShips();
        }
    }
}