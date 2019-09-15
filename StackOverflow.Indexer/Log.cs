using System;

namespace StackOverflow.Indexer
{
    public static class Log
    {
        public static void WriteLine(string message)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] {message}");
        }
    }
}