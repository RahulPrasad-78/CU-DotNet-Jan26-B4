namespace SwiftRoute
{

    class RestrictedDestinationException : Exception
    {
        public RestrictedDestinationException(string message) : base(message) { }
    }

    class InsecurePackagingException : Exception
    {
        public InsecurePackagingException(string message) : base(message) { }
    }
    abstract class Shipment
    {
        public double Weight { get; set; }
        public string Destination { get; set; }
        public string TrackingID { get; set; }
        public bool IsFragile { get; set; }
        public bool IsReinforced { get; set; }
        abstract public void ProcessShipment();

        public string[] restrictedArea = { "North Pole", "Unknown Island", "Antartica", "North Korea" };
    }

    class ExpressShipment : Shipment
    {
        public override void ProcessShipment()
        {
            try
            {
                for (int i = 0; i < restrictedArea.Length; i++)
                {
                    if (restrictedArea[i] == Destination) throw new RestrictedDestinationException("This Destination is Not Allowed");
                }
                if (IsFragile == true && IsReinforced == false)
                    throw new InsecurePackagingException("Product is Not Reinforced");
                if (Weight < 0) throw new ArgumentOutOfRangeException("Wight cannot be less then 0");
            }
            finally
            {
                Console.WriteLine($"Process Complete for {TrackingID}");
            }
        }
        public bool HeavyPermit()
        {
            if (Weight > 1000) return true;
            return false;
        }
    }

    interface ILoggable
    {
        void SaveLog(string message);
    }

    class LogManager : ILoggable
    {
        public void SaveLog(string message)
        {
            string path = @"../../../shipment_audit.log";
            try
            {

                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured");
            }
        }
    }

    internal class Logistics
    {

        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            LogManager log = new LogManager();
            while (true)
            {
                Console.WriteLine("\nYou Want to Enter Data ?");
                string? input = Console.ReadLine().ToLower();
                if (input != "no" && input != "yes") continue;
                if (input == "no") break;

                Console.Write("Enter the ID: ");
                string? id = Console.ReadLine();
                Console.Write("Enter shipment Weight: ");
                string? weight = Console.ReadLine();
                Console.Write("Enter Destination: ");
                string? dist = Console.ReadLine();
                Console.Write("shipment fragile?: ");
                bool isFragile = Console.ReadLine().ToLower() == "yes";
                Console.Write("shipment reinforced?: ");
                bool isReinforced = Console.ReadLine().ToLower() == "yes";

                string data = id + "," + weight + "," + dist + "," + isFragile + "," + isReinforced;
                list.Add(data);
            }

            for (int i = 0; i < list.Count; i++)
            {
                string[] data = new string[5];
                try
                {
                    data = list[i].Split(",");
                }
                catch
                {
                    Console.WriteLine("Range out of bound");
                }

                ExpressShipment shipment = new ExpressShipment()
                {
                    TrackingID = data[0],
                    Weight = Convert.ToDouble(data[1]),
                    Destination = data[2],
                    IsFragile = bool.Parse(data[3]),
                    IsReinforced = bool.Parse(data[4]),
                };
                try
                {
                    shipment.ProcessShipment();
                    if(shipment.HeavyPermit())
                        log.SaveLog($"Trancation ID - {shipment.TrackingID},  Status :- Successful, Heavy Permit Required");
                    log.SaveLog($"Trancation ID - {shipment.TrackingID},  Status :- Successful");
                }
                catch (RestrictedDestinationException ex)
                {
                    log.SaveLog($"Trancation ID - {shipment.TrackingID},  Status :- {ex.Message}");
                }
                catch (InsecurePackagingException ex)
                {
                    log.SaveLog($"Trancation ID - {shipment.TrackingID},  Status :- {ex.Message}");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    log.SaveLog($"Trancation ID - {shipment.TrackingID},  Status :- {ex.Message}");
                }
                catch (Exception ex)
                {
                    log.SaveLog($"Trancation ID - {shipment.TrackingID},  Status :- {ex.Message}");
                }

            }
        }
    }
}
