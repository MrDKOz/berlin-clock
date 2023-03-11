using System;

namespace BerlinClock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clock = new BerlinClock();
            
            for (;;)
            {
                Console.WriteLine(clock.GetTime(DateTime.Now));
                
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.Clear();
            }
        }
    }
}