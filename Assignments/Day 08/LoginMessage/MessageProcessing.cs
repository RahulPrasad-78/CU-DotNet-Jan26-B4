namespace LoginMessage
{
    internal class MessageProcessing
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your login process");
            string input = Console.ReadLine();
            string[] inputs = input.Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            string name = inputs[0];
            string message = inputs[1];
            message = message.ToLower();

            bool compare = true;
            if(!message.Equals("login successful"))
            {
                compare = false;
            }

            string status="";
            if (!message.Contains("successful"))
            {
                status = "LOGIN FAILED";
            }
            else if(message.Contains("successful") && compare == true)
            {
                status = "LOGIN SUCCESS";
            }
            else if(message.Contains("successful") && compare == false)
            {
                status = "LOGIN SUCCESS (CUSTOM MESSAGE)";
            }

            Console.WriteLine($"User    : {name, -10}");
            Console.WriteLine($"Message : {message, -10}");
            Console.WriteLine($"Status  : {status, -10}");
        }
    }
}
