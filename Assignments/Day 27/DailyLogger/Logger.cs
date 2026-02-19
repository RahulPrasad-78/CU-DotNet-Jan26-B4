namespace DailyLogger
{
    internal class Logger
    {
        static void Main(string[] args)
        {
            string file = @"../../../journal.txt";
            Console.WriteLine(file);

            using StreamWriter sw = new StreamWriter(file, true);
            while (true)
            {
                Console.WriteLine("Enter the Daily Journal Data ");
                string data = Console.ReadLine();
                if (data == "stop") break;
                sw.WriteLine(data);
            }

            //StreamReader

        }
    }
}
