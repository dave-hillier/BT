using System;

namespace BS
{
    /// <summary>
    /// Log output for console or for testing 
    /// </summary>
    public static class Log 
    {
        public static void Write(string message) 
        {
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine("---------");
        }

        public static void WriteError(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
        }
    }
}