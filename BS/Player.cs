using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS
{
    /// <summary>
    /// <see cref="Game" Player/>
    /// </summary>
    public class Player : IPlayer
    {
        public string Name { get; private set; }

        /// <summary>
        /// Identify if it's a normal player or computer one.
        /// </summary>
        public bool IsComputer { get; private set; }

        public Player(string name, bool isComputer)
        {
            Name = name;
            IsComputer = isComputer;
        }

        /// <summary>
        /// Display the player board using the givin displayer adapter
        /// </summary>
        public void PrintDetails()
        {
            Log.Output(Name);
        }
    }
}