namespace DictionaryIns
{
    class Policy
    {
        public string HolderName { get; set; }
        public decimal Premium { get; set; }
        public int RiskScore { get; set; }
        public DateTime RenewalDate { get; set; }

        public Policy(string name, decimal premium, int risk, DateTime renewal)
        {
            HolderName = name;
            Premium = premium;
            RiskScore = risk;
            RenewalDate = renewal;
        }
    }
    internal class Program
    {
        public static void BulkAdjustment(Dictionary<string, Policy> policies)
        {
            foreach (var item in policies)
            {
                if (item.Value.RiskScore > 75)
                {
                    item.Value.Premium =
                        item.Value.Premium + (item.Value.Premium * 0.05m);
                }
            }
        }

        public static void CleanUp(Dictionary<string, Policy> policies)
        {
            List<string> removeKeys = new List<string>();

            foreach (var item in policies)
            {
                if (item.Value.RenewalDate < DateTime.Today.AddYears(-3))
                {
                    removeKeys.Add(item.Key);
                }
            }

            foreach (var key in removeKeys)
            {
                policies.Remove(key);
            }
        }

        public static void SecurityCheck(Dictionary<string, Policy> policies, string id)
        {


            Policy pol;
            bool exists = policies.TryGetValue(id, out pol);

            if (exists)
            {
                Console.WriteLine($"Name - {pol.HolderName}");
                Console.WriteLine($"Premium - {pol.Premium}");
                Console.WriteLine($"Risk Score - {pol.RiskScore} ");
                Console.WriteLine($"Renewable Date - {pol.RenewalDate}");
            }
            else
            {
                Console.WriteLine("Policy Not Found");
            }
        }
        static void Main(string[] args)
        {
            Dictionary<string, Policy> policies = new Dictionary<string, Policy>();

            policies.Add("101", new Policy("Rahul", 2000m, 80, DateTime.Today.AddYears(-3)));
            policies.Add("102", new Policy("Rohan", 1000m, 65, DateTime.Today.AddYears(-6)));
            policies["103"] = new Policy("Rohit", 18000m, 90, DateTime.Today.AddMonths(-7));
            policies["104"] = new Policy("Ram", 30000m, 70, DateTime.Today.AddYears(-9));

            Console.Write("Enter Policy ID: ");
            string? id = Console.ReadLine();
            BulkAdjustment(policies);
            CleanUp(policies);
            SecurityCheck(policies, id);
        }
    }
}
