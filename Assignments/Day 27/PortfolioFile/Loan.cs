namespace PortfolioFile
{

    internal class Loan
    {
        public string ClientName { get; set; }
        public double Principal { get; set; }
        public double InterestRate { get; set; }
        //public Loan()
        //{
        //    ClientName = string.Empty;
        //    Principal = 0;
        //    InterestRate = 0;
        //}
        //public Loan(string name, double p, double ir)
        //{
        //    ClientName = name;
        //    Principal = p;
        //    InterestRate = ir;
        //}
        public override string ToString()
        {
            string risk = string.Empty;
            double total = Principal * (InterestRate / 100);
            if (InterestRate > 10) risk = "High";
            else if (InterestRate < 5) risk = "Low";
            else risk = "Medium";
            return $"|{ClientName,-15} | ${Principal,-10} | ${total,-10:f2} | {risk,-7} |";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            while (true)
            {
                Console.WriteLine("\nWant to Enter data or stop");
                string input = Console.ReadLine();
                if (input == "stop") break;

                Console.Write("Enter the name : ");
                string name = Console.ReadLine();
                Console.Write("Enter the Principal : ");
                double p = double.Parse(Console.ReadLine());
                Console.Write("Enter the Intreset Rate : ");
                double rate = double.Parse(Console.ReadLine());
                string data = name + "," + p + "," + rate;
                list.Add(data);
            }

            string path = @"../../../Loan.csv";
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                foreach (var item in list)
                {
                    //Console.WriteLine(item);
                    sw.WriteLine(item);
                }
            }
            //sw.Close();

            //string path1 = @"../../../Loan.csv";
            using StreamReader sr = new StreamReader(path);
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine($"|{"Name",-15} | {"Principal",-10}  | {"Intreset",-10:f2}  | {"Risk",-7} |");
            Console.WriteLine("-------------------------------------------------------");
            while (true)
            {
                string data = sr.ReadLine();
                if (data == null) break;
                Loan l;
                try
                {
                    string[] arr = data.Split(',');

                    l = new Loan
                    {
                        ClientName = arr[0],
                        Principal = double.Parse(arr[1]),
                        InterestRate = double.Parse(arr[2])
                    };
                    Console.WriteLine(l);
                }
                catch
                {
                    Console.WriteLine("Unexpexted error");
                }
            }
        }
    }
}
