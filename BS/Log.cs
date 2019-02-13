using System;

namespace BS
{
    /// <summary>
    /// Log output for console or for testing 
    /// </summary>
    public class Log // DH: could be static class 
    {
        public static void Output(string message) // DH: Consider consistency of terminology Output vs Print vs Write - all three are used, pick one
        {
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine("---------");
        }

        public static void Error(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
        }
    }
}