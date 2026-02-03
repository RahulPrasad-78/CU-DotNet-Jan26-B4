namespace OLADriver
{
    class OLADriver
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string VehicleNo { get; set; }
        public List<Ride> Rides { get; set; }

        public override string ToString()
        {
            Console.WriteLine($"Driver ID - {ID}, Name - {Name}, Vehicle No - {VehicleNo}");
            foreach (var r in Rides)
            {
                Console.WriteLine(r);
            }
            return "\n";
        }
    }

    class Ride
    {
        public int RideID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Fair { get; set; }
        public Ride(int rideId, string from, String to, int fair)
        {
            RideID = rideId;
            From = from;
            To = to;
            Fair = fair;
        }

        public override string ToString()
        {
            return $"Ride ID - {RideID}, From - {From}, To - {To}, Fair - {Fair}";
        }
    }

    class App
    {
        static void Main(string[] args)
        {

            Ride r1 = new Ride(101, "Chandigarh", "Delhi", 3000);
            Ride r2 = new Ride(102, "Jaipur", "Delhi", 4000);
            Ride r3 = new Ride(103, "UP", "Bihar", 2000);
            Ride r4 = new Ride(104, "Bihar", "Asam", 10000);
            Ride r5 = new Ride(105, "Chandigarh", "Noida", 3000);


            OLADriver d1 = new OLADriver()
            {
                ID = 2001,
                Name = "Rahul",
                VehicleNo = "HR45R",
                Rides = new List<Ride> { r1, r2 }
            };

            OLADriver d2 = new OLADriver()
            {
                ID = 1005,
                Name = "Rohit",
                VehicleNo = "ABCD56",
                Rides = new List<Ride> { r3, r4 }
            };

            OLADriver d3 = new OLADriver()
            {
                ID = 6574,
                Name = "Ram",
                VehicleNo = "XYZ67R",
                Rides = new List<Ride> { r5 }
            };

            Console.WriteLine(d1);
            Console.WriteLine(d2);
            Console.WriteLine(d3);
        }
    }
}
