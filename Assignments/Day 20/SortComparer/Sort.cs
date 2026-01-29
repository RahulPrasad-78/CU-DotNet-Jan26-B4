namespace SortComparer
{
    class Flight : IComparable<Flight>
    {
        public string FlightNumber { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime DepartureTime { get; set; }

        public int CompareTo(Flight? other)
        {
            return this.Price.CompareTo(other?.Price);
        }

        public override string ToString()
        {
            return $"Flight Number - {FlightNumber}, Price - {Price}, Duration - {Duration} min, Departure Time - {DepartureTime}";
        }
    }

    class DuractionComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            return x.Duration.CompareTo(y?.Duration);
        }
    }

    class DepartureComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            return x.DepartureTime.CompareTo(y?.DepartureTime);
        }
    }
    internal class Sort
    {
        static void Main(string[] args)
        {
            List<Flight> flights = new List<Flight>()
            {
                new Flight()
                {
                    FlightNumber = "1075",
                    Price = 5679,
                    Duration = TimeSpan.FromMinutes(120),
                    DepartureTime = DateTime.Parse("2026-02-17 23:42:12"),
                },

                new Flight()
                {
                    FlightNumber = "2031",
                    Price = 7234,
                    Duration = TimeSpan.FromMinutes(220),
                    DepartureTime = DateTime.Parse("2026-03-10 12:30:00"),
                },

                new Flight()
                {
                    FlightNumber = "1011",
                    Price = 2013,
                    Duration = TimeSpan.FromMinutes(130),
                    DepartureTime = DateTime.Parse("2026-01-03 19:45:30"),
                }
            };

            Console.WriteLine("Econommy View:");
            flights.Sort();
            foreach(var flight in flights)
            {
                Console.WriteLine(flight);
            }

            Console.WriteLine("\nBusiness Runner View");
            IComparer<Flight> f1 = new DuractionComparer();
            flights.Sort(f1);
            foreach (var flight in flights)
            {
                Console.WriteLine(flight);
            }

            Console.WriteLine("\nEarly Bird View");
            IComparer<Flight> f2 = new DepartureComparer();
            flights.Sort(f2);
            foreach (var flight in flights)
            {
                Console.WriteLine(flight);
            }
        }
    }
}
