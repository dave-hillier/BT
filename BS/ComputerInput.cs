using System;

namespace BS
{
    public class ComputerInput : IPlayerInput
    {
        private readonly Random _rand = new Random();

        public Coordinates ReadCoordinates()
        {
            return new Coordinates(_rand.Next(Board.MaxRow), _rand.Next(Board.MaxColumn));
        }

        public Orientation ReadDirection()
        {
            return (Orientation) _rand.Next(1, 3);
        }
    }
}