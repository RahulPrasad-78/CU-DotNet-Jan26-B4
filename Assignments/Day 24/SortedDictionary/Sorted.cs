using System.Collections;
using System.Collections.Generic;

namespace SortedDictionary
{
    internal class Sorted
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, string> leaderboard = new SortedDictionary<double, string>();
            leaderboard.Add(55.42, "SwiftRacer");
            leaderboard.Add(52.10, "speedDemon");
            leaderboard.Add(58.91, "SteadyEddie");
            leaderboard.Add(51.05, "TurboTom");

            foreach (var item in leaderboard)
            {
                Console.WriteLine($"Name - {item.Value}, Time - {item.Key}");
            }

            Console.WriteLine($"\nThe First Place Holder Name is {leaderboard.Values.First()}" +
                $"with time {leaderboard.Keys.First()}");

            double key = 0;
            foreach (var item in leaderboard)
            {
                if (item.Value == "SteadyEddie") key = item.Key; 
            }

            leaderboard.Remove(key);
            leaderboard.Add(54.00, "SteadyEddie");
        }
    }
}
