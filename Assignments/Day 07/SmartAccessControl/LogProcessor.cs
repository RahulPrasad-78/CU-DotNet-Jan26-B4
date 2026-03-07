namespace SmartAccessControl
{
    internal class LogProcessor
    {

        static bool Validate(string gateCode, char userInitial, byte accessLevel, byte attempts)
        {
            if (gateCode.Length != 2 || !char.IsLetter(gateCode[0]) || !char.IsDigit(gateCode[1])) return true;
            if (!char.IsUpper(userInitial)) return true;
            if (accessLevel > 7 || accessLevel < 0) return true;
            if(attempts >200 || attempts < 0)   return true;

            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your GateCode, UserInitial, AccessLevel, IsActive and Attempts");
            string input = Console.ReadLine();
            string[] arr = input.Split('|');

            string gateCode = arr[0];
            char userInitial = char.Parse(arr[1]);
            byte accessLevel = byte.Parse(arr[2]);
            bool isActive = bool.Parse(arr[3]);
            byte attempts = byte.Parse(arr[4]);
            string status;

            if (Validate(gateCode, userInitial, accessLevel, attempts))
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }

            if(!isActive)
            {
                status = "ACCESS DENIED - INACTIVE USER";
            }
            else if(attempts > 100)
            {
                status = "ACCESS DENIED - TOO MANY ATTEMPTS";
            }
            else if (accessLevel >= 5)
            {
                status = "ACCESS GRANTED - HIGH SECURITY";
            }
            else
            {
                status = "ACCESS GRANTED - STANDARD";
            }

            Console.WriteLine($"Gate     : {gateCode, -10}");
            Console.WriteLine($"User     : {userInitial, -10}");
            Console.WriteLine($"Level    : {accessLevel, -10}");
            Console.WriteLine($"Attempts : {attempts, -10}");
            Console.WriteLine($"Status   : {status, -10}");
        }
    }
}
