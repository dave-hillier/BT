using System;
using System.Reflection;
using Ninject;

namespace BS
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Log.Write("Welcome to Battel Ship game!");
            Log.Write("Would you like to start a game ? [Yy] for yes, anykey for no");
            var newGame = Console.ReadLine();
            if (newGame.ToLower() == "y")
            {
                StartNewGame();
            }

            Log.Write("Good bye");
        }

        private static void StartNewGame()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            Log.Write("Please enter your name");
            var playerName = Console.ReadLine();
            var game = kernel.Get<Game>();
            
            game.New(playerName, false, "Computer", true);
            game.Start();
        }
    }
}