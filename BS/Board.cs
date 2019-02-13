using System.Collections.Generic;
using System.Linq;

namespace BS
{
    public class Board : IBoard
    {
        private const int ShipCapacity = 3;
        public const int MaxRow = 10;
        public const int MaxColumn = 10;
        private readonly IPlayerInput _playerInput;

        public Board(IPlayerInput playerInput)
        {
            _playerInput = playerInput;
            Hits = 0;
            Misses = 0;
            Ships = new List<Ship>();
            Coordinates = GenerateBoardCells();
        }

        public List<Ship> Ships { get; }
        public int Hits { get; private set; }
        public int Misses { get; private set; }
        public Cell[,] Coordinates { get; }


        /// <summary>
        /// Process the hit toward the current <see cref="Board"/>
        /// </summary>
        public bool? TakeHit(Coordinates loc)
        {
            if (!IsLive())
            {
                Log.Write("All ships have been sunk, and player lost already!, please check the correct value");
                return false;
            }

            if (Coordinates[loc.X, loc.Y] == Cell.Destroyer || Coordinates[loc.X, loc.Y] == Cell.Battleship)
            {
                Coordinates[loc.X, loc.Y] = Cell.Hit;
                Hits++;
                return true;
            }

            //Double hit should show as hit 
            Coordinates[loc.X, loc.Y] = Coordinates[loc.X, loc.Y] == Cell.Hit ? Cell.Hit : Cell.Miss;
            Misses++;
            return false;
        }

        /// <summary>
        /// Indicate if <see cref="Board"/> still have active <see cref="Ship"/>s
        /// </summary>
        public bool IsLive()
        {
            var totalShips = Ships.Select(x => (int) x.Type).Sum();

            return Hits < totalShips;
        }

        /// <summary>
        /// Add <see cref="Ship" />
        /// </summary>
        /// <returns>true of added, and false if not been added</returns>
        public bool AddShip(Ship ship, Coordinates startLocation, Orientation orientation)
        {
            if (InvalidCapacity(ship))
            {
                return false;
            }

            var endLocation = GetEndLocation(ship.Size, startLocation, orientation);

            var cells = EnsureEmptyCells(startLocation, endLocation);

            if (cells == null)
            {
                Log.Write($"Cannot add {ship.Type} on your board at {startLocation} toward {orientation}");
                return false;
            }

            UpdateCells(cells, ship);
            Ships.Add(ship);
            Log.Write($"Ship {ship} added on your board at {startLocation} toward {orientation}");
            return true;
        }

        public void InstallShips()
        {
            AddShip(new Ship { Size = 4, Type = ShipType.Destroyer });
            AddShip(new Ship { Size = 4, Type = ShipType.Destroyer });
            AddShip(new Ship { Size = 5, Type = ShipType.Battleship });
        }

        private Cell[,] GenerateBoardCells()
        {
            var cells = new Cell[MaxRow, MaxColumn];
            ;
            for (var x = 0; x < MaxRow; x++)
            for (var y = 0; y < MaxColumn; y++)
                cells.SetValue(Cell.Empty, x, y);
            return cells;
        }

        private void AddShip(Ship ship)
        {
            Log.Write($"Adding ship: {ship}");
            while (true)
            {
                var coords = _playerInput.ReadCoordinates();
                if (ValidCoordinates(coords))
                {
                    var dir = _playerInput.ReadDirection();
                    var added = AddShip(ship, coords, dir);
                    if (added)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Update Cell with <see cref="Ship.Type"/> shortcut 
        /// </summary>
        private void UpdateCells(List<Coordinates> coordinates, Ship ship)
        {
            foreach (var loc in coordinates) Coordinates[loc.X, loc.Y] = ship.ToCell();
        }

        private Coordinates GetEndLocation(int shipSize, Coordinates loc, Orientation orientation)
        {
            int x;
            int y;

            if (orientation == Orientation.Vertical)
            {
                x = loc.X;
                y = loc.Y + shipSize;
            }
            else
            {
                x = loc.X + shipSize;
                y = loc.Y;
            }

            return new Coordinates(x, y);
        }

        /// <summary>
        /// Check Board capacity of ships 
        /// </summary>
        private bool InvalidCapacity(Ship ship)
        {
            if (Ships.Count == ShipCapacity)
            {
                Log.Write($"You have the maximum number of ships:({ShipCapacity})!");
                return true;
            }

            if (ship.Type == ShipType.Battleship)
            {
                if (Ships.Count(s => s.Type == ShipType.Battleship) == 1)
                {
                    return true;
                }
            }
            else
            {
                if (Ships.Count(s => s.Type == ShipType.Destroyer) == 2)
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Make sure that position for ship is empty 
        /// </summary>
        private List<Coordinates> EnsureEmptyCells(Coordinates startLoc, Coordinates endLoc)
        {
            var validLocs = new List<Coordinates>();
            if (!ValidCoordinates(startLoc) || !ValidCoordinates(endLoc))
            {
                return null;
            }

            for (var x = startLoc.X; x < endLoc.X; x++)
            {
                if (Coordinates[x, startLoc.Y] > Cell.Miss)
                {
                    return null;
                }

                validLocs.Add(new Coordinates(x, startLoc.Y));
            }

            for (var y = startLoc.Y; y < endLoc.Y; y++)
            {
                if (Coordinates[startLoc.X, y] > Cell.Miss)
                {
                    return null;
                }

                validLocs.Add(new Coordinates(startLoc.X, y));
            }

            return validLocs;
        }

        /// <summary>
        /// Ensure <see cref="Coordinates"/> within the range of <see cref="Board"/>
        /// </summary>
        public static bool ValidCoordinates(Coordinates loc)
        {
            return loc.Y >= 0 && loc.Y < MaxColumn && loc.X >= 0 && loc.X < MaxRow;
        }
    }
}